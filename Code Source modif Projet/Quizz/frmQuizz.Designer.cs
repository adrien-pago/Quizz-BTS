using System;
using System.Windows.Forms;

namespace Quizz
{
    partial class frmQuizz
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtPseudo;
        private TextBox txtPassword;
        private Button cmdAjouterLePseudo;
        private Button cmdSignUp;
        private ListBox Classement;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPseudo = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmdAjouterLePseudo = new System.Windows.Forms.Button();
            this.cmdSignUp = new System.Windows.Forms.Button();
            this.Classement = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPseudo
            // 
            this.txtPseudo.Location = new System.Drawing.Point(523, 46);
            this.txtPseudo.Name = "txtPseudo";
            this.txtPseudo.Size = new System.Drawing.Size(100, 22);
            this.txtPseudo.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(523, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cmdAjouterLePseudo
            // 
            this.cmdAjouterLePseudo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmdAjouterLePseudo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAjouterLePseudo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdAjouterLePseudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAjouterLePseudo.Location = new System.Drawing.Point(415, 188);
            this.cmdAjouterLePseudo.Name = "cmdAjouterLePseudo";
            this.cmdAjouterLePseudo.Size = new System.Drawing.Size(208, 102);
            this.cmdAjouterLePseudo.TabIndex = 2;
            this.cmdAjouterLePseudo.Text = "Jouer";
            this.cmdAjouterLePseudo.UseVisualStyleBackColor = false;
            this.cmdAjouterLePseudo.Click += new System.EventHandler(this.cmdDebut_Click);
            // 
            // cmdSignUp
            // 
            this.cmdSignUp.BackColor = System.Drawing.Color.Lime;
            this.cmdSignUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdSignUp.Location = new System.Drawing.Point(415, 135);
            this.cmdSignUp.Name = "cmdSignUp";
            this.cmdSignUp.Size = new System.Drawing.Size(208, 35);
            this.cmdSignUp.TabIndex = 3;
            this.cmdSignUp.Text = "Créer Compte";
            this.cmdSignUp.UseVisualStyleBackColor = false;
            this.cmdSignUp.Click += new System.EventHandler(this.cmdAjouterLePseudo_Click);
            // 
            // Classement
            // 
            this.Classement.BackColor = System.Drawing.Color.Gainsboro;
            this.Classement.ItemHeight = 16;
            this.Classement.Location = new System.Drawing.Point(38, 52);
            this.Classement.Name = "Classement";
            this.Classement.Size = new System.Drawing.Size(297, 228);
            this.Classement.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(412, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "PSEUDO";
            this.label1.Click += new System.EventHandler(this.cmdAjouterLePseudo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "PASSWORD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(34, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Classement des meilleures parties";
            // 
            // frmQuizz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 329);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPseudo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cmdAjouterLePseudo);
            this.Controls.Add(this.cmdSignUp);
            this.Controls.Add(this.Classement);
            this.Name = "frmQuizz";
            this.Text = "Quizz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private Label label3;
    }
}

