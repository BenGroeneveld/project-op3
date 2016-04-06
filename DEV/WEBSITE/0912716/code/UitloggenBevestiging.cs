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
    public partial class UitloggenBevestiging : Form
    {
        public UitloggenBevestiging()
        {
            InitializeComponent();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            uitloggen();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void uitloggen()
        {
            List<Form> openForms = new List<Form>();

            foreach(Form f in Application.OpenForms)
            {
                openForms.Add(f);
            }

            foreach(Form f in openForms)
            {
                if(f.Name != "Welkom")
                {
                    f.Close();
                }
            }
        }
    }
}
