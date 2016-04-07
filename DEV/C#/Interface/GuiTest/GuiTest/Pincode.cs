using System;
using System.Threading;
using System.Windows.Forms;

namespace Gui
{
    public partial class Pincode : Form
    {
        public int password = 0;
        public Pincode()
        {
            InitializeComponent();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            new Welkom().Show();
            this.Close();
        }

        private void btnVolgende_Click(object sender, EventArgs e)
        {
            try
            {
                if(password == 1234)
                {
                    new MainMenu().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Verkeerd wachtwoord! Probeer opnieuw!");
                    new Pincode().Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("ERROR lullo");
            }
        }

        private void inputInloggen_TextChanged(object sender, EventArgs e)
        {
            int i = ArduinoInput.intInputText();
            textBox1.Text = Convert.ToString(i);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i = ArduinoInput.intInputText();
            textBox2.Text = Convert.ToString(i);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int i = ArduinoInput.intInputText();
            textBox3.Text = Convert.ToString(i);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string passwordStr = inputInloggen.Text + textBox1.Text + textBox2.Text + textBox3.Text;
            int passwordInt = Convert.ToInt32(passwordStr);
            password = passwordInt;
        }

        private void Pincode_Load(object sender, EventArgs e)
        {
            int i = ArduinoInput.intInputText();
            inputInloggen.Text = Convert.ToString(i);
        }
    }
}
