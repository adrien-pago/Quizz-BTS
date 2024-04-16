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
    public partial class frmQuizz : Form
    {

        Joueur joueur; 
        public frmQuizz()
        {
            InitializeComponent();
            cmdDebut.Enabled = false;
            
        }

        private void cmdAjouterLePseudo_Click(object sender, EventArgs e)
        {
            object resultat;
            Connection_mySQL bdd = new Connection_mySQL();
            if (txtPseudo.Text != "")
            {
                resultat = bdd.TestPseudo(txtPseudo.Text);
                if (resultat == null)
                {
                    joueur = new Joueur();
                    joueur.Pseudo = txtPseudo.Text;
                    bdd.InsertJoueur(txtPseudo.Text, 0);
                    cmdAjouterLePseudo.Enabled = false;
                    cmdDebut.Enabled = true;
                }
                else
                {
                    string message = "le pseudo " + txtPseudo.Text + " n'est plus disponible, merci de sélectionner un autre pseudo";
                    string caption = "Pseudo invalide";
                    MessageBoxButtons bouton = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, bouton, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = "merci de mettre un pseudo";
                string caption = "Pseudo vide";
                MessageBoxButtons bouton = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, bouton, MessageBoxIcon.Error);
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
                lstClassement.Items.Clear();
                foreach (Joueur j in lstJoueur)
                {
                    lstClassement.Items.Add(j.ToString());
                }
            }
            lstJoueur.Clear();
            cmdAjouterLePseudo.Enabled = true;
            cmdDebut.Enabled = false;
        }

        private void frmQuizz_Load(object sender, EventArgs e)
        {
            Connection_mySQL bdd = new Connection_mySQL();
            List<Joueur> lstJoueur =  bdd.selectJoueur();

            if (lstJoueur.Count > 0)
            {
                lstClassement.Items.Clear();
                foreach (Joueur j in lstJoueur)
                {
                    lstClassement.Items.Add(j.ToString());
                }
            }
        }
    }
}
