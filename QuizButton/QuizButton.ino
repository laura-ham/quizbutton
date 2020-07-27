//#define RFNANO 1

#include <EEPROM.h>

#include <DigitalIO.h>
#include <printf.h>
#include <nRF24L01.h>

#ifdef RFNANO
  #include <RF24_config.h>
  #include <RF24.h>
  RF24 rf(10, 9);
#else
  #include <RF24_config.h>
  #include <RF24.h>
  RF24 rf(A0, A1);
#endif

#define ADDRESS_EEPROM 0
#define MASTER_EEPROM 1
#define TIMEOUT 5000
#define DEBOUNCE 100
#define ACK_TIMEOUT 5000

uint8_t payload = 1;
uint8_t broadcast[] = "*sl";
uint8_t address[] = "0sl";
uint8_t masterAddress[] = "mst";
uint8_t masterSendAddress[] = "0sl";

bool master = false;

long lampOnTimeStamp = 0;
long pressTimeStamp = 0;

#define LINE_FLUSH_TIMEOUT 100
#define LINE_IDLE_TIMEOUT 500
char lineBuffer[100];
uint8_t lineCount;
bool lineOverflow = false;
long lastCharTimestamp;

void setupModule() {
    if (!rf.begin()){
      digitalWrite(3, HIGH);
      Serial.println("Could not start RF module");
      while(1);
    }
    Serial.println("RF module initialized");
    rf.setAddressWidth(3);
    rf.setChannel(10);
    rf.openWritingPipe(masterAddress);
    rf.openReadingPipe(1, address);
    rf.openReadingPipe(2, broadcast);
  
    rf.setAutoAck(1);                    // Ensure autoACK is enabled
    rf.enableAckPayload();               // Allow optional ack payloads
    rf.enableDynamicPayloads();          // Ack payloads are dynamic payloads
    rf.setRetries(0,15);                 // Smallest time between retries, max no. of retries
    rf.setPayloadSize(1);                // Here we are sending 1-byte payloads to test the call-response speed
    fdevopen(&my_putc, 0);
    //rf.printDetails();                   // Dump the configuration of the rf unit for debugging
    
    rf.startListening();
}

// the setup function runs once when you press reset or power the board
void setup() {
  Serial.begin(115200);
  Serial.println("Start");

  uint8_t addressEeprom = EEPROM.read(ADDRESS_EEPROM);
  if(addressEeprom == 255)
  {
    //Uninitialized EEPROM
    addressEeprom = '0';
    EEPROM.write(ADDRESS_EEPROM, addressEeprom);
  }
  address[0] = addressEeprom;
  Serial.print("Address: ");
  Serial.println((char*)address);
  
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(2, INPUT);
  pinMode(3, OUTPUT);
  digitalWrite(2, HIGH);
  digitalWrite(3, LOW);
  setupModule();

  //Startup as master if button is pressed at startup
  if(!digitalRead(2))
  {
    switchToMaster();
  }
}

int my_putc( char c, FILE *t) {
  Serial.write( c );
}

void switchToMaster()
{
  master = true;
  rf.stopListening();
  rf.closeReadingPipe(1);
  //rf.closeReadingPipe(2);
  rf.openReadingPipe(1, masterAddress);
  rf.openWritingPipe(broadcast);
  rf.setPayloadSize(1);                // Here we are sending 1-byte payloads to test the call-response speed
  rf.startListening();
  uint8_t payload = 1;
  rf.writeAckPayload(1,&payload, 1);
  Serial.println("Switching to master");
}

// the loop function runs over and over again forever
void loop() {
  if (master) 
  {
    if (rf.available()) {
      char line[] = "Line claimed: 0";
      rf.read(&line[sizeof(line)-2], 1);
      digitalWrite(3, HIGH);
      Serial.println(line);
      delay(TIMEOUT);
      //Flush rf
      uint8_t data;
      while(rf.available())
      {
        rf.read(&data, 1);
      }
      uint8_t payload = 1;
      rf.flush_tx();
      rf.writeAckPayload(1,&payload, 1);
      digitalWrite(3, LOW);
    }
  } 
  else 
  {
    if (pressTimeStamp == 0 && ! digitalRead(2)) 
    {
      Serial.println("Button pressed");
      uint8_t data = address[0];
      pressTimeStamp = millis();
      
      rf.stopListening();
      bool success = rf.write(&data, 1);
      
      if(!success)
      {
        Serial.println("Could not send data");
      }
      else if(rf.available())
      {
        rf.read(&data, 1);
        Serial.println("Response received:");
        lampOnTimeStamp = millis();
        digitalWrite(3, HIGH);
        uint8_t data;
        while(rf.available())
        {
          rf.read(&data, 1);
        }
      }
      else
      {
        Serial.println("No response received");
      }
      rf.startListening();
    }
    if(lampOnTimeStamp > 0 && millis() > lampOnTimeStamp + TIMEOUT)
    {
      lampOnTimeStamp = 0;
      digitalWrite(3, LOW);
    }
    if(pressTimeStamp != 0 && millis() - pressTimeStamp > DEBOUNCE && digitalRead(2))
    {
      pressTimeStamp = 0;
    }
  }

  //Handle serial communication
  int lineSize = completeLine();
  if(lineSize > 0)
  {
    switch(lineBuffer[0])
    {
      case 'm':
        switchToMaster();
        break;
      case 'i':
        handleID(lineSize);
        break;
      default:
        Serial.println("Unknown command received");
        break;
    }
  }
}

void handleID(int count)
{
  if(count != 2)
  {
    Serial.println("Expected 'i' followed by one byte ID");
    Serial.print("Character count for line was ");
    Serial.println(count);
    return;
  }
  address[0] = lineBuffer[1];
  EEPROM.write(ADDRESS_EEPROM, address[0]);
  Serial.print("Set id to ");
  Serial.println((char*)address);
}

int completeLine()
{
  while(Serial.available())
  {
    handleIdle();
    handleOverflow();
    if(!lineOverflow)
    {
      char c = Serial.read();
      lastCharTimestamp = millis();
      if(c == '\r' || c == '\n')
      {
        if(lineCount > 0)
        {
          //Line done
          int answer = lineCount;
          lineCount = 0;
          return answer;
        }
        //Else it was an empty line, we can skip that case: Line count is zero anyway so nothing needs to be reset
      }
      else
      {
        lineBuffer[lineCount++] = c;
      }
    }
  }
  return 0;
}

void handleIdle()
{
  if(!Serial.available())
  {
    return;
  }
  if(millis() - lastCharTimestamp > LINE_IDLE_TIMEOUT)
  {
    if(lineCount > 0)
    {
      //Idle timeout has passed, empty the current line
      Serial.println("Discarding unfinished line due to timeout");
      lineCount = 0;
    }
  }
}

void handleOverflow()
{
  if(lineCount == sizeof(lineBuffer))
  {
    //overflow
    lineCount = 0;
    lineOverflow = true;
    lastCharTimestamp = millis();
    Serial.println("Overflow - flushing...");
  }
  if(lineOverflow)
  {
    if(millis() - lastCharTimestamp > LINE_FLUSH_TIMEOUT)
    {
      //Flush timeout has passed, we can continue normally
      lineOverflow = false;
      Serial.println("Done flushing");
    }
    else
    {
      while(Serial.available())
      {
        //Flush data
        Serial.read();
        lastCharTimestamp = millis();
      }
    }
  }
}
