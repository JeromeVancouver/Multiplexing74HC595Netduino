using System;
using Microsoft.SPOT;
using System.IO.Ports;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using System.Threading;


namespace PHAOneWire
{
    class OneWire : IDisposable
    {
        // This code is designed to work with Peter H. Anderson's RS232 to Dallas OneWire Controller:
        // http://www.phanderson.com/stamp/onewire.html
        // You would connect the controller to D0 and D1 (connecting RX to TX, TX to RX) on the Netduino

        private SerialPort _COM1;

        public static byte[] GetByteArray(string s)
        {
            return System.Text.Encoding.UTF8.GetBytes(s);
        }
        public static byte GetByteFromHex(string s)
        {
            return GetByteFromHex(GetByteArray(s));
        }
        public static byte GetByteFromHex(byte[] ba)
        {
            return (byte)((((ba[0] > 96) ? ba[0] - 87 : ba[0] - 48) * 16) + ((ba[1] > 96) ? ba[1] - 87 : ba[1] - 48));
        }

        public OneWire()
        {
            this._COM1 = new SerialPort(SerialPorts.COM1, 9600);
            this._COM1.Open();
        }

        public void Write(string s)
        {
            byte[] ba = GetByteArray(s);
            this._COM1.Write(ba, 0, ba.Length);
        }
        public byte ReadByte(int port = 0)
        {
            byte[] ReadBytes = new byte[4];
            string s = "R" + port.ToString().Trim();
            Write(s);
            Thread.Sleep(20);  //needs enough time to send/receive the data

            _COM1.Read(ReadBytes, 0, 4);

            return GetByteFromHex(ReadBytes);
        }

        public void Dispose()
        {
            if (this._COM1.IsOpen)
            {
                this._COM1.Close();
            }
            this._COM1.Dispose();
        }
    }
}
