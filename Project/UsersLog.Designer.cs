namespace Project
{
    partial class UsersLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersLog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.manager_log = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.datetime_manager_from = new DevExpress.XtraEditors.TextEdit();
            this.datetime_manager_to = new DevExpress.XtraEditors.TextEdit();
            this.btn_manager_search = new DevExpress.XtraEditors.SimpleButton();
            this.btn_manager_reset = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_manager = new System.Windows.Forms.Label();
            this.dropdown_manager_searchby_code = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupbox_manager_date = new DevExpress.XtraEditors.GroupControl();
            this.datagridview_manager_date = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.employee_log = new DevExpress.XtraTab.XtraTabPage();
            this.groupbox_employee_adv_search = new DevExpress.XtraEditors.GroupControl();
            this.datetime_employee_from = new DevExpress.XtraEditors.TextEdit();
            this.datetime_employee_to = new DevExpress.XtraEditors.TextEdit();
            this.btn_employee_search = new DevExpress.XtraEditors.SimpleButton();
            this.btn_employee_reset = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_codeemployee = new System.Windows.Forms.Label();
            this.dropdown_employee_searchby_code = new System.Windows.Forms.ComboBox();
            this.lbl_to_date = new System.Windows.Forms.Label();
            this.lbl_from_date = new System.Windows.Forms.Label();
            this.groupbox_employee_date = new DevExpress.XtraEditors.GroupControl();
            this.datagridview_employee_date = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.users_log = new DevExpress.XtraTab.XtraTabControl();
            this.manager_log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_manager_from.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_manager_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupbox_manager_date)).BeginInit();
            this.groupbox_manager_date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_manager_date)).BeginInit();
            this.employee_log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupbox_employee_adv_search)).BeginInit();
            this.groupbox_employee_adv_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_employee_from.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_employee_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupbox_employee_date)).BeginInit();
            this.groupbox_employee_date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_employee_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.users_log)).BeginInit();
            this.users_log.SuspendLayout();
            this.SuspendLayout();
            // 
            // manager_log
            // 
            this.manager_log.Controls.Add(this.groupControl7);
            this.manager_log.Controls.Add(this.groupbox_manager_date);
            this.manager_log.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("manager_log.ImageOptions.Image")));
            this.manager_log.Name = "manager_log";
            this.manager_log.Size = new System.Drawing.Size(1227, 599);
            this.manager_log.Text = "آمار ورود و خروج مدیران کل";
            // 
            // groupControl7
            // 
            this.groupControl7.AppearanceCaption.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl7.AppearanceCaption.Options.UseFont = true;
            this.groupControl7.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl7.CaptionImageOptions.Image")));
            this.groupControl7.Controls.Add(this.datetime_manager_from);
            this.groupControl7.Controls.Add(this.datetime_manager_to);
            this.groupControl7.Controls.Add(this.btn_manager_search);
            this.groupControl7.Controls.Add(this.btn_manager_reset);
            this.groupControl7.Controls.Add(this.lbl_manager);
            this.groupControl7.Controls.Add(this.dropdown_manager_searchby_code);
            this.groupControl7.Controls.Add(this.label5);
            this.groupControl7.Controls.Add(this.label6);
            this.groupControl7.Location = new System.Drawing.Point(11, 354);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(1205, 228);
            this.groupControl7.TabIndex = 9;
            this.groupControl7.Text = "جستجو پیشرفته";
            // 
            // datetime_manager_from
            // 
            this.datetime_manager_from.Location = new System.Drawing.Point(791, 111);
            this.datetime_manager_from.Name = "datetime_manager_from";
            this.datetime_manager_from.Properties.AutoHeight = false;
            this.datetime_manager_from.Size = new System.Drawing.Size(250, 39);
            this.datetime_manager_from.TabIndex = 34;
            // 
            // datetime_manager_to
            // 
            this.datetime_manager_to.Location = new System.Drawing.Point(452, 111);
            this.datetime_manager_to.Name = "datetime_manager_to";
            this.datetime_manager_to.Properties.AutoHeight = false;
            this.datetime_manager_to.Size = new System.Drawing.Size(250, 39);
            this.datetime_manager_to.TabIndex = 35;
            // 
            // btn_manager_search
            // 
            this.btn_manager_search.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manager_search.Appearance.Options.UseFont = true;
            this.btn_manager_search.Location = new System.Drawing.Point(86, 111);
            this.btn_manager_search.Name = "btn_manager_search";
            this.btn_manager_search.Size = new System.Drawing.Size(121, 40);
            this.btn_manager_search.TabIndex = 28;
            this.btn_manager_search.Text = "جستجو";
            this.btn_manager_search.Click += new System.EventHandler(this.btn_manager_search_Click);
            // 
            // btn_manager_reset
            // 
            this.btn_manager_reset.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manager_reset.Appearance.Options.UseFont = true;
            this.btn_manager_reset.Location = new System.Drawing.Point(213, 111);
            this.btn_manager_reset.Name = "btn_manager_reset";
            this.btn_manager_reset.Size = new System.Drawing.Size(94, 40);
            this.btn_manager_reset.TabIndex = 28;
            this.btn_manager_reset.Text = "ریست";
            this.btn_manager_reset.Click += new System.EventHandler(this.btn_manager_reset_Click);
            // 
            // lbl_manager
            // 
            this.lbl_manager.AutoSize = true;
            this.lbl_manager.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_manager.Location = new System.Drawing.Point(337, 77);
            this.lbl_manager.Name = "lbl_manager";
            this.lbl_manager.Size = new System.Drawing.Size(87, 31);
            this.lbl_manager.TabIndex = 25;
            this.lbl_manager.Text = "کد مدیرکل";
            // 
            // dropdown_manager_searchby_code
            // 
            this.dropdown_manager_searchby_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdown_manager_searchby_code.FormattingEnabled = true;
            this.dropdown_manager_searchby_code.Location = new System.Drawing.Point(313, 111);
            this.dropdown_manager_searchby_code.Name = "dropdown_manager_searchby_code";
            this.dropdown_manager_searchby_code.Size = new System.Drawing.Size(133, 39);
            this.dropdown_manager_searchby_code.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(708, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = ": تا تاریخ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1047, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 31);
            this.label6.TabIndex = 1;
            this.label6.Text = ": از تاریخ";
            // 
            // groupbox_manager_date
            // 
            this.groupbox_manager_date.AppearanceCaption.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_manager_date.AppearanceCaption.Options.UseFont = true;
            this.groupbox_manager_date.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupbox_manager_date.CaptionImageOptions.Image")));
            this.groupbox_manager_date.Controls.Add(this.datagridview_manager_date);
            this.groupbox_manager_date.Location = new System.Drawing.Point(11, 16);
            this.groupbox_manager_date.Name = "groupbox_manager_date";
            this.groupbox_manager_date.Size = new System.Drawing.Size(1205, 332);
            this.groupbox_manager_date.TabIndex = 8;
            this.groupbox_manager_date.Text = "آمار ورود و خروج";
            // 
            // datagridview_manager_date
            // 
            this.datagridview_manager_date.AllowCustomTheming = false;
            this.datagridview_manager_date.AllowUserToAddRows = false;
            this.datagridview_manager_date.AllowUserToDeleteRows = false;
            this.datagridview_manager_date.AllowUserToResizeColumns = false;
            this.datagridview_manager_date.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.datagridview_manager_date.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridview_manager_date.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridview_manager_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridview_manager_date.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.datagridview_manager_date.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridview_manager_date.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridview_manager_date.ColumnHeadersHeight = 40;
            this.datagridview_manager_date.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.datagridview_manager_date.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.datagridview_manager_date.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridview_manager_date.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.datagridview_manager_date.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datagridview_manager_date.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.datagridview_manager_date.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.datagridview_manager_date.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.datagridview_manager_date.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.datagridview_manager_date.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.datagridview_manager_date.CurrentTheme.Name = null;
            this.datagridview_manager_date.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.datagridview_manager_date.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.datagridview_manager_date.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridview_manager_date.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.datagridview_manager_date.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridview_manager_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagridview_manager_date.EnableHeadersVisualStyles = false;
            this.datagridview_manager_date.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.datagridview_manager_date.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.datagridview_manager_date.HeaderBgColor = System.Drawing.Color.Empty;
            this.datagridview_manager_date.HeaderForeColor = System.Drawing.Color.White;
            this.datagridview_manager_date.Location = new System.Drawing.Point(5, 38);
            this.datagridview_manager_date.Name = "datagridview_manager_date";
            this.datagridview_manager_date.ReadOnly = true;
            this.datagridview_manager_date.RowHeadersVisible = false;
            this.datagridview_manager_date.RowTemplate.Height = 40;
            this.datagridview_manager_date.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview_manager_date.Size = new System.Drawing.Size(1195, 284);
            this.datagridview_manager_date.TabIndex = 0;
            this.datagridview_manager_date.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // employee_log
            // 
            this.employee_log.Controls.Add(this.groupbox_employee_adv_search);
            this.employee_log.Controls.Add(this.groupbox_employee_date);
            this.employee_log.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("employee_log.ImageOptions.Image")));
            this.employee_log.Name = "employee_log";
            this.employee_log.Size = new System.Drawing.Size(1227, 599);
            this.employee_log.Text = "آمار ورود و خروج کارمندان";
            // 
            // groupbox_employee_adv_search
            // 
            this.groupbox_employee_adv_search.AppearanceCaption.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_employee_adv_search.AppearanceCaption.Options.UseFont = true;
            this.groupbox_employee_adv_search.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupbox_employee_adv_search.CaptionImageOptions.Image")));
            this.groupbox_employee_adv_search.Controls.Add(this.datetime_employee_from);
            this.groupbox_employee_adv_search.Controls.Add(this.datetime_employee_to);
            this.groupbox_employee_adv_search.Controls.Add(this.btn_employee_search);
            this.groupbox_employee_adv_search.Controls.Add(this.btn_employee_reset);
            this.groupbox_employee_adv_search.Controls.Add(this.lbl_codeemployee);
            this.groupbox_employee_adv_search.Controls.Add(this.dropdown_employee_searchby_code);
            this.groupbox_employee_adv_search.Controls.Add(this.lbl_to_date);
            this.groupbox_employee_adv_search.Controls.Add(this.lbl_from_date);
            this.groupbox_employee_adv_search.Location = new System.Drawing.Point(11, 354);
            this.groupbox_employee_adv_search.Name = "groupbox_employee_adv_search";
            this.groupbox_employee_adv_search.Size = new System.Drawing.Size(1205, 228);
            this.groupbox_employee_adv_search.TabIndex = 6;
            this.groupbox_employee_adv_search.Text = "جستجو پیشرفته";
            // 
            // datetime_employee_from
            // 
            this.datetime_employee_from.Location = new System.Drawing.Point(791, 111);
            this.datetime_employee_from.Name = "datetime_employee_from";
            this.datetime_employee_from.Properties.AutoHeight = false;
            this.datetime_employee_from.Size = new System.Drawing.Size(250, 39);
            this.datetime_employee_from.TabIndex = 33;
            // 
            // datetime_employee_to
            // 
            this.datetime_employee_to.Location = new System.Drawing.Point(452, 111);
            this.datetime_employee_to.Name = "datetime_employee_to";
            this.datetime_employee_to.Properties.AutoHeight = false;
            this.datetime_employee_to.Size = new System.Drawing.Size(250, 39);
            this.datetime_employee_to.TabIndex = 33;
            // 
            // btn_employee_search
            // 
            this.btn_employee_search.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employee_search.Appearance.Options.UseFont = true;
            this.btn_employee_search.Location = new System.Drawing.Point(86, 111);
            this.btn_employee_search.Name = "btn_employee_search";
            this.btn_employee_search.Size = new System.Drawing.Size(121, 40);
            this.btn_employee_search.TabIndex = 32;
            this.btn_employee_search.Text = "جستجو";
            this.btn_employee_search.Click += new System.EventHandler(this.btn_employee_search_Click);
            // 
            // btn_employee_reset
            // 
            this.btn_employee_reset.Appearance.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employee_reset.Appearance.Options.UseFont = true;
            this.btn_employee_reset.Location = new System.Drawing.Point(213, 111);
            this.btn_employee_reset.Name = "btn_employee_reset";
            this.btn_employee_reset.Size = new System.Drawing.Size(94, 40);
            this.btn_employee_reset.TabIndex = 2;
            this.btn_employee_reset.Text = "ریست";
            this.btn_employee_reset.Click += new System.EventHandler(this.btn_employee_reset_Click);
            // 
            // lbl_codeemployee
            // 
            this.lbl_codeemployee.AutoSize = true;
            this.lbl_codeemployee.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codeemployee.Location = new System.Drawing.Point(340, 77);
            this.lbl_codeemployee.Name = "lbl_codeemployee";
            this.lbl_codeemployee.Size = new System.Drawing.Size(79, 31);
            this.lbl_codeemployee.TabIndex = 23;
            this.lbl_codeemployee.Text = "کد کارمند";
            // 
            // dropdown_employee_searchby_code
            // 
            this.dropdown_employee_searchby_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdown_employee_searchby_code.FormattingEnabled = true;
            this.dropdown_employee_searchby_code.Location = new System.Drawing.Point(313, 111);
            this.dropdown_employee_searchby_code.Name = "dropdown_employee_searchby_code";
            this.dropdown_employee_searchby_code.Size = new System.Drawing.Size(133, 39);
            this.dropdown_employee_searchby_code.TabIndex = 22;
            // 
            // lbl_to_date
            // 
            this.lbl_to_date.AutoSize = true;
            this.lbl_to_date.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_to_date.Location = new System.Drawing.Point(708, 116);
            this.lbl_to_date.Name = "lbl_to_date";
            this.lbl_to_date.Size = new System.Drawing.Size(72, 31);
            this.lbl_to_date.TabIndex = 1;
            this.lbl_to_date.Text = ": تا تاریخ";
            // 
            // lbl_from_date
            // 
            this.lbl_from_date.AutoSize = true;
            this.lbl_from_date.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_from_date.Location = new System.Drawing.Point(1047, 116);
            this.lbl_from_date.Name = "lbl_from_date";
            this.lbl_from_date.Size = new System.Drawing.Size(72, 31);
            this.lbl_from_date.TabIndex = 1;
            this.lbl_from_date.Text = ": از تاریخ";
            // 
            // groupbox_employee_date
            // 
            this.groupbox_employee_date.AppearanceCaption.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_employee_date.AppearanceCaption.Options.UseFont = true;
            this.groupbox_employee_date.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupbox_employee_date.CaptionImageOptions.Image")));
            this.groupbox_employee_date.Controls.Add(this.datagridview_employee_date);
            this.groupbox_employee_date.Location = new System.Drawing.Point(11, 16);
            this.groupbox_employee_date.Name = "groupbox_employee_date";
            this.groupbox_employee_date.Size = new System.Drawing.Size(1205, 332);
            this.groupbox_employee_date.TabIndex = 5;
            this.groupbox_employee_date.Text = "آمار ورود و خروج";
            // 
            // datagridview_employee_date
            // 
            this.datagridview_employee_date.AllowCustomTheming = false;
            this.datagridview_employee_date.AllowUserToAddRows = false;
            this.datagridview_employee_date.AllowUserToDeleteRows = false;
            this.datagridview_employee_date.AllowUserToResizeColumns = false;
            this.datagridview_employee_date.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.datagridview_employee_date.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagridview_employee_date.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridview_employee_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridview_employee_date.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.datagridview_employee_date.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridview_employee_date.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.datagridview_employee_date.ColumnHeadersHeight = 40;
            this.datagridview_employee_date.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.datagridview_employee_date.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.datagridview_employee_date.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridview_employee_date.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.datagridview_employee_date.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datagridview_employee_date.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.datagridview_employee_date.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.datagridview_employee_date.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.datagridview_employee_date.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.datagridview_employee_date.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.datagridview_employee_date.CurrentTheme.Name = null;
            this.datagridview_employee_date.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.datagridview_employee_date.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.datagridview_employee_date.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridview_employee_date.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.datagridview_employee_date.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridview_employee_date.DefaultCellStyle = dataGridViewCellStyle6;
            this.datagridview_employee_date.EnableHeadersVisualStyles = false;
            this.datagridview_employee_date.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.datagridview_employee_date.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.datagridview_employee_date.HeaderBgColor = System.Drawing.Color.Empty;
            this.datagridview_employee_date.HeaderForeColor = System.Drawing.Color.White;
            this.datagridview_employee_date.Location = new System.Drawing.Point(5, 38);
            this.datagridview_employee_date.Name = "datagridview_employee_date";
            this.datagridview_employee_date.ReadOnly = true;
            this.datagridview_employee_date.RowHeadersVisible = false;
            this.datagridview_employee_date.RowTemplate.Height = 40;
            this.datagridview_employee_date.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview_employee_date.Size = new System.Drawing.Size(1195, 284);
            this.datagridview_employee_date.TabIndex = 0;
            this.datagridview_employee_date.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // users_log
            // 
            this.users_log.AppearancePage.Header.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.users_log.AppearancePage.Header.Options.UseFont = true;
            this.users_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_log.Location = new System.Drawing.Point(0, 0);
            this.users_log.Name = "users_log";
            this.users_log.SelectedTabPage = this.manager_log;
            this.users_log.Size = new System.Drawing.Size(1229, 643);
            this.users_log.TabIndex = 0;
            this.users_log.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.employee_log,
            this.manager_log});
            // 
            // UsersLog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 643);
            this.Controls.Add(this.users_log);
            this.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UsersLog.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsersLog";
            this.Load += new System.EventHandler(this.UsersLog_Load);
            this.manager_log.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_manager_from.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_manager_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupbox_manager_date)).EndInit();
            this.groupbox_manager_date.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_manager_date)).EndInit();
            this.employee_log.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupbox_employee_adv_search)).EndInit();
            this.groupbox_employee_adv_search.ResumeLayout(false);
            this.groupbox_employee_adv_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_employee_from.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datetime_employee_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupbox_employee_date)).EndInit();
            this.groupbox_employee_date.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_employee_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.users_log)).EndInit();
            this.users_log.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage manager_log;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.GroupControl groupbox_manager_date;
        private Bunifu.UI.WinForms.BunifuDataGridView datagridview_manager_date;
        private DevExpress.XtraTab.XtraTabPage employee_log;
        private DevExpress.XtraEditors.GroupControl groupbox_employee_adv_search;
        private System.Windows.Forms.Label lbl_to_date;
        private System.Windows.Forms.Label lbl_from_date;
        private DevExpress.XtraEditors.GroupControl groupbox_employee_date;
        private Bunifu.UI.WinForms.BunifuDataGridView datagridview_employee_date;
        private DevExpress.XtraTab.XtraTabControl users_log;
        private System.Windows.Forms.ComboBox dropdown_employee_searchby_code;
        private System.Windows.Forms.Label lbl_codeemployee;
        private System.Windows.Forms.Label lbl_manager;
        private System.Windows.Forms.ComboBox dropdown_manager_searchby_code;
        private DevExpress.XtraEditors.SimpleButton btn_employee_reset;
        private DevExpress.XtraEditors.SimpleButton btn_manager_reset;
        private DevExpress.XtraEditors.SimpleButton btn_manager_search;
        private DevExpress.XtraEditors.SimpleButton btn_employee_search;
        private DevExpress.XtraEditors.TextEdit datetime_employee_to;
        private DevExpress.XtraEditors.TextEdit datetime_employee_from;
        private DevExpress.XtraEditors.TextEdit datetime_manager_from;
        private DevExpress.XtraEditors.TextEdit datetime_manager_to;
    }
}