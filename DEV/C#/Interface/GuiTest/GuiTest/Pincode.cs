using System;
using System.Windows.Forms;

namespace Gui
{
    public partial class Pincode : Form
    {
        public int password = 0;
        private int correctPassword = 0;
        private string cardID = ArduinoInput.strCardID;
        private bool uitloggen = false;
        private bool approval = true;
        private bool correctie = false;

        public Pincode()
        {
            InitializeComponent();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            MainBackend.restart();
        }

        private void btnVolgende_Click(object sender, EventArgs e)
        {
            try
            {
                if(password != correctPassword)
                {
                    approval = false;
                    clearPincode();
                    label2.Text = "Verkeerd wachtwoord";
                    approval = true;
                    setup();

                    string str = strNumberPushed();
                    inputInloggen.Text = str;
                    checkButtonPushed();
                }
                else
                {
                    nextPage();
                }
            }
            catch
            {
                label2.Text = "Error! [NXTc]";
            }
        }

        public void setup()
        {
            setCardID();
            setCorrectPassword();
        }

        public void setCardID()
        {
            privateSetCardID(cardID);
        }

        private void privateSetCardID(string str)
        {
            txtCardID.Text = str;
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
                label2.Text = "Error! [PW01]";
            }
        }

        private void clearPincode()
        {
            inputInloggen.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Pincode_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            setup();

            string str = strNumberPushed();
            if(correctie)
            {
                btnCorrectie.PerformClick();
            }
            else if(uitloggen)
            {
                btnUitloggen.PerformClick();
            }
            else
            {
                inputInloggen.Text = str;
            }
        }

        private string strNumberPushed()
        {
            string str = "";
            string strNumber = "";

            if(approval)
            {
                while(str.Equals("") || str.Equals("B") || str.Equals("D"))
                {
                    str = ArduinoInput.strInputText();
                    if(str.Equals("A"))
                    {
                        correctie = true;
                    }
                    else if(str.Equals("C"))
                    {
                        uitloggen = true;
                    }
                    else
                    {
                        strNumber = str;
                    }
                }
            }
            return strNumber;
        }

        private void checkButtonPushed()
        {
            string str = ArduinoInput.strInputText();

            if(str.Equals("A"))
            {
                btnCorrectie.PerformClick();
            }
            else if(str.Equals("C"))
            {
                btnUitloggen.PerformClick();
            }
            else if(str.Equals("D"))
            {
                btnVolgende.PerformClick();
            }
        }

        private void inputInloggen_TextChanged(object sender, EventArgs e)
        {
            if(!inputInloggen.Text.Equals(""))
            {
                string str = strNumberPushed();
                if(correctie)
                {
                    btnCorrectie.PerformClick();
                }
                else if(uitloggen)
                {
                    btnUitloggen.PerformClick();
                }
                else
                {
                    textBox1.Text = str;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!textBox1.Text.Equals(""))
            {
                string str = strNumberPushed();
                if(correctie)
                {
                    btnCorrectie.PerformClick();
                }
                else if(uitloggen)
                {
                    btnUitloggen.PerformClick();
                }
                else
                {
                    textBox2.Text = str;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(!textBox2.Text.Equals(""))
            {
                string str = strNumberPushed();
                if(correctie)
                {
                    btnCorrectie.PerformClick();
                }
                else if(uitloggen)
                {
                    btnUitloggen.PerformClick();
                }
                else
                {
                    textBox3.Text = str;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(!textBox3.Text.Equals(""))
            {
                string passwordStr = inputInloggen.Text + textBox1.Text + textBox2.Text + textBox3.Text;
                password = Convert.ToInt32(passwordStr);
                checkButtonPushed();
            }
        }

        private void nextPage()
        {
            var next = new MainMenu();
            next.Show();
            Hide();
            next.Closed += (s, args) => Close();
        }

        private void btnCorrectie_Click(object sender, EventArgs e)
        {
            approval = false;

            clearPincode();

            correctie = false;
            approval = true;

            string str = strNumberPushed();
            if(correctie)
            {
                btnCorrectie.PerformClick();
            }
            else if(uitloggen)
            {
                btnUitloggen.PerformClick();
            }
            else
            {
                inputInloggen.Text = str;
            }
        }
    }
}
