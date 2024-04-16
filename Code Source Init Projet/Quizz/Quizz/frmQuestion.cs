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

    public partial class frmQuestion : Form
    {
        //déclaration des variables globales
        int nombreQuestionTotal;
        int QuestionActuelle = 0;
        int bonneReponseQ;
        int reponseA = 1;
        int reponseB = 2;
        int reponseC = 3;
        int score = 0;
        int bonneReponse = 0;
        int mauvaiseReponse = 0;
        int countTimer0_5s = 0;
        int countTimer1s = 0;
        List<Question> lstquest;
        Joueur joueur;
        public frmQuestion(Joueur joueur)
        {
            InitializeComponent();
            Connection_mySQL bdd = new Connection_mySQL();
            lstquest = bdd.selectQuestion();
            nombreQuestionTotal = lstquest.Count();
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
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
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

        

        private void cmdReponseA_Click(object sender, EventArgs e)
        {
            if (reponseA == bonneReponseQ)
            {
                bonneReponse = 1;
                tmr1s.Stop();
                tmr1s.Interval = 1000;
                countTimer1s = 10;
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
                countTimer1s = 10;
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
                countTimer1s = 10;
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
                if (countTimer0_5s%2 == 0)
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
                else
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
                countTimer0_5s++;
            }
            else
            {
                countTimer0_5s = 0;
                tmr0_5s.Stop();
                tmr1s.Interval = 1;
                countTimer1s = 10;
                tmr1s.Start();
            }
        }

        private void tmr1s_Tick(object sender, EventArgs e)
        {
            if (countTimer1s == 10)
            {
                countTimer1s = 0;
                tmr1s.Stop();
                tmr1s.Interval = 1000;
                if ((bonneReponse == 0) && (mauvaiseReponse == 0))
                {
                    tmr0_5s.Start();
                }
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
                    bonneReponse = 0;
                    prgTemps.Value = 0;
                    prgQuestion.Increment(1);
                    tmr1s.Start();
                }
                else
                {
                    Dispose();
                }
            }
            else
            {
                countTimer1s++;
                prgTemps.Increment(1);
            }            
        }
    }
}
