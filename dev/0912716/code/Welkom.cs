using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiTest
{
    public partial class Welkom : Form
    {
        public Welkom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WelkomTimer_Tick(object sender, EventArgs e)
        {
            new Pincode().Show();
            this.Hide();
            WelkomTimer.Stop();
        }
    }
}
