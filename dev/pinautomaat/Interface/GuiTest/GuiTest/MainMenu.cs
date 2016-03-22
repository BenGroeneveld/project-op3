using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiTest
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            new Welkom().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            new Saldo().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void btnGeldOpnemen_Click(object sender, EventArgs e)
        {
            new GeldOpnemen().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}