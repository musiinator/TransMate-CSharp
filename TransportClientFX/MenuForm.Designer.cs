using System;
using System.Windows.Forms;

namespace TransportClientFX
{
    partial class MenuForm
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.loggedInLabel = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.Label();
            this.curseLabel = new System.Windows.Forms.Label();
            this.rezervariLabel = new System.Windows.Forms.Label();
            this.curseGridView = new System.Windows.Forms.DataGridView();
            this.rezervariGridView = new System.Windows.Forms.DataGridView();
            this.destinatieLabel = new System.Windows.Forms.Label();
            this.dataSiOraPlecariiLabel = new System.Windows.Forms.Label();
            this.destinatieText = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.oraPlecariiLabel = new System.Windows.Forms.Label();
            this.oraComboBox = new System.Windows.Forms.ComboBox();
            this.cautareButton = new System.Windows.Forms.Button();
            this.locuriDisponibileLabel = new System.Windows.Forms.Label();
            this.locuriDisponibileText = new System.Windows.Forms.TextBox();
            this.numeClientLabel = new System.Windows.Forms.Label();
            this.numarLocuriLabel = new System.Windows.Forms.Label();
            this.numeClientText = new System.Windows.Forms.TextBox();
            this.numarLocuriText = new System.Windows.Forms.TextBox();
            this.adaugareButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.curseGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(317, 21);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(256, 28);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to TransMate!";
            // 
            // loggedInLabel
            // 
            this.loggedInLabel.AutoSize = true;
            this.loggedInLabel.BackColor = System.Drawing.Color.Transparent;
            this.loggedInLabel.Location = new System.Drawing.Point(757, 9);
            this.loggedInLabel.Name = "loggedInLabel";
            this.loggedInLabel.Size = new System.Drawing.Size(71, 13);
            this.loggedInLabel.TabIndex = 1;
            this.loggedInLabel.Text = "Logged in as:";
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.BackColor = System.Drawing.Color.Transparent;
            this.usernameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.Location = new System.Drawing.Point(827, 9);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(0, 13);
            this.usernameText.TabIndex = 2;
            // 
            // curseLabel
            // 
            this.curseLabel.AutoSize = true;
            this.curseLabel.BackColor = System.Drawing.Color.Transparent;
            this.curseLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curseLabel.Location = new System.Drawing.Point(200, 91);
            this.curseLabel.Name = "curseLabel";
            this.curseLabel.Size = new System.Drawing.Size(55, 23);
            this.curseLabel.TabIndex = 3;
            this.curseLabel.Text = "Curse";
            // 
            // rezervariLabel
            // 
            this.rezervariLabel.AutoSize = true;
            this.rezervariLabel.BackColor = System.Drawing.Color.Transparent;
            this.rezervariLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rezervariLabel.Location = new System.Drawing.Point(632, 88);
            this.rezervariLabel.Name = "rezervariLabel";
            this.rezervariLabel.Size = new System.Drawing.Size(86, 23);
            this.rezervariLabel.TabIndex = 4;
            this.rezervariLabel.Text = "Rezervari";
            // 
            // curseGridView
            // 
            this.curseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.curseGridView.Location = new System.Drawing.Point(50, 118);
            this.curseGridView.Name = "curseGridView";
            this.curseGridView.RowHeadersWidth = 62;
            this.curseGridView.Size = new System.Drawing.Size(361, 177);
            this.curseGridView.TabIndex = 5;
            this.curseGridView.SelectionChanged += new System.EventHandler(this.curseGridView_SelectionChanged);
            // 
            // rezervariGridView
            // 
            this.rezervariGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rezervariGridView.Location = new System.Drawing.Point(547, 114);
            this.rezervariGridView.Name = "rezervariGridView";
            this.rezervariGridView.RowHeadersWidth = 62;
            this.rezervariGridView.Size = new System.Drawing.Size(265, 180);
            this.rezervariGridView.TabIndex = 6;
            this.rezervariGridView.SelectionChanged += new System.EventHandler(this.rezervariGridView_SelectionChanged);
            // 
            // destinatieLabel
            // 
            this.destinatieLabel.AutoSize = true;
            this.destinatieLabel.BackColor = System.Drawing.Color.Transparent;
            this.destinatieLabel.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinatieLabel.Location = new System.Drawing.Point(98, 310);
            this.destinatieLabel.Name = "destinatieLabel";
            this.destinatieLabel.Size = new System.Drawing.Size(83, 21);
            this.destinatieLabel.TabIndex = 7;
            this.destinatieLabel.Text = "Destinatie:";
            // 
            // dataSiOraPlecariiLabel
            // 
            this.dataSiOraPlecariiLabel.AutoSize = true;
            this.dataSiOraPlecariiLabel.BackColor = System.Drawing.Color.Transparent;
            this.dataSiOraPlecariiLabel.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSiOraPlecariiLabel.Location = new System.Drawing.Point(81, 341);
            this.dataSiOraPlecariiLabel.Name = "dataSiOraPlecariiLabel";
            this.dataSiOraPlecariiLabel.Size = new System.Drawing.Size(101, 21);
            this.dataSiOraPlecariiLabel.TabIndex = 8;
            this.dataSiOraPlecariiLabel.Text = "Data plecarii:";
            // 
            // destinatieText
            // 
            this.destinatieText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinatieText.Location = new System.Drawing.Point(188, 311);
            this.destinatieText.Name = "destinatieText";
            this.destinatieText.Size = new System.Drawing.Size(180, 23);
            this.destinatieText.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(188, 341);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // oraPlecariiLabel
            // 
            this.oraPlecariiLabel.AutoSize = true;
            this.oraPlecariiLabel.BackColor = System.Drawing.Color.Transparent;
            this.oraPlecariiLabel.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oraPlecariiLabel.Location = new System.Drawing.Point(89, 364);
            this.oraPlecariiLabel.Name = "oraPlecariiLabel";
            this.oraPlecariiLabel.Size = new System.Drawing.Size(94, 21);
            this.oraPlecariiLabel.TabIndex = 11;
            this.oraPlecariiLabel.Text = "Ora plecarii:";
            // 
            // oraComboBox
            // 
            this.oraComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oraComboBox.FormattingEnabled = true;
            this.oraComboBox.Location = new System.Drawing.Point(188, 365);
            this.oraComboBox.Name = "oraComboBox";
            this.oraComboBox.Size = new System.Drawing.Size(179, 23);
            this.oraComboBox.TabIndex = 12;
            // 
            // cautareButton
            // 
            this.cautareButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cautareButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cautareButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cautareButton.Location = new System.Drawing.Point(185, 394);
            this.cautareButton.Name = "cautareButton";
            this.cautareButton.Size = new System.Drawing.Size(180, 30);
            this.cautareButton.TabIndex = 13;
            this.cautareButton.Text = "Cautare";
            this.cautareButton.UseVisualStyleBackColor = false;
            this.cautareButton.Click += new System.EventHandler(this.cautareButton_Click);
            // 
            // locuriDisponibileLabel
            // 
            this.locuriDisponibileLabel.AutoSize = true;
            this.locuriDisponibileLabel.BackColor = System.Drawing.Color.Transparent;
            this.locuriDisponibileLabel.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locuriDisponibileLabel.Location = new System.Drawing.Point(46, 431);
            this.locuriDisponibileLabel.Name = "locuriDisponibileLabel";
            this.locuriDisponibileLabel.Size = new System.Drawing.Size(137, 21);
            this.locuriDisponibileLabel.TabIndex = 14;
            this.locuriDisponibileLabel.Text = "Locuri disponibile:";
            // 
            // locuriDisponibileText
            // 
            this.locuriDisponibileText.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locuriDisponibileText.Location = new System.Drawing.Point(188, 430);
            this.locuriDisponibileText.Name = "locuriDisponibileText";
            this.locuriDisponibileText.Size = new System.Drawing.Size(47, 26);
            this.locuriDisponibileText.TabIndex = 15;
            // 
            // numeClientLabel
            // 
            this.numeClientLabel.AutoSize = true;
            this.numeClientLabel.BackColor = System.Drawing.Color.Transparent;
            this.numeClientLabel.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeClientLabel.Location = new System.Drawing.Point(555, 314);
            this.numeClientLabel.Name = "numeClientLabel";
            this.numeClientLabel.Size = new System.Drawing.Size(99, 21);
            this.numeClientLabel.TabIndex = 16;
            this.numeClientLabel.Text = "Nume client:";
            // 
            // numarLocuriLabel
            // 
            this.numarLocuriLabel.AutoSize = true;
            this.numarLocuriLabel.BackColor = System.Drawing.Color.Transparent;
            this.numarLocuriLabel.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numarLocuriLabel.Location = new System.Drawing.Point(568, 339);
            this.numarLocuriLabel.Name = "numarLocuriLabel";
            this.numarLocuriLabel.Size = new System.Drawing.Size(87, 21);
            this.numarLocuriLabel.TabIndex = 17;
            this.numarLocuriLabel.Text = "Numar loc:";
            // 
            // numeClientText
            // 
            this.numeClientText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeClientText.Location = new System.Drawing.Point(653, 314);
            this.numeClientText.Name = "numeClientText";
            this.numeClientText.Size = new System.Drawing.Size(159, 23);
            this.numeClientText.TabIndex = 18;
            // 
            // numarLocuriText
            // 
            this.numarLocuriText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numarLocuriText.Location = new System.Drawing.Point(653, 341);
            this.numarLocuriText.Name = "numarLocuriText";
            this.numarLocuriText.Size = new System.Drawing.Size(160, 23);
            this.numarLocuriText.TabIndex = 19;
            // 
            // adaugareButton
            // 
            this.adaugareButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.adaugareButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adaugareButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.adaugareButton.Location = new System.Drawing.Point(653, 370);
            this.adaugareButton.Name = "adaugareButton";
            this.adaugareButton.Size = new System.Drawing.Size(159, 30);
            this.adaugareButton.TabIndex = 22;
            this.adaugareButton.Text = "Adaugare";
            this.adaugareButton.UseVisualStyleBackColor = false;
            this.adaugareButton.Click += new System.EventHandler(this.adaugareButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.logoutButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logoutButton.Location = new System.Drawing.Point(818, 441);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(67, 26);
            this.logoutButton.TabIndex = 23;
            this.logoutButton.Text = "Log out";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TransportClientFX.Properties.Resources.menuBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(893, 476);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.adaugareButton);
            this.Controls.Add(this.numarLocuriText);
            this.Controls.Add(this.numeClientText);
            this.Controls.Add(this.numarLocuriLabel);
            this.Controls.Add(this.numeClientLabel);
            this.Controls.Add(this.locuriDisponibileText);
            this.Controls.Add(this.locuriDisponibileLabel);
            this.Controls.Add(this.cautareButton);
            this.Controls.Add(this.oraComboBox);
            this.Controls.Add(this.oraPlecariiLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.destinatieText);
            this.Controls.Add(this.dataSiOraPlecariiLabel);
            this.Controls.Add(this.destinatieLabel);
            this.Controls.Add(this.rezervariGridView);
            this.Controls.Add(this.curseGridView);
            this.Controls.Add(this.rezervariLabel);
            this.Controls.Add(this.curseLabel);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.loggedInLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "MenuForm";
            this.Text = "menuForm";
            ((System.ComponentModel.ISupportInitialize)(this.curseGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label loggedInLabel;
        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.Label curseLabel;
        private System.Windows.Forms.Label rezervariLabel;
        private System.Windows.Forms.DataGridView curseGridView;
        private System.Windows.Forms.DataGridView rezervariGridView;
        private System.Windows.Forms.Label destinatieLabel;
        private System.Windows.Forms.Label dataSiOraPlecariiLabel;
        private System.Windows.Forms.TextBox destinatieText;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label oraPlecariiLabel;
        private System.Windows.Forms.ComboBox oraComboBox;
        private System.Windows.Forms.Button cautareButton;
        private System.Windows.Forms.Label locuriDisponibileLabel;
        private System.Windows.Forms.TextBox locuriDisponibileText;
        private System.Windows.Forms.Label numeClientLabel;
        private System.Windows.Forms.Label numarLocuriLabel;
        private System.Windows.Forms.TextBox numeClientText;
        private System.Windows.Forms.TextBox numarLocuriText;
        private System.Windows.Forms.Button adaugareButton;
        private System.Windows.Forms.Button logoutButton;
    }
}