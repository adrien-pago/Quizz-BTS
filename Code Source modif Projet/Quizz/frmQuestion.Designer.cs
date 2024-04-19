

using System;

namespace Quizz
{
    partial class frmQuestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.cmdReponseA = new System.Windows.Forms.Button();
            this.cmdReponseB = new System.Windows.Forms.Button();
            this.cmdReponseC = new System.Windows.Forms.Button();
            this.lblCat = new System.Windows.Forms.Label();
            this.tmr1s = new System.Windows.Forms.Timer(this.components);
            this.tmr0_5s = new System.Windows.Forms.Timer(this.components);
            this.prgTemps = new System.Windows.Forms.ProgressBar();
            this.prgQuestion = new System.Windows.Forms.ProgressBar();
            this.lblTemps = new System.Windows.Forms.Label();
            this.lblBQ = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnExtractQuizz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(100, 42);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(0, 16);
            this.lblQuestion.TabIndex = 0;
            // 
            // cmdReponseA
            // 
            this.cmdReponseA.Location = new System.Drawing.Point(59, 61);
            this.cmdReponseA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdReponseA.Name = "cmdReponseA";
            this.cmdReponseA.Size = new System.Drawing.Size(155, 115);
            this.cmdReponseA.TabIndex = 1;
            this.cmdReponseA.UseVisualStyleBackColor = true;
            this.cmdReponseA.Click += new System.EventHandler(this.cmdReponseA_Click);
            // 
            // cmdReponseB
            // 
            this.cmdReponseB.Location = new System.Drawing.Point(265, 61);
            this.cmdReponseB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdReponseB.Name = "cmdReponseB";
            this.cmdReponseB.Size = new System.Drawing.Size(155, 115);
            this.cmdReponseB.TabIndex = 2;
            this.cmdReponseB.UseVisualStyleBackColor = true;
            this.cmdReponseB.Click += new System.EventHandler(this.cmdReponseB_Click);
            // 
            // cmdReponseC
            // 
            this.cmdReponseC.Location = new System.Drawing.Point(465, 61);
            this.cmdReponseC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdReponseC.Name = "cmdReponseC";
            this.cmdReponseC.Size = new System.Drawing.Size(155, 115);
            this.cmdReponseC.TabIndex = 3;
            this.cmdReponseC.UseVisualStyleBackColor = true;
            this.cmdReponseC.Click += new System.EventHandler(this.cmdReponseC_Click);
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(100, 11);
            this.lblCat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(0, 16);
            this.lblCat.TabIndex = 4;
            // 
            // tmr1s
            // 
            this.tmr1s.Interval = 1000;
            this.tmr1s.Tick += new System.EventHandler(this.tmr1s_Tick);
            // 
            // tmr0_5s
            // 
            this.tmr0_5s.Interval = 500;
            this.tmr0_5s.Tick += new System.EventHandler(this.tmr0_5s_Tick);
            // 
            // prgTemps
            // 
            this.prgTemps.Location = new System.Drawing.Point(67, 261);
            this.prgTemps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prgTemps.Name = "prgTemps";
            this.prgTemps.Size = new System.Drawing.Size(553, 35);
            this.prgTemps.TabIndex = 5;
            // 
            // prgQuestion
            // 
            this.prgQuestion.Location = new System.Drawing.Point(67, 348);
            this.prgQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prgQuestion.Name = "prgQuestion";
            this.prgQuestion.Size = new System.Drawing.Size(553, 35);
            this.prgQuestion.TabIndex = 6;
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Location = new System.Drawing.Point(308, 230);
            this.lblTemps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(98, 16);
            this.lblTemps.TabIndex = 7;
            this.lblTemps.Text = "Barre du temps";
            // 
            // lblBQ
            // 
            this.lblBQ.AutoSize = true;
            this.lblBQ.Location = new System.Drawing.Point(308, 328);
            this.lblBQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBQ.Name = "lblBQ";
            this.lblBQ.Size = new System.Drawing.Size(127, 16);
            this.lblBQ.TabIndex = 8;
            this.lblBQ.Text = "Barre des questions";
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPause.Location = new System.Drawing.Point(44, 8);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(191, 31);
            this.btnPause.TabIndex = 9;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnExtractQuizz
            // 
            this.btnExtractQuizz.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExtractQuizz.Location = new System.Drawing.Point(465, 8);
            this.btnExtractQuizz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExtractQuizz.Name = "btnExtractQuizz";
            this.btnExtractQuizz.Size = new System.Drawing.Size(191, 31);
            this.btnExtractQuizz.TabIndex = 11;
            this.btnExtractQuizz.Text = "Extraire le quizz";
            this.btnExtractQuizz.UseVisualStyleBackColor = false;
            this.btnExtractQuizz.Click += new System.EventHandler(this.btnExtractQuizz_Click);
            // 
            // frmQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Quizz.Properties.Resources.fondpoint__3_1;
            this.ClientSize = new System.Drawing.Size(667, 420);
            this.Controls.Add(this.btnExtractQuizz);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblBQ);
            this.Controls.Add(this.lblTemps);
            this.Controls.Add(this.prgQuestion);
            this.Controls.Add(this.prgTemps);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.cmdReponseC);
            this.Controls.Add(this.cmdReponseB);
            this.Controls.Add(this.cmdReponseA);
            this.Controls.Add(this.lblQuestion);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmQuestion";
            this.Text = "Question";
            this.Load += new System.EventHandler(this.frmQuestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button cmdReponseA;
        private System.Windows.Forms.Button cmdReponseB;
        private System.Windows.Forms.Button cmdReponseC;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Timer tmr1s;
        private System.Windows.Forms.Timer tmr0_5s;
        private System.Windows.Forms.ProgressBar prgTemps;
        private System.Windows.Forms.ProgressBar prgQuestion;
        private System.Windows.Forms.Label lblTemps;
        private System.Windows.Forms.Label lblBQ;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnExtractQuizz;
    }
}