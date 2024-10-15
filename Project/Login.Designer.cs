namespace Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtbox_login_telephone = new DevExpress.XtraEditors.TextEdit();
            this.txtbox_login_password = new DevExpress.XtraEditors.TextEdit();
            this.btn_register = new DevExpress.XtraEditors.SimpleButton();
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_login_telephone = new System.Windows.Forms.Label();
            this.lbl_login_password = new System.Windows.Forms.Label();
            this.checkbox_showpassword = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_login_telephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_login_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbox_showpassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbox_login_telephone
            // 
            this.txtbox_login_telephone.Location = new System.Drawing.Point(55, 62);
            this.txtbox_login_telephone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbox_login_telephone.Name = "txtbox_login_telephone";
            this.txtbox_login_telephone.Properties.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_login_telephone.Properties.Appearance.Options.UseFont = true;
            this.txtbox_login_telephone.Properties.Appearance.Options.UseTextOptions = true;
            this.txtbox_login_telephone.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtbox_login_telephone.Properties.AutoHeight = false;
            this.txtbox_login_telephone.Properties.MaxLength = 11;
            this.txtbox_login_telephone.Properties.UseMaskAsDisplayFormat = true;
            this.txtbox_login_telephone.Size = new System.Drawing.Size(361, 50);
            this.txtbox_login_telephone.TabIndex = 0;
            // 
            // txtbox_login_password
            // 
            this.txtbox_login_password.Location = new System.Drawing.Point(55, 162);
            this.txtbox_login_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbox_login_password.Name = "txtbox_login_password";
            this.txtbox_login_password.Properties.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_login_password.Properties.Appearance.Options.UseFont = true;
            this.txtbox_login_password.Properties.Appearance.Options.UseTextOptions = true;
            this.txtbox_login_password.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtbox_login_password.Properties.AutoHeight = false;
            this.txtbox_login_password.Properties.MaxLength = 255;
            this.txtbox_login_password.Properties.PasswordChar = '*';
            this.txtbox_login_password.Size = new System.Drawing.Size(361, 50);
            this.txtbox_login_password.TabIndex = 0;
            // 
            // btn_register
            // 
            this.btn_register.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.Appearance.Options.UseFont = true;
            this.btn_register.Location = new System.Drawing.Point(237, 286);
            this.btn_register.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(179, 42);
            this.btn_register.TabIndex = 1;
            this.btn_register.Text = "ثبت نام";
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_login
            // 
            this.btn_login.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Appearance.Options.UseFont = true;
            this.btn_login.Location = new System.Drawing.Point(55, 286);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(179, 42);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "ورود";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_login_telephone
            // 
            this.lbl_login_telephone.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login_telephone.Location = new System.Drawing.Point(189, 24);
            this.lbl_login_telephone.Name = "lbl_login_telephone";
            this.lbl_login_telephone.Size = new System.Drawing.Size(93, 35);
            this.lbl_login_telephone.TabIndex = 4;
            this.lbl_login_telephone.Text = "شماره تلفن";
            // 
            // lbl_login_password
            // 
            this.lbl_login_password.AutoSize = true;
            this.lbl_login_password.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login_password.Location = new System.Drawing.Point(202, 127);
            this.lbl_login_password.Name = "lbl_login_password";
            this.lbl_login_password.Size = new System.Drawing.Size(67, 31);
            this.lbl_login_password.TabIndex = 5;
            this.lbl_login_password.Text = "رمز عبور";
            // 
            // checkbox_showpassword
            // 
            this.checkbox_showpassword.Location = new System.Drawing.Point(288, 231);
            this.checkbox_showpassword.Name = "checkbox_showpassword";
            this.checkbox_showpassword.Properties.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_showpassword.Properties.Appearance.Options.UseFont = true;
            this.checkbox_showpassword.Properties.Caption = "نمایش رمز عبور";
            this.checkbox_showpassword.Size = new System.Drawing.Size(128, 35);
            this.checkbox_showpassword.TabIndex = 6;
            this.checkbox_showpassword.CheckedChanged += new System.EventHandler(this.checkbox_showpassword_CheckedChanged);
            // 
            // Login
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 377);
            this.Controls.Add(this.checkbox_showpassword);
            this.Controls.Add(this.lbl_login_password);
            this.Controls.Add(this.lbl_login_telephone);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.txtbox_login_password);
            this.Controls.Add(this.txtbox_login_telephone);
            this.Font = new System.Drawing.Font("Lalezar", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Login.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_login_telephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_login_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbox_showpassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtbox_login_telephone;
        private DevExpress.XtraEditors.TextEdit txtbox_login_password;
        private DevExpress.XtraEditors.SimpleButton btn_register;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private System.Windows.Forms.Label lbl_login_telephone;
        private System.Windows.Forms.Label lbl_login_password;
        private DevExpress.XtraEditors.CheckEdit checkbox_showpassword;
    }
}

