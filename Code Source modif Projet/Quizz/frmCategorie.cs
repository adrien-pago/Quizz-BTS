using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Quizz;

namespace Quizz
{
    public partial class frmCategorie : Form
    {
        private Joueur joueur;
        private Connection_mySQL connection;
        private List<Question> lstQuestions; // Ajout de la liste de questions

        public frmCategorie(Joueur joueur, Connection_mySQL connection, List<Question> lstQuestions) // Modification du constructeur
        {
            InitializeComponent();
            this.joueur = joueur;
            this.connection = connection;
            this.lstQuestions = lstQuestions; // Initialisation de la liste de questions
        }

        // Événement de chargement du formulaire
        private void frmCategorie_Load(object sender, EventArgs e)
        {

        }
        //Quand on clique sur le libelle 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Choix des fonctions pour la sélection de catégorie
        private void btnClickChoice(object sender, EventArgs e)
        {
            Button boutonClick = sender as Button;

            if (boutonClick != null)
            {
                string categorie = boutonClick.Tag as string;
                cmdChoice(categorie);
            }
        }

        // Méthode pour gérer le choix de la catégorie
        private void cmdChoice(string categorie)
        {
            frmQuestion question = new frmQuestion(joueur, categorie, connection, lstQuestions);
            if (question.NombreQuestionTotal == 0)
            {
                MessageBox.Show("Pas de question pour cette catégorie");
            }
            else
            {
                question.ShowDialog();
                Dispose();
            }
        }
    }
}
