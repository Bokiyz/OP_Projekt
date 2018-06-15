using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Drawing;
using System.Collections.Generic;
using System;
using System.Threading;

namespace ColorIt
{
    public partial class Form1 : Form
    {
        ScriptEngine pyEngine = null;
        ScriptScope pyScope = null;
        public Color[] boje = new Color[6] {Color.Yellow, Color.Green, Color.Red, Color.Blue, Color.Maroon, Color.Magenta};
        public int novaBoja = -1;
        public int trenutnaBoja = -1;
        public int potezi = 0;
        private bool winF = false;
        public List<PictureBox> pictureBoxes = new List<PictureBox>();
        public int[] brojBoje = new int[144];

        HighscoreShow form;
        HighscoreEntry formEntry;

        public Form1()
        {
            InitializeComponent();

            DB.DBInit();
            Thread.Sleep(1000);

            pyEngine = Python.CreateEngine();
            pyScope = pyEngine.CreateScope();

            Control[] matches;
            for (int i = 1; i <= 144; i++)
            {
                matches = Controls.Find("pb" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is PictureBox)
                {
                    pictureBoxes.Add((PictureBox)matches[0]);
                }
            }

            ScriptSource ss = pyEngine.CreateScriptSourceFromFile(@"Paint.py");
            ss.Execute(pyScope);
            
            dynamic ext = pyScope.GetVariable("Load");
            ext(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Projektni zadatak iz kolegija\nObjektno programiranje 2017/2018", "About", MessageBoxButtons.OK);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Obojati sve kvadratiće jednakom bojom!\nGornji lijevi kut je početna točka.\nKlikom na jednu od 6 boja, bojaju se svi trentuni\nkvadratići te svi susjedni (bez dijagonala)!", "Help", MessageBoxButtons.OK);
        }
        
        private void btnZuta_Click(object sender, EventArgs e)
        {
            novaBoja = 0;
            potezi++;
            potezi21.Text = potezi.ToString() + " / 21";

            dynamic paint = pyScope.GetVariable("Paintuj");
            paint(this, 1, 1, trenutnaBoja, novaBoja);

            trenutnaBoja = novaBoja;

            winLose(sender, e);

            btnZuta.Enabled = false;
            btnZelena.Enabled = true;
            btnCrvena.Enabled = true;
            btnPlava.Enabled = true;
            btnRuzicasta.Enabled = true;
            btnSmeda.Enabled = true;
        }

        private void btnZelena_Click(object sender, EventArgs e)
        {
            novaBoja = 1;
            potezi++;
            potezi21.Text = potezi.ToString() + " / 21";

            dynamic paint = pyScope.GetVariable("Paintuj");
            paint(this, 1, 1, trenutnaBoja, novaBoja);

            trenutnaBoja = novaBoja;

            winLose(sender, e);

            btnZuta.Enabled = true;
            btnZelena.Enabled = false;
            btnCrvena.Enabled = true;
            btnPlava.Enabled = true;
            btnRuzicasta.Enabled = true;
            btnSmeda.Enabled = true;
        }

        private void btnCrvena_Click(object sender, EventArgs e)
        {
            novaBoja = 2;
            potezi++;
            potezi21.Text = potezi.ToString() + " / 21";

            dynamic paint = pyScope.GetVariable("Paintuj");
            paint(this, 1, 1, trenutnaBoja, novaBoja);

            trenutnaBoja = novaBoja;

            winLose(sender, e);

            btnZuta.Enabled = true;
            btnZelena.Enabled = true;
            btnCrvena.Enabled = false;
            btnPlava.Enabled = true;
            btnRuzicasta.Enabled = true;
            btnSmeda.Enabled = true;
        }

        private void btnPlava_Click(object sender, EventArgs e)
        {
            novaBoja = 3;
            potezi++;
            potezi21.Text = potezi.ToString() + " / 21";

            dynamic paint = pyScope.GetVariable("Paintuj");
            paint(this, 1, 1, trenutnaBoja, novaBoja);

            trenutnaBoja = novaBoja;

            winLose(sender, e);

            btnZuta.Enabled = true;
            btnZelena.Enabled = true;
            btnCrvena.Enabled = true;
            btnPlava.Enabled = false;
            btnRuzicasta.Enabled = true;
            btnSmeda.Enabled = true;
        }

        private void btnRuzicasta_Click(object sender, EventArgs e)
        {
            novaBoja = 5;
            potezi++;
            potezi21.Text = potezi.ToString() + " / 21";

            dynamic paint = pyScope.GetVariable("Paintuj");
            paint(this, 1, 1, trenutnaBoja, novaBoja);

            trenutnaBoja = novaBoja;

            winLose(sender, e);

            btnZuta.Enabled = true;
            btnZelena.Enabled = true;
            btnCrvena.Enabled = true;
            btnPlava.Enabled = true;
            btnRuzicasta.Enabled = false;
            btnSmeda.Enabled = true;
        }
        
        private void btnSmeda_Click(object sender, EventArgs e)
        {
            novaBoja = 4;
            potezi++;
            potezi21.Text = potezi.ToString() + " / 21";

            dynamic paint = pyScope.GetVariable("Paintuj");
            paint(this, 1, 1, trenutnaBoja, novaBoja);

            trenutnaBoja = novaBoja;

            winLose(sender, e);

            btnZuta.Enabled = true;
            btnZelena.Enabled = true;
            btnCrvena.Enabled = true;
            btnPlava.Enabled = true;
            btnRuzicasta.Enabled = true;
            btnSmeda.Enabled = false;
        }

        private void winLose(object sender, EventArgs e)
        {
            if (potezi < 21)
            {
                dynamic win = pyScope.GetVariable("winCondition");
                winF = win(this, trenutnaBoja);
                if (winF)
                {
                    MessageBox.Show("POBJEDA!\n" + potezi.ToString() + " / 21!", "KRAJ", MessageBoxButtons.OK);
                    formEntry = new HighscoreEntry();
                    formEntry.poteziValue = potezi.ToString();
                    formEntry.Show();
                    newToolStripMenuItem_Click(sender, e);
                }
            }
            else if (potezi == 21)
            {
                dynamic win = pyScope.GetVariable("winCondition");
                winF = win(this, trenutnaBoja);
                if (winF)
                {
                    MessageBox.Show("POBJEDA!\n" + potezi.ToString() + " / 21!", "KRAJ", MessageBoxButtons.OK);
                    formEntry = new HighscoreEntry();
                    formEntry.poteziValue = potezi.ToString();
                    formEntry.Show();
                    newToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Ostali ste bez poteza!", "KRAJ", MessageBoxButtons.OK);
                    DialogResult dialogResult = MessageBox.Show("Želite li pokušati ponovno istu ploču?", "UPIT", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dynamic ext = pyScope.GetVariable("LoadStaro");
                        ext(this);
                    }
                    else
                    {
                        newToolStripMenuItem_Click(sender, e);
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptSource ss = pyEngine.CreateScriptSourceFromFile(@"Paint.py");
            ss.Execute(pyScope);

            dynamic ext = pyScope.GetVariable("Load");
            ext(this);
        }
        
        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form == null || form.Enabled == false)
            {
                form = new HighscoreShow();
                form.Show();
            }
            else
            {
                form.Activate();
            }
        }
    }
}