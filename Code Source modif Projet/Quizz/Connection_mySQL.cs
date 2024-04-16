using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace Quizz
{
    class Connection_mySQL
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Connection_mySQL()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "Quizz";
            uid = "root";
            password = "";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool AddUser(string nomJoueur, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Joueurs (Pseudo, PASSWORD_USER) VALUES (@Pseudo, @Password)";
                cmd.Parameters.AddWithValue("@Pseudo", nomJoueur);
                cmd.Parameters.AddWithValue("@Password", passwordHash);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                finally
                {
                    CloseConnection();
                }
            }
            return false;
        }

        public bool UserExists(string nomJoueur)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Joueurs WHERE Pseudo = @Pseudo";
                cmd.Parameters.AddWithValue("@Pseudo", nomJoueur);

                int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                CloseConnection();
                return userCount > 0;
            }
            return false;
        }

        public List<Question> selectQuestion()
        {
            List<Question> lstQuestions = new List<Question>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Nom, Question, Reponse_1, Reponse_2, Reponse_3, Bonne FROM question INNER JOIN categories ON idCategories = Fkcategories ORDER BY idQuestion", connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Question quest = new Question();
                        quest.Categories = reader["Nom"].ToString();
                        quest.NomQuestion = reader["Question"].ToString();
                        quest.ReponseA = reader["Reponse_1"].ToString();
                        quest.ReponseB = reader["Reponse_2"].ToString();
                        quest.ReponseC = reader["Reponse_3"].ToString();
                        quest.BonneReponse = Convert.ToInt32(reader["Bonne"]);
                        lstQuestions.Add(quest);
                    }
                }

                CloseConnection();
            }

            return lstQuestions;
        }

        public void UpdateScore(string pseudo, int score)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE Joueurs SET Score = @Score WHERE Pseudo = @Pseudo", connection);
                cmd.Parameters.AddWithValue("@Score", score);
                cmd.Parameters.AddWithValue("@Pseudo", pseudo);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public List<Joueur> selectJoueur()
        {
            List<Joueur> lstJoueur = new List<Joueur>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Pseudo, Score FROM Joueurs ORDER BY Score DESC", connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Joueur joueur = new Joueur();
                        joueur.Pseudo = reader["Pseudo"].ToString();
                        joueur.Score = Convert.ToInt32(reader["Score"]);
                        lstJoueur.Add(joueur);
                    }
                }
                CloseConnection();
            }
            return lstJoueur;
        }
    }
}
