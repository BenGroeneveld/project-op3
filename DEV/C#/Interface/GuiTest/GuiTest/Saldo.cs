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
            Application.Restart();
        }

        private void btnVorige_Click(object sender, EventArgs e)
        {
            var geldOpnemenForm = new GeldOpnemen();
            geldOpnemenForm.Show();
            this.Hide();
            geldOpnemenForm.Closed += (s, args) => this.Close();
        }
    }
}
