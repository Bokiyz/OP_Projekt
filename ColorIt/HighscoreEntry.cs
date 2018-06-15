using System;
using System.Windows.Forms;

namespace ColorIt
{
    public partial class HighscoreEntry : Form
    {
        private bool flag = false;

        public HighscoreEntry()
        {
            InitializeComponent();
        }

        public String poteziValue { get; set; }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            if(txtboxIme.Text != "")
            {
                DB.DBUnos(txtboxIme.Text, poteziValue.ToString());

                flag = true;
                Close();
            }
            else
            {
                MessageBox.Show("Unesi ime!", "Greška", MessageBoxButtons.OK);
            }
        }

        private void HighscoreEntry_Load(object sender, EventArgs e)
        {
            lblPoteziBroj.Text = poteziValue;
        }

        private void HighscoreEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                Enabled = false;
            }
            else
            {                
                DialogResult dialogResult = MessageBox.Show("Želite li unijeti rezultat?", "UPIT", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    Enabled = false;
                }
            }
        }
    }
}
