using System;
using System.Windows.Forms;

namespace Gui
{
    public partial class Pincode : Form
    {
        public int password = 0;
        private int correctPassword = 0;
        private string cardID = ArduinoInput.strCardID;
        private bool approval = false;

        public Pincode()
        {
            InitializeComponent();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnVolgende_Click(object sender, EventArgs e)
        {
            try
            {
                if(password != correctPassword)
                {
                    clearPincode();
                    label2.Text = "Verkeerd wachtwoord";
                    checkPincode();
                }
                else
                {
                    var mainMenuForm = new MainMenu();
                    mainMenuForm.Show();
                    this.Hide();
                    mainMenuForm.Closed += (s, args) => this.Close();
                }
            }
            catch
            {
                label2.Text = "Error! You broke it. Nice job!";
            }
        }

        private void setCorrectPassword()
        {
            if(cardID.Equals("ID107"))
            {
                correctPassword = 1070;
            }
            else if(cardID.Equals("ID182"))
            {
                correctPassword = 1820;
            }
            else if(cardID.Equals("ID231"))
            {
                correctPassword = 2310;
            }
            else
            {
                label2.Text = "Error! You broke it. Nice job! Password shizzles.";
            }
        }

        public void setCardID()
        {
            privateSetCardID(cardID);
        }

        private void privateSetCardID(string str)
        {
            txtCardID.Text = str;
        }

        public void setup()
        {
            setCardID();
            setCorrectPassword();
        }

        public void checkPincode()
        {
            approval = true;
            try
            {
                int i = ArduinoInput.intInputText();
                inputInloggen.Text = Convert.ToString(i);
            }
            catch
            {
                label2.Text = "Error while converting.";
            }
        }

        private void clearPincode()
        {
            approval = false;
            inputInloggen.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Pincode_Shown(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            setup();
            checkPincode();
        }

        private void inputInloggen_TextChanged(object sender, EventArgs e)
        {
            if(approval)
            {
                int i = ArduinoInput.intInputText();
                textBox1.Text = Convert.ToString(i);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(approval)
            {
                int i = ArduinoInput.intInputText();
                textBox2.Text = Convert.ToString(i);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(approval)
            {
                int i = ArduinoInput.intInputText();
                textBox3.Text = Convert.ToString(i);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(approval)
            {
                string passwordStr = inputInloggen.Text + textBox1.Text + textBox2.Text + textBox3.Text;
                password = Convert.ToInt32(passwordStr);
            }
        }
    }
}
