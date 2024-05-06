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
        private Score Score = new Score(); // Initialiser le champ Score avec une instance de Score
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
        public void LoadScoresByCategory()
        {
            Dictionary<int, List<Score>> scoresByCategory = connection.SelectScoresByCategory();

            foreach (KeyValuePair<int, List<Score>> entry in scoresByCategory)
            {
                int category = entry.Key;
                List<Score> scores = entry.Value;

                switch (category)
                {
                    case 1:
                        Mathématique.Items.Clear();
                        foreach (Score score in scores)
                        {
                            Mathématique.Items.Add(score.ToString());
                        }
                        break;
                    case 3:
                        Culture.Items.Clear();
                        foreach (Score score in scores)
                        {
                            Culture.Items.Add(score.ToString());
                        }
                        break;
                    case 2:
                        Programmation.Items.Clear();
                        foreach (Score score in scores)
                        {
                            Programmation.Items.Add(score.ToString());
                        }
                        break;
                    case 4: // Afficher dans le tableau de toutes les catégories
                        Classement.Items.Clear();
                        foreach (Score score in scores)
                        {
                            Classement.Items.Add(score.ToString());
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

            // Lance la fenêtre de sélection de catégorie
            frmCategorie categorieForm = new frmCategorie(joueur, connection, lstQuestions);
            DialogResult result = categorieForm.ShowDialog();

            // Si l'utilisateur a sélectionné une catégorie et a cliqué sur "OK"
            if (result == DialogResult.OK && !string.IsNullOrEmpty(categorieForm.SelectedCategorie))
            {
                string categorie = categorieForm.SelectedCategorie; // Récupérer la catégorie sélectionnée

                // Chargez la liste de questions
                lstQuestions = connection.selectQuestion(categorieForm.SelectedCategorie);

                // Si la liste de questions est chargée avec succès
                if (lstQuestions != null && lstQuestions.Count > 0)
                {
                    // Passez la liste de questions à frmQuestion
                    frmQuestion question = new frmQuestion(joueur, categorieForm.SelectedCategorie, connection, lstQuestions);
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
                    MessageBox.Show("Aucune question trouvée pour cette catégorie.");
                }
            }
        }
    }
}
