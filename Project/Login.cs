using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Every Form

using System.Data.OleDb;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;

namespace Project
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            check_db();
        }

        public void check_db()
        {
            if (!File.Exists("project.mdb"))
            {
                MessageBox.Show("فایل دیتابیس یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void login()
        {
            if (txtbox_login_telephone.Text != "" && txtbox_login_password.Text != "")
            {
                try
                {
                    db_connection.connection.Open();

                    string password = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(txtbox_login_password.Text)).Select(txt => txt.ToString("x2")));

                    string employee_query = $"select * from employee where e_telephone='{txtbox_login_telephone.Text}' and e_password='{password}'";

                    string manager_query = $"select * from manager where m_telephone='{txtbox_login_telephone.Text}' and m_password='{password}'";

                    OleDbCommand employee_command = new OleDbCommand(employee_query, db_connection.connection);

                    OleDbCommand manager_command = new OleDbCommand(manager_query, db_connection.connection);

                    OleDbDataAdapter employee_adapter = new OleDbDataAdapter(employee_command);

                    OleDbDataAdapter manager_adapter = new OleDbDataAdapter(manager_command);

                    DataTable employee_table = new DataTable();

                    DataTable teammanager_table = new DataTable();

                    DataTable projectmanager_table = new DataTable();

                    DataTable manager_table = new DataTable();

                    try
                    {

                        employee_adapter.Fill(employee_table);

                        manager_adapter.Fill(manager_table);

                        db_connection.connection.Close();

                        if (employee_table.Rows.Count > 0)
                        {
                            session.user_id = employee_table.Rows[0][0].ToString();
                            session.user_name = employee_table.Rows[0][1].ToString();
                            session.user_telephone = employee_table.Rows[0][2].ToString();
                            session.user_password = employee_table.Rows[0][3].ToString();
                            session.user_level = employee_table.Rows[0][4].ToString();
                            session.user_expertise = employee_table.Rows[0][5].ToString();

                            Employee employee = new Employee();

                            this.Hide();

                            employee.ShowDialog();

                            this.Show();
                        }
                        else if (manager_table.Rows.Count > 0)
                        {
                            session.user_id = manager_table.Rows[0][0].ToString();
                            session.user_name = manager_table.Rows[0][1].ToString();
                            session.user_telephone = manager_table.Rows[0][2].ToString();
                            session.user_password = manager_table.Rows[0][3].ToString();

                            Manager manager = new Manager();

                            this.Hide();

                            manager.ShowDialog();

                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("شماره تلفن یا رمز عبور شما اشتباه می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Login | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Login | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                db_connection.connection.Close();

                txtbox_login_telephone.Clear();

                txtbox_login_password.Clear();
            }
            else
                MessageBox.Show("فیلد های مورد نظر نمیتوانند خالی باشند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void checkbox_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_showpassword.Checked)
                txtbox_login_password.Properties.PasswordChar = '\0';
            else
                txtbox_login_password.Properties.PasswordChar = '*';
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            txtbox_login_telephone.Clear();
            txtbox_login_password.Clear();

            Register register = new Register();

            this.Hide();

            register.ShowDialog();

            this.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
