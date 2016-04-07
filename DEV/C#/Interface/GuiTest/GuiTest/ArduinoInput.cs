using System;
using System.IO.Ports;

namespace Gui
{
    public static class ArduinoInput
    {
        public static string strInputText()
        {
            SerialPort mySerialPort = new SerialPort("COM6");
            mySerialPort.BaudRate = 9600;
            string str = "";

            mySerialPort.Open();
            while(str.Equals(""))
            {
                str = mySerialPort.ReadLine().ToString().Trim();
            }
            mySerialPort.Close();

            return str;
        }

        public static int intInputText()
        {
            SerialPort mySerialPort = new SerialPort("COM6");
            mySerialPort.BaudRate = 9600;
            string str = "";

            mySerialPort.Open();
            while(str.Equals("") || str.Equals("A") || str.Equals("B") || str.Equals("C") || str.Equals("D") || str.Equals("*") || str.Equals("#"))
            {
                str = mySerialPort.ReadLine().ToString().Trim();
            }
            mySerialPort.Close();

            int i = Convert.ToInt32(str);
            return i;
        }
    }
}
