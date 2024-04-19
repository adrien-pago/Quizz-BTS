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
            LoadClassement();// Affiche le classement avec la fonction LoadClassement

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
        //Lancer le quizz en vérifiant le compte avant
        private void cmdDebut_Click(object sender, EventArgs e)
        {
            string username = txtPseudo.Text.Trim();
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (connection.ValidateUser(username, password))
                {
                    frmQuestion question = new frmQuestion(joueur);
                    question.ShowDialog();

                    Connection_mySQL bdd = new Connection_mySQL();
                    bdd.UpdateScore(joueur.Pseudo, joueur.Score);
                    List<Joueur> lstJoueur = bdd.selectJoueur();

                    if (lstJoueur.Count > 0)
                    {
                        Classement.Items.Clear();
                        foreach (Joueur j in lstJoueur)
                        {
                            Classement.Items.Add(j.ToString());
                        }
                    }
                    lstJoueur.Clear();
                    cmdAjouterLePseudo.Enabled = true;
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

        //Charger le quizz et mettre à jour liste des joueurs
        private void frmQuizz_Load(object sender, EventArgs e)
        {
            List<Joueur> lstJoueur = connection.selectJoueur();
            if (lstJoueur.Count > 0)
            {
                Classement.Items.Clear();
                foreach (Joueur j in lstJoueur)
                {
                    Classement.Items.Add(j.ToString());
                }
            }
        }

        //Afficher le scoore des anciennes parties
        private void LoadClassement()
        {
            Classement.Items.Clear();  //nom de la ListBox 

            List<Joueur> lstJoueur = connection.selectJoueur();
            if (lstJoueur.Count > 0)
            {
                foreach (Joueur j in lstJoueur)
                {
                    string displayText = $"{j.Pseudo} - Score: {j.Score}";
                    Classement.Items.Add(displayText);
                }
            }
            else
            {
                Classement.Items.Add("Aucun joueur trouvé.");
            }
        }
    }
}
