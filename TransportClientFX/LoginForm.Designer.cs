namespace TransportClientFX
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.errorText = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.lockphoto = new System.Windows.Forms.PictureBox();
            this.logophoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lockphoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logophoto)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(339, 143);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(79, 19);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(343, 184);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(75, 19);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameText
            // 
            this.usernameText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.Location = new System.Drawing.Point(424, 143);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(144, 23);
            this.usernameText.TabIndex = 5;
            // 
            // passwordText
            // 
            this.passwordText.AcceptsReturn = true;
            this.passwordText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.Location = new System.Drawing.Point(424, 180);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(144, 23);
            this.passwordText.TabIndex = 6;
            this.passwordText.UseSystemPasswordChar = true;
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.ForeColor = System.Drawing.Color.Red;
            this.errorText.Location = new System.Drawing.Point(383, 115);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(10, 13);
            this.errorText.TabIndex = 7;
            this.errorText.Text = " ";
            this.errorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.loginButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginButton.Location = new System.Drawing.Point(447, 233);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 28);
            this.loginButton.TabIndex = 8;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // lockphoto
            // 
            this.lockphoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("lockphoto.ErrorImage")));
            this.lockphoto.Image = ((System.Drawing.Image)(resources.GetObject("lockphoto.Image")));
            this.lockphoto.Location = new System.Drawing.Point(424, 34);
            this.lockphoto.Name = "lockphoto";
            this.lockphoto.Size = new System.Drawing.Size(60, 57);
            this.lockphoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lockphoto.TabIndex = 1;
            this.lockphoto.TabStop = false;
            // 
            // logophoto
            // 
            this.lockphoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("lockphoto.ErrorImage")));
            this.logophoto.Image = ((System.Drawing.Image)(resources.GetObject("logophoto.Image")));
            this.logophoto.Location = new System.Drawing.Point(-2, 0);
            this.logophoto.Name = "logophoto";
            this.logophoto.Size = new System.Drawing.Size(297, 327);
            this.logophoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logophoto.TabIndex = 0;
            this.logophoto.TabStop = false;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 325);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.lockphoto);
            this.Controls.Add(this.logophoto);
            this.Name = "LoginForm";
            this.Text = "TransMate";
            ((System.ComponentModel.ISupportInitialize)(this.lockphoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logophoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logophoto;
        private System.Windows.Forms.PictureBox lockphoto;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label errorText;
        private System.Windows.Forms.Button loginButton;
    }
}