using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gui
{
    public static class MainBackend
    {
        private static int baud = 9600;
        private static string recognizeText = "Arduino";
        public static int loggedInValue = 0;

        public static void doWelkom()
        {
            checkCard();
        }

        private static void checkCard()
        {
            loggedInValue = 0;
            ArduinoInput.strCardID = "";
            if(!ArduinoInput.isConnected(baud, recognizeText, loggedInValue))
            {
                ArduinoInput.connect(baud, recognizeText, loggedInValue);
            }
            else
            {
                while(!ArduinoInput.isConnected(baud, recognizeText, loggedInValue))
                {
                    ArduinoInput.connect(baud, recognizeText, loggedInValue);
                }
            }
            ArduinoInput.strCardID = ArduinoInput.strRFID();
            loggedInValue = 255;
        }

        public static void restart()
        {
            privateRestart();
        }

        private static void privateRestart()
        {
            Welkom next = new Welkom();

            List<Form> openForms = new List<Form>();

            foreach(Form f in Application.OpenForms)
            {
                openForms.Add(f);
            }
            
            foreach(Form f in openForms)
            {
                Type currentType = f.GetType();
                Type welkom = typeof(Welkom);
                Type pincode = typeof(Pincode);
                Type background = typeof(Background);

                if(!currentType.Equals(background))
                {
                    f.Close();
                }
            }
        }
    }
}
