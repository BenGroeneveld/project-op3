using System;
using System.Windows.Forms;

namespace Gui
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            var saldoForm = new Saldo();
            saldoForm.Show();
            this.Hide();
            saldoForm.Closed += (s, args) => this.Close();
        }

        private void btnGeldOpnemen_Click(object sender, EventArgs e)
        {
            var geldOpnemenForm = new GeldOpnemen();
            geldOpnemenForm.Show();
            this.Hide();
            geldOpnemenForm.Closed += (s, args) => this.Close();
        }
    }
}