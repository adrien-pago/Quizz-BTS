using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quizz
{
    public partial class frmQuizz : Form
    {
        private Connection_mySQL connection;
        private Joueur joueur;

        //à L'init de la page
        public frmQuizz()
        {
            InitializeComponent();
            connection = new Connection_mySQL();
            joueur = new Joueur(); // Initialisation de l'objet joueur
            LoadScoresByCategory();// Affiche le classement avec la fonction LoadScoresByCategory

        }
        // Créer un new compte user
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

        //Afficher scoore dans les différent tableau en fonction des catégorie
        private void LoadScoresByCategory()
        {
            Dictionary<string, List<Joueur>> scoresByCategory = connection.SelectScoresByCategory();

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
        // Lancer le quizz
        private void jouer_Click(object sender, EventArgs e)
        {
            string username = txtPseudo.Text.Trim();
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (connection.ValidateUser(username, password))
                {
                    frmCategorie categorie = new frmCategorie(joueur);
                    categorie.ShowDialog();

                    frmQuestion question = new frmQuestion(joueur, joueur.Categorie.ToString());
                    question.FormClosed += (s, args) => // Événement de fermeture du formulaire frmQuestion
                    {
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


