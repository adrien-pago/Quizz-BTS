using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Quizz;

namespace Quizz
{
    public partial class frmQuizz : Form
    {
        private Connection_mySQL connection;
        private Joueur joueur;
        private Score Score;
        private List<Question> lstQuestions; // Ajout de la liste de questions

        // Initialisation de la page
        public frmQuizz()
        {
            InitializeComponent();
            connection = new Connection_mySQL();
            joueur = new Joueur(); // Initialisation de l'objet joueur
            LoadScoresByCategory(); // Affiche le classement avec la fonction LoadScoresByCategory
        }

        // Créer un nouveau compte utilisateur
        private void cmdAjouterLePseudo_Click(object sender, EventArgs e)
        {
            string username = txtPseudo.Text.Trim();
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (!connection.UserExists(username))
                {
                    bool isAdded = connection.AddUser(username, password);
                    if (isAdded)
                    {
                        MessageBox.Show("Utilisateur ajouté avec succès !");
                        txtPseudo.Clear();
                        txtPassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de l'utilisateur.");
                    }
                }
                else
                {
                    MessageBox.Show("Un utilisateur avec ce pseudo existe déjà.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }

        // Afficher les scores dans les différents tableaux en fonction des catégories
        private void LoadScoresByCategory()
        {
            Dictionary<int, List<Joueur>> scoresByCategory = connection.SelectScoresByCategory();

            foreach (KeyValuePair<string, List<Joueur>> entry in scoresByCategory)
            {
                string category = entry.Key;
                List<Joueur> scores = entry.Value;

                switch (category)
                {
                    case "1":
                        Mathématique.Items.Clear();
                        foreach (Joueur joueur in scores)
                        {
                            Mathématique.Items.Add(joueur.ToString());
                        }
                        break;
                    case "3":
                        Culture.Items.Clear();
                        foreach (Joueur joueur in scores)
                        {
                            Culture.Items.Add(joueur.ToString());
                        }
                        break;
                    case "2":
                        Programmation.Items.Clear();
                        foreach (Joueur joueur in scores)
                        {
                            Programmation.Items.Add(joueur.ToString());
                        }
                        break;
                    case "4": // Afficher dans le tableau de toutes les catégories
                        Classement.Items.Clear();
                        foreach (Joueur joueur in scores)
                        {
                            Classement.Items.Add(joueur.ToString());
                        }
                        break;
                }
            }
        }

        // Lancer le quiz
        private void jouer_Click(object sender, EventArgs e)
        {
            string username = txtPseudo.Text.Trim();
            string password = txtPassword.Text;
            string categorie = ""; // Déclarer la variable categorie
            if (Mathématique.SelectedItem != null)
                    {
                categorie = "1";
            }
            else if (Programmation.SelectedItem != null)
                    {
                categorie = "2";
            }
            else if (Culture.SelectedItem != null)
                    {
                categorie = "3";
            }

            Score = new Score(); // Créer une nouvelle instance de Score
            Score.Pseudo = username;
            Score.Categorie = Convert.ToInt32(categorie); // Convertir la catégorie en entier
            Score.Time = TimeSpan.Zero; // Initialiser le temps à zéro

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // Assurez-vous que le pseudo est défini avant de continuer
                joueur.Pseudo = username;

                if (connection.ValidateUser(username, password))
                {
                    // Passer l'instance de Connection_mySQL et la liste de questions au formulaire frmQuestion
                    frmQuestion question = new frmQuestion(joueur, categorie, connection, lstQuestions);
                    question.FormClosed += (s, args) => // Événement de fermeture du formulaire frmQuestion
                    {
                        // Mise à jour du score dans la base de données après la fermeture du formulaire frmQuestion
                        string pseudo = Score.Pseudo;
                        int score = Score.Value;
                        int categorieId = Score.Categorie;
                        TimeSpan time = Score.Time;

                        connection.UpdateScore(Score); // Passer l'objet Score directement
                        LoadScoresByCategory(); // Rafraîchir les scores après la fermeture du formulaire frmQuestion
                    };
                    question.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Le pseudo ou le mot de passe est incorrect.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir le pseudo et le mot de passe.");
            }
        }
    }
}
