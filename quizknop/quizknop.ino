#include <DigitalIO.h>
#include <printf.h>
#include <nRF24L01.h>
#include <RF24_config.h>
#include <RF24.h>

/*
  Blink

  Turns an LED on for one second, then off for one second, repeatedly.

  Most Arduinos have an on-board LED you can control. On the UNO, MEGA and ZERO
  it is attached to digital pin 13, on MKR1000 on pin 6. LED_BUILTIN is set to
  the correct LED pin independent of which board is used.
  If you want to know what pin the on-board LED is connected to on your Arduino
  model, check the Technical Specs of your board at:
  https://www.arduino.cc/en/Main/Products

  modified 8 May 2014
  by Scott Fitzgerald
  modified 2 Sep 2016
  by Arturo Guadalupi
  modified 8 Sep 2016
  by Colby Newman

  This example code is in the public domain.

  http://www.arduino.cc/en/Tutorial/Blink
*/

RF24 rf(A0, A1);

#define quiz_master 0
#define knop_nummer 1

uint8_t addresses[][6] = {"msr", "1sl", "2sl", "3sl", "4sl", "5sl"};

// the setup function runs once when you press reset or power the board
void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(2, INPUT);
  pinMode(3, OUTPUT);
  digitalWrite(2, HIGH);
  rf.begin();
  rf.setAddressWidth(3);
  if (quiz_master == 1) {
   //rf.openWritingPipe(addresses[0]);
   rf.openReadingPipe(1, addresses[0]);
  } else {
    rf.openWritingPipe(addresses[0]);
    rf.openReadingPipe(1, addresses[knop_nummer]);
  }
  rf.startListening();

  rf.setAutoAck(1);                    // Ensure autoACK is enabled
  rf.enableAckPayload();               // Allow optional ack payloads
  rf.setRetries(0,15);                 // Smallest time between retries, max no. of retries
  rf.setPayloadSize(1);                // Here we are sending 1-byte payloads to test the call-response speed

}

// the loop function runs over and over again forever
void loop() {
  if (quiz_master == 1) {
    if (rf.available()) {
      uint8_t data;
      rf.read(&data, 1);
      digitalWrite(3, HIGH);
      delay(5000);
      digitalWrite(3, LOW);
    }
  } else {
    if (! digitalRead(2)) {
      uint8_t data = 5;
      rf.stopListening();
      rf.write(&data, 1);
      rf.startListening();
    }
  }
}
