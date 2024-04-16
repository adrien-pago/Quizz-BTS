using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quizz
{
    public partial class frmQuizz : Form
    {
        private Connection_mySQL connection;
        private Joueur joueur;

        public frmQuizz()
        {
            InitializeComponent();
            connection = new Connection_mySQL();
            joueur = new Joueur(); // Initialisation de l'objet joueur
        }

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

        private void cmdDebut_Click(object sender, EventArgs e)
        {
            Connection_mySQL bdd = new Connection_mySQL();

            frmQuestion question = new frmQuestion(joueur);

            question.ShowDialog();

            bdd.UpdateScore(joueur.Pseudo, joueur.Score);
            txtPseudo.Text = "";
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
            cmdDebut.Enabled = false;
        }

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

        private void txtPseudo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstClassement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
