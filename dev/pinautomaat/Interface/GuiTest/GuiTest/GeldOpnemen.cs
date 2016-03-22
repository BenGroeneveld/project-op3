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
    public partial class GeldOpnemen : Form
    {
        public GeldOpnemen()
        {
            InitializeComponent();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            new Welkom().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void btnVorige_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }
    }
}
