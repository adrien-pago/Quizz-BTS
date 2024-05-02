using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Quizz
{
    public partial class frmQuestion : Form
    {
        //déclaration des variables globales
        private int nombreQuestionTotal;
        private int QuestionActuelle = 0;
        private int bonneReponseQ;
        private int reponseA = 1;
        private int reponseB = 2;
        private int reponseC = 3;
        private int score = 0;
        private int bonneReponse = 0;
        private int mauvaiseReponse = 0;
        private int countTimer0_5s = 0;
        private int countTimer1s = 0;
        private List<Question> lstquest;
        private Joueur joueur;
        private int Categorie;
        private Connection_mySQL connection;
        private bool isPaused;

        public int NombreQuestionTotal
        {
            get { return nombreQuestionTotal; }
        }

        // Constructeur de la classe
        public frmQuestion(Joueur joueur, string categorie, Connection_mySQL connection, List<Question> lstquest)
        {
            InitializeComponent();
            this.connection = connection; // Utiliser la connexion passée
            this.lstquest = lstquest; // Utiliser les questions passées
            if (lstquest != null)
            {
                nombreQuestionTotal = lstquest.Count;
            }
            else
            {
                // Gérer le cas où lstquest est null
                nombreQuestionTotal = 0;
            }
            prgTemps.Visible = true;
            prgTemps.Minimum = 0;
            prgTemps.Maximum = 10;
            prgTemps.Value = 0;
            prgTemps.Step = 1;
            prgQuestion.Visible = true;
            prgQuestion.Minimum = 0;
            prgQuestion.Maximum = nombreQuestionTotal;
            prgQuestion.Value = 0;
            prgQuestion.Step = 1;
            this.joueur = joueur;
            this.connection = connection;

            // Ajout du gestionnaire d'événements pour l'événement FormClosed
            this.FormClosed += new FormClosedEventHandler(frmQuestion_FormClosed);
        }


        // Événement de chargement du formulaire
        private void frmQuestion_Load(object sender, EventArgs e)
        {
            if (lstquest != null && lstquest.Count > 0)
            {
                // Instanciation de l'objet Score avec les valeurs initiales
                Quizz.Score scoreObject = new Quizz.Score();
                scoreObject.Pseudo = "nom_du_joueur";
                scoreObject.Value = 0;
                scoreObject.Time = TimeSpan.Zero;
                scoreObject.Categorie = 0;

                // Affichage de la première question
                Question quest = lstquest[0];
                lblCat.Text = quest.Categories;
                lblQuestion.Text = quest.NomQuestion;
                cmdReponseA.Text = quest.ReponseA;
                cmdReponseB.Text = quest.ReponseB;
                cmdReponseC.Text = quest.ReponseC;
                bonneReponseQ = quest.BonneReponse;
                QuestionActuelle = 1;
                prgQuestion.Increment(1);
                tmr1s.Start();
            }
            else
            {
                MessageBox.Show("Aucune question n'a été chargée.");
                this.Close(); // Fermer le formulaire si aucune question n'a été chargée
            }
        }


        // Méthodes pour gérer les clics sur les boutons de réponse
        private void cmdReponseA_Click(object sender, EventArgs e)
        {
            if (reponseA == bonneReponseQ)
            {
                bonneReponse = 1;
                tmr1s.Stop();
                tmr1s.Interval = 1000;
                countTimer1s = 11;
                tmr1s.Start();
            }
            else
            {
                tmr1s.Stop();
                mauvaiseReponse = 1;
                tmr0_5s.Start();
            }
        }

        private void cmdReponseB_Click(object sender, EventArgs e)
        {
            if (reponseB == bonneReponseQ)
            {
                bonneReponse = 1;
                tmr1s.Stop();
                tmr1s.Interval = 1000;
                countTimer1s = 11;
                tmr1s.Start();
            }
            else
            {
                tmr1s.Stop();
                mauvaiseReponse = 1;
                tmr0_5s.Start();
            }
        }

        private void cmdReponseC_Click(object sender, EventArgs e)
        {
            if (reponseC == bonneReponseQ)
            {
                bonneReponse = 1;
                tmr1s.Stop();
                tmr1s.Interval = 1000;
                countTimer1s = 11;
                tmr1s.Start();
            }
            else
            {
                tmr1s.Stop();
                mauvaiseReponse = 1;
                tmr0_5s.Start();
            }
        }

        private void tmr0_5s_Tick(object sender, EventArgs e)
        {
            if (countTimer0_5s < 6)
            {
                if (countTimer0_5s % 2 == 0)
                {
                    switch (bonneReponseQ)
                    {
                        case 1:
                            cmdReponseA.Enabled = false;
                            break;
                        case 2:
                            cmdReponseB.Enabled = false;
                            break;
                        case 3:
                            cmdReponseC.Enabled = false;
                            break;
                    }
                }
                else
                {
                    switch (bonneReponseQ)
                    {
                        case 1:
                            cmdReponseA.Enabled = true;
                            break;
                        case 2:
                            cmdReponseB.Enabled = true;
                            break;
                        case 3:
                            cmdReponseC.Enabled = true;
                            break;
                    }
                }
                countTimer0_5s++;
            }
            else
            {
                countTimer0_5s = 0;
                tmr0_5s.Stop();
                tmr1s.Interval = 1000;
                countTimer1s = 11;
                tmr1s.Start();
            }
        }

        private void tmr1s_Tick(object sender, EventArgs e)
        {
            if (countTimer1s == 10)
            {
                if ((bonneReponse == 0) && (mauvaiseReponse == 0))
                {
                    tmr1s.Stop();
                    tmr0_5s.Start();
                }
            }
            else if (countTimer1s == 11)
            {
                countTimer1s = 0;
                tmr1s.Stop();
                tmr1s.Interval = 1000;

                if (bonneReponse == 1)
                {
                    score++;
                    joueur.Score = score;
                }
                if (QuestionActuelle < nombreQuestionTotal)
                {
                    mauvaiseReponse = 0;
                    cmdReponseA.Enabled = true;
                    cmdReponseB.Enabled = true;
                    cmdReponseC.Enabled = true;
                    Question quest = lstquest[QuestionActuelle];
                    lblCat.Text = quest.Categories;
                    lblQuestion.Text = quest.NomQuestion;
                    cmdReponseA.Text = quest.ReponseA;
                    cmdReponseB.Text = quest.ReponseB;
                    cmdReponseC.Text = quest.ReponseC;
                    bonneReponseQ = quest.BonneReponse;
                    QuestionActuelle++;
                    prgQuestion.Increment(1);
                    tmr1s.Start();
                }
                else
                {
                    // S'il n'y a plus de questions, arrêtez le jeu et affichez le score
                    tmr1s.Stop();
                    // Affichez le score
                    MessageBox.Show("Votre score est de : " + score);
                    // Enregistrez le score dans la base de données
                    if (connection != null)
                    {
                        // Assurez-vous que la connexion est ouverte
                        if (connection.OpenConnection())
                        {
                            // Créez un objet Score avec les détails
                            Quizz.Score scoreObject = new Quizz.Score();
                            scoreObject.Pseudo = joueur.Pseudo;
                            scoreObject.Value = score;
                            scoreObject.Time = DateTime.Now.TimeOfDay;
                            scoreObject.Categorie = Categorie;

                            // Appelez la méthode d'insertion dans la classe de connexion pour enregistrer le score
                            connection.UpdateScore(scoreObject);

                            // Fermez la connexion après avoir enregistré le score
                            connection.CloseConnection();
                        }
                    }
                    // Fermez le formulaire
                    this.Close();
                }
            }
            else
            {
                countTimer1s++;
                prgTemps.Increment(1);
            }
        }

        // Événement de fermeture du formulaire
        private void frmQuestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Arrêtez tous les timers pour libérer les ressources
            tmr0_5s.Stop();
            tmr1s.Stop();
        }

        private void cmdPause_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                // Reprendre le jeu
                tmr0_5s.Start();
                tmr1s.Start();
                isPaused = false;
                cmdPause.Text = "Pause";
            }
            else
            {
                // Mettre en pause le jeu
                tmr0_5s.Stop();
                tmr1s.Stop();
                isPaused = true;
                cmdPause.Text = "Reprendre";
            }
        }
    }
}
