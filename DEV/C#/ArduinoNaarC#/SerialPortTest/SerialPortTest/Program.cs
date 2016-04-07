using System;
using System.IO.Ports;

namespace SerialPortTest
{
    public class Program
    {
        public static void Main()
        {
            string str = "";
            string strCheck = "1";
            bool checkBool = true;
            SerialPort mySerialPort = new SerialPort("COM6");
            mySerialPort.BaudRate = 9600;
            
            mySerialPort.Open();
            while(checkBool)
            {
                str = mySerialPort.ReadLine();
                Console.WriteLine(str);

                if(str.Equals(strCheck, StringComparison.OrdinalIgnoreCase))
                {
                    checkBool = false;
                }
            }
            mySerialPort.Close();
        }
    }
}
