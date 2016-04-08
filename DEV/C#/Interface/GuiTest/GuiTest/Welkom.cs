using System;
using System.Windows.Forms;

namespace Gui
{
    public partial class Welkom : Form
    {
        private int baud = 9600;
        private string recognizeText = "Arduino";
        private static int loggedInValue = 0;

        public Welkom()
        {
            InitializeComponent();
        }

        private void checkCard()
        {
            if(ArduinoInput.connect(baud, recognizeText, loggedInValue))
            {
                ArduinoInput.strCardID = ArduinoInput.strRFID();
                loggedInValue = 255;

                var pincodeForm = new Pincode();
                pincodeForm.Show();
                this.Hide();
                pincodeForm.Closed += (s, args) => this.Close();
            }
        }

        private void Welkom_Shown(object sender, EventArgs e)
        {
            loggedInValue = 0;
            checkCard();
        }
    }
}
