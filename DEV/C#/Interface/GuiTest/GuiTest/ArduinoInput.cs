using System;
using System.Threading;
using System.IO.Ports;

namespace Gui
{
    public static class ArduinoInput
    {
        public static string port = "";
        public static SerialPort currentPort;
        public static string strCardID = "";
        public static int connectionCorrect = 128;

        public static Boolean connect(int baud, string recognizeText, int loggedInValue)
        {
            try
            {
                byte[] buffer = new byte[5];
                buffer[0] = Convert.ToByte(16);
                buffer[1] = Convert.ToByte(connectionCorrect);
                buffer[2] = Convert.ToByte(0);
                buffer[3] = Convert.ToByte(loggedInValue);
                buffer[4] = Convert.ToByte(4);

                int intReturnASCII = 0;
                char charReturnValue = (Char)intReturnASCII;

                string[] ports = SerialPort.GetPortNames();
                foreach(string newport in ports)
                {
                    currentPort = new SerialPort(newport, baud);
                    currentPort.Open();
                    currentPort.Write(buffer, 0, 5);
                    Thread.Sleep(1000);
                    int count = currentPort.BytesToRead;
                    string returnMessage = "";
                    while(count > 0)
                    {
                        intReturnASCII = currentPort.ReadByte();
                        returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                        count--;
                    }

                    currentPort.Close();
                    port = newport;
                    if(returnMessage.Contains(recognizeText))
                    {
                        connectionCorrect = 127;
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static string strRFID()
        {
            string strCard = "ID";

            currentPort.Open();
            while(!strCardID.Contains(strCard))
            {
                strCardID = currentPort.ReadLine().ToString().Trim();
            }
            currentPort.Close();

            return strCardID;
        }

        public static string strInputText()
        {
            string str = "";

            currentPort.Open();
            while(str.Equals(""))
            {
                str = currentPort.ReadLine().ToString().Trim();
            }
            currentPort.Close();

            return str;
        }

        public static int intInputText()
        {
            string str = "";

            currentPort.Open();
            while(str.Equals("") || str.Contains("A") || str.Contains("B") || str.Contains("C") || str.Contains("D") || str.Contains("*") || str.Contains("#"))
            {
                str = currentPort.ReadLine().ToString().Trim();
            }
            currentPort.Close();

            int i = Convert.ToInt32(str);
            return i;
        }

        public static string message(int loggedInValue)
        {
            try
            {
                byte[] buffer = new byte[5];
                buffer[0] = Convert.ToByte(16);
                buffer[1] = Convert.ToByte(connectionCorrect);
                buffer[2] = Convert.ToByte(0);
                buffer[3] = Convert.ToByte(loggedInValue);
                buffer[4] = Convert.ToByte(4);

                currentPort.Open();
                currentPort.Write(buffer, 0, 5);
                int intReturnASCII = 0;
                char charReturnValue = (Char)intReturnASCII;
                Thread.Sleep(200);
                int count = currentPort.BytesToRead;
                string returnMessage = "";
                while(count > 0)
                {
                    intReturnASCII = currentPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                    count--;
                }
                currentPort.Close();
                return returnMessage;
            }
            catch(Exception e)
            {
                return "Error";
            }
        }
    }
}
