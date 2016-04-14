using System;
using System.Windows.Forms;

namespace Gui
{
    public partial class GeldOpnemen : Form
    {
        private int veelvoudBedrag = 10;
        private bool uitloggen = false;
        private bool leaveThisPage = false;
        private bool printBon = true;

        public GeldOpnemen()
        {
            InitializeComponent();
        }

        private void nextPage(bool printBon)
        {
            var bedankt = new Bedankt(printBon);
            bedankt.Show();
            this.Hide();
            bedankt.Closed += (s, args) => this.Close();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            MainBackend.restart();
        }

        private void btnPrintBonWel_Click(object sender, EventArgs e)
        {
            printBon = true;
            nextPage(printBon);
        }

        private void btnPrintBonNiet_Click(object sender, EventArgs e)
        {
            printBon = false;
            nextPage(printBon);
        }

        private void checkUitloggen()
        {
            if(uitloggen)
            {
                btnUitloggen.PerformClick();
            }
        }

        private void checkButtonPushed()
        {
            string str = "";

            while(str.Equals(""))
            {
                str = ArduinoInput.strInputText();

                if(str.Equals("A"))
                {
                    button1.PerformClick();
                }
                else if(str.Equals("B"))
                {
                    btnPrintBonWel.PerformClick();
                    leaveThisPage = true;
                }
                else if(str.Equals("C"))
                {
                    btnUitloggen.PerformClick();
                    leaveThisPage = true;
                }
                else if(str.Equals("D"))
                {
                    btnPrintBonNiet.PerformClick();
                    leaveThisPage = true;
                }
                else
                {
                    bedrag.Text += str;
                }
            }
        }

        private bool isCorrectBedrag(string str)
        {
            int i = Convert.ToInt32(str);
            if(i % veelvoudBedrag != 0)
            {
                label1.Text = "Incorrect bedrag.\nTyp een veelvoud van €" + veelvoudBedrag + ",00 in.";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GeldOpnemen_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            label1.Text = "Hoeveel geld wilt u opnemen?\nTyp een veelvoud van €" + veelvoudBedrag + ",00 in.";
            while(!leaveThisPage)
            {
                checkButtonPushed();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bedrag.ResetText();
        }
    }
}
