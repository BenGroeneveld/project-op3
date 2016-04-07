using System;
using System.IO.Ports;

namespace SerialPortTest
{
    public class Program
    {
        public static void Main()
        {
            string str = "";
            bool checkBool = true;
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            SerialPort mySerialPort = new SerialPort("COM6");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;
            
            mySerialPort.Open();
            while(checkBool)
            {
                str = mySerialPort.ReadLine();
                Console.WriteLine(str);

                if(stringComparer.Equals("id_107", str))
                {
                    checkBool = false;
                }
            }
            mySerialPort.Close();
        }
    }
}
