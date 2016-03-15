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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new GuiWindow().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }
    }
}
