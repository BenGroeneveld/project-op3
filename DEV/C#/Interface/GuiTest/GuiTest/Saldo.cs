using System;
using System.Windows.Forms;

namespace Gui
{
    public partial class Saldo : Form
    {
        public Saldo()
        {
            InitializeComponent();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            MainBackend.restart();
        }

        private void btnVorige_Click(object sender, EventArgs e)
        {
            var geldOpnemenForm = new GeldOpnemen();
            geldOpnemenForm.Show();
            this.Hide();
            geldOpnemenForm.Closed += (s, args) => this.Close();
        }

        private void Saldo_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            checkButtonPushed();
        }

        private void checkButtonPushed()
        {
            string str = "";
            while(!(str.Equals("C") || str.Equals("D")))
            {
                str = ArduinoInput.strInputText();
                if(str.Equals("C"))
                {
                    btnUitloggen.PerformClick();
                }
                else if(str.Equals("D"))
                {
                    btnGeldOpnemen.PerformClick();
                }
            }
        }
    }
}
