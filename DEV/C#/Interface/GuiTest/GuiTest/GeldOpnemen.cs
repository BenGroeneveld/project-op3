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

namespace Gui
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
            this.Hide();
        }

        private void btnPrintBonWel_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintBonNiet_Click(object sender, EventArgs e)
        {

        }
    }
}
