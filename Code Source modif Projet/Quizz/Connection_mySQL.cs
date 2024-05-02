using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Diagnostics;
using Quizz;

namespace Quizz
{
    public class Connection_mySQL // Classe gérant la connexion à la base de données MySQL
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Connection_mySQL() // Constructeur de la classe
        {
            Initialize();
        }

        private void Initialize()// base de donné test
        {
            server = "localhost";
            database = "quizz";
            uid = "root";
            password = "";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()  // Méthode pour ouvrir la connexion à la base de données
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

        public bool CloseConnection() // fermer la connection
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
        //Ajouter un new user à la base de donné
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
        //Vérifier si l'user existe déjà en base de donné avant de l'insérer
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
        //Vérifier le compte avant de lancé le quizz
        public bool ValidateUser(string username, string password)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT PASSWORD_USER FROM Joueurs WHERE Pseudo = @Pseudo", connection);
                cmd.Parameters.AddWithValue("@Pseudo", username);

                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)  // Vérifiers que le résultat n'est pas null sinon on a une erreur quand on vérifie le sel du hash
                    {
                        string storedHash = result.ToString();
                        if (!string.IsNullOrEmpty(storedHash) && BCrypt.Net.BCrypt.Verify(password, storedHash))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucun utilisateur trouvé avec ce pseudo.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }
            return false;
        }


        // récupérer une liste de question
        // récupérer une liste de question
        public List<Question> selectQuestion(string categorie)
        {
            // Ajouter une instruction de débogage pour vérifier la valeur de la catégorie
            Debug.WriteLine("Valeur de la catégorie : " + categorie);
            MessageBox.Show("Valeur de la catégorie : " + categorie);

            List<Question> lstQuestions = new List<Question>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Nom, Question, Reponse_1, Reponse_2, Reponse_3, Bonne FROM question " +
                    "INNER JOIN categories ON idCategories = Fkcategories AND Fkcategories = @categorie ORDER BY idQuestion", connection);

                // Utilisation de paramètres SQL pour la catégorie
                cmd.Parameters.AddWithValue("@categorie", categorie);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Debug.WriteLine("Des données ont été retournées pour la catégorie : " + categorie);
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
                    else
                    {
                        Debug.WriteLine("Aucune donnée n'a été retournée pour la catégorie : " + categorie);
                    }
                }

                CloseConnection();
            }
            else
            {
                Debug.WriteLine("La connexion à la base de données n'a pas pu être ouverte.");
            }

            return lstQuestions;
        }



        // Mettre à jour le nouveau score en base de données ou bien modifier si le joueur a déjà joué dans la catégorie
        public void UpdateScore(Score score)
        {
            if (OpenConnection())
            {
                // Vérifier si le joueur a déjà joué dans cette catégorie
                MySqlCommand selectCmd = new MySqlCommand("SELECT COUNT(*) FROM score WHERE Pseudo = @Pseudo AND Categorie = @Categorie", connection);
                selectCmd.Parameters.AddWithValue("@Pseudo", score.Pseudo);
                selectCmd.Parameters.AddWithValue("@Categorie", score.Categorie);
                int count = Convert.ToInt32(selectCmd.ExecuteScalar());

                if (count > 0)
                {
                    // Le joueur a déjà joué dans cette catégorie, donc effectuer une mise à jour
                    MySqlCommand updateCmd = new MySqlCommand("UPDATE score SET Score = @Score, Time = @Time WHERE Pseudo = @Pseudo AND Categorie = @Categorie", connection);
                    updateCmd.Parameters.AddWithValue("@Score", score.Value);
                    updateCmd.Parameters.AddWithValue("@Pseudo", score.Pseudo);
                    updateCmd.Parameters.AddWithValue("@Categorie", score.Categorie);
                    updateCmd.Parameters.AddWithValue("@Time", score.Time.ToString("c")); // Convertir TimeSpan en chaîne de caractères au format HH:mm:ss
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    // Le joueur n'a jamais joué dans cette catégorie, donc insérer une nouvelle ligne
                    MySqlCommand insertCmd = new MySqlCommand("INSERT INTO score (Pseudo, Score, Categorie, Time) VALUES (@Pseudo, @Score, @Categorie, @Time)", connection);
                    insertCmd.Parameters.AddWithValue("@Pseudo", score.Pseudo);
                    insertCmd.Parameters.AddWithValue("@Score", score.Value);
                    insertCmd.Parameters.AddWithValue("@Categorie", score.Categorie);
                    insertCmd.Parameters.AddWithValue("@Time", score.Time.ToString("c")); // Convertir TimeSpan en chaîne de caractères au format HH:mm:ss
                    insertCmd.ExecuteNonQuery();
                }

                CloseConnection();
            }
        }

        // Récupérer liste des joueurs en fonction du score du time et de la catégorie
        public Dictionary<int, List<Score>> SelectScoresByCategory()
        {
            Dictionary<int, List<Score>> scoresByCategory = new Dictionary<int, List<Score>>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Pseudo, Score, Time, Categorie FROM score  ORDER BY Score DESC", connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Score score = new Score();
                        score.Pseudo = reader["Pseudo"].ToString();
                        score.Value = Convert.ToInt32(reader["Score"]);
                        score.Time = TimeSpan.Parse(reader["Time"].ToString());
                        score.Categorie = Convert.ToInt32(reader["Categorie"]);
                        if (!scoresByCategory.ContainsKey(score.Categorie))
                        {
                            scoresByCategory[score.Categorie] = new List<Score>();
                        }
                        scoresByCategory[score.Categorie].Add(score);
                    }
                }
                CloseConnection();
            }
            return scoresByCategory;
        }
    }
}
