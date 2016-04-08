using System;
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
            Application.Restart();
        }

        private void btnPrintBonWel_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintBonNiet_Click(object sender, EventArgs e)
        {

        }
    }
}
