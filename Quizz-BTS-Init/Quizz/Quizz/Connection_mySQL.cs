using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Quizz
{
    class Connection_mySQL
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Connection_mySQL()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "Quizz";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

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
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
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

        //Insert statement
        public void InsertJoueur(string nomJoueur, int resultat)
        {
            connection.Open();
            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO Joueurs (Pseudo, Score) VALUES (@Pseudo, @Score)";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@Pseudo", nomJoueur);
            cmd.Parameters.AddWithValue("@Score", resultat);

            // Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public object TestPseudo(string nomJoueur)
        {
            connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT Pseudo FROM joueurs WHERE Pseudo LIKE '" + nomJoueur + "'";

            object resultat = cmd.ExecuteScalar();

            connection.Close();

            return resultat;

            
        }
        public void UpdateScore(string nomJoueur,int resultat)
        {
            connection.Open();
            
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE joueurs SET Score = " + resultat + " WHERE Pseudo LIKE '" + nomJoueur + "'";

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public int countCategorie()
        {
            int nombre;
            object resultat;

            connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT COUNT(Nom) FROM categories";

            resultat = cmd.ExecuteScalar();

            if (resultat!=null)
            {
                nombre = Convert.ToInt32(resultat);
            }
            else
            {
                 nombre = 0;
            }

            return nombre;


        }

        public List<Joueur> selectJoueur()
        {
            List<Joueur> lstJoueur = new List<Joueur>();

            connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT Pseudo, Score FROM joueurs ORDER BY score DESC LIMIT 16";

            MySqlDataReader j = cmd.ExecuteReader();

            while (j.Read())
            {
                Joueur joueurs = new Joueur();
                joueurs.Pseudo = Convert.ToString(j[0]);
                joueurs.Score = Convert.ToInt32(j[1]);
                lstJoueur.Add(joueurs);
            }
            j.Close();
            connection.Close();
            return lstJoueur;
        }

        public List<Question> selectQuestion()
        {
            List<Question> lstQuestions = new List<Question>();
            connection.Open();
            
            
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT Nom,Question,Reponse_1,Reponse_2,Reponse_3,Bonne FROM question INNER JOIN categories ON idCategories = Fkcategories ORDER BY idQuestion";

            MySqlDataReader question = cmd.ExecuteReader();
            
            while (question.Read())
            {
                Question quest = new Question();
                quest.Categories = Convert.ToString(question[0]);
                quest.NomQuestion = Convert.ToString(question[1]);
                quest.ReponseA = Convert.ToString(question[2]);
                quest.ReponseB = Convert.ToString(question[3]);
                quest.ReponseC = Convert.ToString(question[4]);
                quest.BonneReponse = Convert.ToInt32(question[5]);
                lstQuestions.Add(quest);
            }
            question.Close();
            connection.Close();
            return lstQuestions;
        }
    }
}
