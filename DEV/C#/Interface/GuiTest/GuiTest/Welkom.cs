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

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            new Pincode().Show();
            this.Hide();
        }
    }
}
