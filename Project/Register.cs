using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

// Every Form

using System.Data.OleDb;
using System.Security.Cryptography;
using System.IO;

namespace Project
{
    public partial class Register : DevExpress.XtraEditors.XtraForm
    {
        public Register()
        {
            InitializeComponent();
        }

        Login login = new Login();

        private void load_expertise()
        {
            try
            {
                db_connection.connection.Open();

                string query = "select * from expertise";

                OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);

                    combobox_expertise.DataSource = table;
                    combobox_expertise.DisplayMember = "ex_code";
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db_connection.connection.Close();
        }

        private void register()
        {
            if (txtbox_name.Text != "" && txtbox_telephone.Text != "" && txtbox_password.Text != "" && combobox_expertise.SelectedIndex > -1)
            {
                if (txtbox_telephone.Text[0] == '0' && txtbox_telephone.Text[1] == '9' && txtbox_telephone.Text.Length == 11)
                {
                    try
                    {
                        db_connection.connection.Open();

                        string query = $"select * from employee, manager where e_telephone='{txtbox_telephone.Text}' or m_telephone='{txtbox_telephone.Text}'";

                        OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                        DataTable table = new DataTable();

                        try
                        {
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                                MessageBox.Show("این شماره در سیستم ثبت شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                string employee_name = txtbox_name.Text;

                                string employee_telephone = txtbox_telephone.Text;

                                string employee_password = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(txtbox_password.Text)).Select(txt => txt.ToString("x2")));

                                string query_insert = $"insert into employee (e_name, e_telephone, e_password, e_expertise) values('{employee_name}', '{employee_telephone}', '{employee_password}', {combobox_expertise.Text})";

                                OleDbCommand query_command = new OleDbCommand(query_insert, db_connection.connection);

                                int result = query_command.ExecuteNonQuery();

                                if (result == 1)
                                {
                                    MessageBox.Show("عملیات ثبت نام با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("خطایی در ثبت نام شما رخ داد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    db_connection.connection.Close();
                }
                else
                    MessageBox.Show("شماره تلفن وارد شده نامعتبر می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("فیلد های مورد نظر نمیتوانند خالی باشند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Register_Load(object sender, EventArgs e)
        {
            login.check_db();
            load_expertise();
            combobox_expertise.SelectedIndex = -1;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            register();
        }
    }
}