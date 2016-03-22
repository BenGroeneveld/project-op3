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
    public partial class GuiWindow : Form
    {
        public GuiWindow()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            Thread.Sleep(10); //GEVAARLIJK!!!!
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}