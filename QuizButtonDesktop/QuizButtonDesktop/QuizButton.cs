using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizButtonDesktop
{
    public class QuizButton
    {
        public delegate void MessageHandler(String text);
        public static event MessageHandler LineReceived;

        SerialPort port;
        private List<char> incomingData;

        public QuizButton()
        {
            incomingData = new List<char>();
        }

        public void connect(string portName)
        {
            if (port == null || !port.PortName.Equals(port))
            {
                var newPort = new SerialPort(portName);
                newPort.BaudRate = 115200;
                newPort.DataReceived += Port_DataReceived;

                if (port != null)
                {
                    port.DataReceived -= Port_DataReceived;
                    port.Close();
                    Thread.Sleep(100);
                }
                port = newPort;

                try
                {
                    port.Open();
                    port.WriteLine("m");//Switch button to master

                    Properties.Settings.Default["defaultPort"] = portName;
                    Properties.Settings.Default.Save();
                }
                catch (IOException) { }
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (port == null || !port.IsOpen)
            {
                return;
            }
            int available = port.BytesToRead;
            byte[] data = new byte[available];
            port.Read(data, 0, available);
            incomingData.AddRange(Encoding.ASCII.GetChars(data));
            while (incomingData.Contains('\r'))
            {
                int index = incomingData.IndexOf('\r');
                string line = new string(incomingData.GetRange(0, index + 1).ToArray()).Replace("\n", "").Replace('\r', '\n');
                incomingData.RemoveRange(0, index + 1);
                LineReceived?.Invoke(line);
            }
        }
    }
}
