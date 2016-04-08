using System;
using System.Windows.Forms;

namespace Gui
{
    public partial class Welkom : Form
    {
        public Welkom()
        {
            InitializeComponent();
        }

        private void checkCard()
        {
            ArduinoInput.strCardID = ArduinoInput.strRFID();
            new Pincode().Show();
            Hide();
        }

        private void Welkom_Shown(object sender, EventArgs e)
        {
            checkCard();
        }
    }
}
