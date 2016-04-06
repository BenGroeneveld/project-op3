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
    public partial class Saldo : Form
    {
        public Saldo()
        {
            InitializeComponent();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            new Welkom().Show();
            this.Hide();
        }

        private void btnVorige_Click(object sender, EventArgs e)
        {
            new GeldOpnemen().Show();
            this.Hide();
        }
    }
}
