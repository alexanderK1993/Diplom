namespace DiplomVirtualEnterprize
{
    partial class Login
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
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.MailLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.labelRegistration = new System.Windows.Forms.Label();
            this.linkLabelEnter = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelRegistration = new System.Windows.Forms.LinkLabel();
            this.labelEnter = new System.Windows.Forms.Label();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMail
            // 
            this.textBoxMail.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMail.Location = new System.Drawing.Point(123, 62);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(142, 20);
            this.textBoxMail.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Location = new System.Drawing.Point(123, 98);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(142, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // MailLabel
            // 
            this.MailLabel.AutoSize = true;
            this.MailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MailLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MailLabel.ForeColor = System.Drawing.Color.White;
            this.MailLabel.Location = new System.Drawing.Point(47, 61);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(59, 21);
            this.MailLabel.TabIndex = 2;
            this.MailLabel.Text = "Почта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(47, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelLogin.Controls.Add(this.labelError);
            this.panelLogin.Controls.Add(this.buttonRegistration);
            this.panelLogin.Controls.Add(this.labelRegistration);
            this.panelLogin.Controls.Add(this.linkLabelEnter);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.linkLabelRegistration);
            this.panelLogin.Controls.Add(this.labelEnter);
            this.panelLogin.Controls.Add(this.buttonEnter);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.MailLabel);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Controls.Add(this.textBoxMail);
            this.panelLogin.ForeColor = System.Drawing.Color.Black;
            this.panelLogin.Location = new System.Drawing.Point(0, 1);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(323, 199);
            this.panelLogin.TabIndex = 4;
            this.panelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogin_Paint);
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.BackColor = System.Drawing.Color.Orange;
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegistration.Location = new System.Drawing.Point(27, 136);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(238, 27);
            this.buttonRegistration.TabIndex = 10;
            this.buttonRegistration.Text = "Зарегестрировать компанию";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Visible = false;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // labelRegistration
            // 
            this.labelRegistration.AutoSize = true;
            this.labelRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRegistration.ForeColor = System.Drawing.Color.White;
            this.labelRegistration.Location = new System.Drawing.Point(112, 8);
            this.labelRegistration.Name = "labelRegistration";
            this.labelRegistration.Size = new System.Drawing.Size(184, 20);
            this.labelRegistration.TabIndex = 9;
            this.labelRegistration.Text = "зарегестрироваться";
            this.labelRegistration.Visible = false;
            // 
            // linkLabelEnter
            // 
            this.linkLabelEnter.AutoSize = true;
            this.linkLabelEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelEnter.LinkColor = System.Drawing.Color.Orange;
            this.linkLabelEnter.Location = new System.Drawing.Point(3, 8);
            this.linkLabelEnter.Name = "linkLabelEnter";
            this.linkLabelEnter.Size = new System.Drawing.Size(56, 20);
            this.linkLabelEnter.TabIndex = 8;
            this.linkLabelEnter.TabStop = true;
            this.linkLabelEnter.Text = "Войти";
            this.linkLabelEnter.Visible = false;
            this.linkLabelEnter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEnter_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(66, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "или";
            // 
            // linkLabelRegistration
            // 
            this.linkLabelRegistration.AutoSize = true;
            this.linkLabelRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelRegistration.LinkColor = System.Drawing.Color.Orange;
            this.linkLabelRegistration.Location = new System.Drawing.Point(112, 8);
            this.linkLabelRegistration.Name = "linkLabelRegistration";
            this.linkLabelRegistration.Size = new System.Drawing.Size(166, 20);
            this.linkLabelRegistration.TabIndex = 6;
            this.linkLabelRegistration.TabStop = true;
            this.linkLabelRegistration.Text = "зарегестрироваться";
            this.linkLabelRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegistration_LinkClicked);
            // 
            // labelEnter
            // 
            this.labelEnter.AutoSize = true;
            this.labelEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEnter.ForeColor = System.Drawing.Color.White;
            this.labelEnter.Location = new System.Drawing.Point(3, 8);
            this.labelEnter.Name = "labelEnter";
            this.labelEnter.Size = new System.Drawing.Size(61, 20);
            this.labelEnter.TabIndex = 5;
            this.labelEnter.Text = "Войти";
            // 
            // buttonEnter
            // 
            this.buttonEnter.BackColor = System.Drawing.Color.Orange;
            this.buttonEnter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEnter.Location = new System.Drawing.Point(200, 136);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(65, 27);
            this.buttonEnter.TabIndex = 4;
            this.buttonEnter.Text = "Войти";
            this.buttonEnter.UseVisualStyleBackColor = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(6, 37);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(314, 13);
            this.labelError.TabIndex = 11;
            this.labelError.Text = "Указанный почтовый ящик уже зарегистрирован в системе";
            this.labelError.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 198);
            this.Controls.Add(this.panelLogin);
            this.Name = "Login";
            this.ShowIcon = false;
            this.Text = "Вход в систему";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.LinkLabel linkLabelRegistration;
        private System.Windows.Forms.Label labelEnter;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRegistration;
        private System.Windows.Forms.LinkLabel linkLabelEnter;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.Label labelError;
    }
}