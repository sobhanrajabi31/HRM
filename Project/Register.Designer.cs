namespace Project
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.txtbox_name = new DevExpress.XtraEditors.TextEdit();
            this.txtbox_telephone = new DevExpress.XtraEditors.TextEdit();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txtbox_password = new DevExpress.XtraEditors.TextEdit();
            this.lbl_telephone = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_expertise = new System.Windows.Forms.Label();
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.btn_register = new DevExpress.XtraEditors.SimpleButton();
            this.combobox_expertise = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_telephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbox_name
            // 
            this.txtbox_name.Location = new System.Drawing.Point(55, 62);
            this.txtbox_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Properties.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_name.Properties.Appearance.Options.UseFont = true;
            this.txtbox_name.Properties.AutoHeight = false;
            this.txtbox_name.Properties.MaxLength = 255;
            this.txtbox_name.Size = new System.Drawing.Size(361, 50);
            this.txtbox_name.TabIndex = 1;
            // 
            // txtbox_telephone
            // 
            this.txtbox_telephone.Location = new System.Drawing.Point(55, 163);
            this.txtbox_telephone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbox_telephone.Name = "txtbox_telephone";
            this.txtbox_telephone.Properties.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_telephone.Properties.Appearance.Options.UseFont = true;
            this.txtbox_telephone.Properties.AutoHeight = false;
            this.txtbox_telephone.Properties.MaxLength = 11;
            this.txtbox_telephone.Size = new System.Drawing.Size(361, 50);
            this.txtbox_telephone.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(170, 27);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(131, 31);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "نام و نام خانوادگی";
            // 
            // txtbox_password
            // 
            this.txtbox_password.Location = new System.Drawing.Point(55, 263);
            this.txtbox_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbox_password.Name = "txtbox_password";
            this.txtbox_password.Properties.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_password.Properties.Appearance.Options.UseFont = true;
            this.txtbox_password.Properties.AutoHeight = false;
            this.txtbox_password.Properties.MaxLength = 255;
            this.txtbox_password.Properties.PasswordChar = '*';
            this.txtbox_password.Size = new System.Drawing.Size(361, 50);
            this.txtbox_password.TabIndex = 1;
            // 
            // lbl_telephone
            // 
            this.lbl_telephone.AutoSize = true;
            this.lbl_telephone.Location = new System.Drawing.Point(190, 128);
            this.lbl_telephone.Name = "lbl_telephone";
            this.lbl_telephone.Size = new System.Drawing.Size(90, 31);
            this.lbl_telephone.TabIndex = 2;
            this.lbl_telephone.Text = "تلفن همراه";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(202, 228);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(67, 31);
            this.lbl_password.TabIndex = 2;
            this.lbl_password.Text = "رمز عبور";
            // 
            // lbl_expertise
            // 
            this.lbl_expertise.AutoSize = true;
            this.lbl_expertise.Location = new System.Drawing.Point(208, 328);
            this.lbl_expertise.Name = "lbl_expertise";
            this.lbl_expertise.Size = new System.Drawing.Size(55, 31);
            this.lbl_expertise.TabIndex = 2;
            this.lbl_expertise.Text = "مهارت";
            // 
            // btn_register
            // 
            this.btn_register.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.Appearance.Options.UseFont = true;
            this.btn_register.Location = new System.Drawing.Point(55, 424);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(361, 39);
            this.btn_register.TabIndex = 4;
            this.btn_register.Text = "ثبت نام";
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // combobox_expertise
            // 
            this.combobox_expertise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_expertise.FormattingEnabled = true;
            this.combobox_expertise.Location = new System.Drawing.Point(55, 362);
            this.combobox_expertise.Name = "combobox_expertise";
            this.combobox_expertise.Size = new System.Drawing.Size(361, 39);
            this.combobox_expertise.TabIndex = 5;
            // 
            // Register
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 529);
            this.Controls.Add(this.combobox_expertise);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.lbl_expertise);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_telephone);
            this.Controls.Add(this.txtbox_password);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txtbox_telephone);
            this.Controls.Add(this.txtbox_name);
            this.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Register.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_telephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbox_password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtbox_name;
        private DevExpress.XtraEditors.TextEdit txtbox_telephone;
        private System.Windows.Forms.Label lbl_name;
        private DevExpress.XtraEditors.TextEdit txtbox_password;
        private System.Windows.Forms.Label lbl_telephone;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_expertise;
        private DevExpress.XtraBars.FormAssistant formAssistant1;
        private DevExpress.XtraEditors.SimpleButton btn_register;
        private System.Windows.Forms.ComboBox combobox_expertise;
    }
}