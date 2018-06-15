using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace ColorIt
{
    public static class DB
    {
        public static void DBInit()
        {
            string createHighQuery = @"CREATE TABLE IF NOT EXISTS Highscore (
                          ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                          Potezi TEXT NOT NULL,
                          Name TEXT NOT NULL
                          )";

            string dummyInsert = "INSERT INTO Highscore (Name, Potezi) VALUES ('Borna', '19');" +
                                 "INSERT INTO Highscore (Name, Potezi) VALUES ('David', '21');" +
                                 "INSERT INTO Highscore (Name, Potezi) VALUES ('Ivo', '15')";

            string path = Path.Combine(Application.StartupPath, "highscoreDB.db");

            if (!File.Exists(path))
            {
                SQLiteConnection conn;
                SQLiteConnection.CreateFile(path);
                conn = new SQLiteConnection("Data Source=highscoreDB.db;Version=3;Foreign Keys=true;");

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["db"].ConnectionString = "Data Source=highscoreDB.db;Version=3;Foreign Keys=true;";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(createHighQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = dummyInsert;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void DBUnos(string Ime, string Potezi)
        {
            string insertScore = "INSERT INTO Highscore (Name, Potezi) VALUES ('" + Ime + "','" + Potezi + "')";
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(insertScore, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
