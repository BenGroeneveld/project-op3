using System.Windows.Forms;

namespace Gui
{
    public partial class Background : Form
    {
        public Background()
        {
            InitializeComponent();
        }

        private void Background_Shown(object sender, System.EventArgs e)
        {
            var welkomForm = new Welkom();
            welkomForm.Show();
            this.Hide();
            welkomForm.Closed += (s, args) => this.Close();
        }
    }
}
