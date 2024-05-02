using System;
using System.Windows.Forms;

namespace Quizz
{
    partial class frmQuizz
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtPseudo;
        private TextBox txtPassword;
        private Button Jouer;
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
            this.Jouer = new System.Windows.Forms.Button();
            this.cmdSignUp = new System.Windows.Forms.Button();
            this.Classement = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Mathématique = new System.Windows.Forms.ListBox();
            this.Culture = new System.Windows.Forms.ListBox();
            this.Programmation = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPseudo
            // 
            this.txtPseudo.Location = new System.Drawing.Point(649, 404);
            this.txtPseudo.Name = "txtPseudo";
            this.txtPseudo.Size = new System.Drawing.Size(131, 22);
            this.txtPseudo.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(649, 437);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(131, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // Jouer
            // 
            this.Jouer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Jouer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Jouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jouer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Jouer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Jouer.Location = new System.Drawing.Point(538, 519);
            this.Jouer.Name = "Jouer";
            this.Jouer.Size = new System.Drawing.Size(242, 122);
            this.Jouer.TabIndex = 2;
            this.Jouer.Text = "Jouer";
            this.Jouer.UseVisualStyleBackColor = false;
            this.Jouer.Click += new System.EventHandler(this.jouer_Click);
            // 
            // cmdSignUp
            // 
            this.cmdSignUp.BackColor = System.Drawing.Color.Lime;
            this.cmdSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSignUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdSignUp.Location = new System.Drawing.Point(538, 478);
            this.cmdSignUp.Name = "cmdSignUp";
            this.cmdSignUp.Size = new System.Drawing.Size(242, 35);
            this.cmdSignUp.TabIndex = 3;
            this.cmdSignUp.Text = "Créer Compte";
            this.cmdSignUp.UseVisualStyleBackColor = false;
            this.cmdSignUp.Click += new System.EventHandler(this.cmdAjouterLePseudo_Click);
            // 
            // Classement
            // 
            this.Classement.BackColor = System.Drawing.Color.Gainsboro;
            this.Classement.ColumnWidth = 3;
            this.Classement.ItemHeight = 16;
            this.Classement.Location = new System.Drawing.Point(12, 99);
            this.Classement.MultiColumn = true;
            this.Classement.Name = "Classement";
            this.Classement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Classement.Size = new System.Drawing.Size(276, 260);
            this.Classement.TabIndex = 1;
            this.Classement.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 410);
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
            this.label2.Location = new System.Drawing.Point(535, 443);
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
            this.label3.Location = new System.Drawing.Point(414, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Classement des meilleures parties par catégories\r\n";
            // 
            // Mathématique
            // 
            this.Mathématique.BackColor = System.Drawing.Color.Gainsboro;
            this.Mathématique.ColumnWidth = 3;
            this.Mathématique.ItemHeight = 16;
            this.Mathématique.Location = new System.Drawing.Point(332, 99);
            this.Mathématique.MultiColumn = true;
            this.Mathématique.Name = "Mathématique";
            this.Mathématique.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Mathématique.Size = new System.Drawing.Size(276, 260);
            this.Mathématique.TabIndex = 8;
            this.Mathématique.TabStop = false;
            // 
            // Culture
            // 
            this.Culture.BackColor = System.Drawing.Color.Gainsboro;
            this.Culture.ColumnWidth = 3;
            this.Culture.ItemHeight = 16;
            this.Culture.Location = new System.Drawing.Point(660, 99);
            this.Culture.MultiColumn = true;
            this.Culture.Name = "Culture";
            this.Culture.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Culture.Size = new System.Drawing.Size(276, 260);
            this.Culture.TabIndex = 9;
            this.Culture.TabStop = false;
            // 
            // Programmation
            // 
            this.Programmation.BackColor = System.Drawing.Color.Gainsboro;
            this.Programmation.ColumnWidth = 3;
            this.Programmation.ItemHeight = 16;
            this.Programmation.Location = new System.Drawing.Point(991, 99);
            this.Programmation.MultiColumn = true;
            this.Programmation.Name = "Programmation";
            this.Programmation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Programmation.Size = new System.Drawing.Size(276, 260);
            this.Programmation.TabIndex = 10;
            this.Programmation.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(12, 379);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1255, 281);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(656, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Culture Générale";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(328, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Matématiques";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.Location = new System.Drawing.Point(8, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Toutes catégories\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Firebrick;
            this.label7.Location = new System.Drawing.Point(987, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Informatique";
            // 
            // frmQuizz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1297, 672);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Programmation);
            this.Controls.Add(this.Culture);
            this.Controls.Add(this.Mathématique);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPseudo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.Jouer);
            this.Controls.Add(this.cmdSignUp);
            this.Controls.Add(this.Classement);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmQuizz";
            this.Text = "Quizz";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Mathématique_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox Mathématique;
        private ListBox Culture;
        private ListBox Programmation;
        public PictureBox pictureBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}

