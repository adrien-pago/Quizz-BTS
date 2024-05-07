using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizz
{
    public partial class frmCategorie : Form
    {

        Joueur joueur;


        public frmCategorie(Joueur joueur)
        {
            InitializeComponent();
            this.joueur = joueur;
        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Choix des fonctions pour la séléction de catégorie
        private void btnClickChoice(object sender, EventArgs e)
        {
            Button boutonClick = sender as Button;

            if (boutonClick != null)
            {
                string categorie = boutonClick.Tag as string;
                cmdChoice(categorie);
            }     
        }
        private void cmdChoice(string categorie)
        {
            frmQuestion question = new frmQuestion(joueur, categorie);
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
