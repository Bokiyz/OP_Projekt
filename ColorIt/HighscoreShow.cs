using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace ColorIt
{
    public partial class HighscoreShow : Form
    {
        ScriptEngine pyEngine = null;
        ScriptScope pyScope = null;
        public string name;
        public string potezi;
        int i = 0;

        public HighscoreShow()
        {
            InitializeComponent();

            pyEngine = Python.CreateEngine();
            pyScope = pyEngine.CreateScope();

            ScriptSource ss = pyEngine.CreateScriptSourceFromFile(@"Paint.py");
            ss.Execute(pyScope);
        }

        private void HighscoreShow_Load(object sender, EventArgs e)
        {
            string selectScore = "SELECT * FROM Highscore ORDER BY Potezi ASC LIMIT 3";
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(selectScore, conn))
                {
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        potezi = reader["Potezi"] as string;
                        name = reader["Name"] as string;

                        dynamic hiscore = pyScope.GetVariable("ispisHighscore");
                        hiscore(this, i);

                        i++;
                        if (i > 2) i = 0;
                    }
                }
                conn.Close();
            }
        }

        private void HighscoreShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = false;
        }
    }
}
