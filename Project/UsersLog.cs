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
    public partial class UsersLog : DevExpress.XtraEditors.XtraForm
    {
        public UsersLog()
        {
            InitializeComponent();
        }

        Login login = new Login();

        private void datagridviews()
        {
            try
            {
                db_connection.connection.Open();

                string query_employee = "select el_code as کد_تاریخ, el_ecode as کد_کارمند, el_enterdate as تاریخ_ورود, el_exitdate as تاریخ_خروج from employee_log";

                string query_manager = "select ml_code as کد_تاریخ, ml_mcode as کد_کارمند, ml_enterdate as تاریخ_ورود, ml_exitdate as تاریخ_خروج from manager_log";

                OleDbCommand command_employee = new OleDbCommand(query_employee, db_connection.connection);

                OleDbCommand command_manager = new OleDbCommand(query_manager, db_connection.connection);

                OleDbDataAdapter adapter_employee = new OleDbDataAdapter(command_employee);

                OleDbDataAdapter adapter_manager = new OleDbDataAdapter(command_manager);

                DataTable table_employee = new DataTable();

                DataTable table_manager = new DataTable();

                try
                {
                    adapter_employee.Fill(table_employee);

                    adapter_manager.Fill(table_manager);

                    datagridview_employee_date.DataSource = table_employee;

                    datagridview_manager_date.DataSource = table_manager;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "DataGridViews | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "DataGridViews | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void comboboxs()
        {
            try
            {
                db_connection.connection.Open();

                string query_employee = "select * from employee";

                string query_manager = "select * from manager";

                OleDbCommand command_employee = new OleDbCommand(query_employee, db_connection.connection);

                OleDbCommand command_manager = new OleDbCommand(query_manager, db_connection.connection);

                OleDbDataAdapter adapter_employee = new OleDbDataAdapter(command_employee);

                OleDbDataAdapter adapter_manager = new OleDbDataAdapter(command_manager);

                DataTable table_employee = new DataTable();

                DataTable table_manager = new DataTable();

                try
                {
                    adapter_employee.Fill(table_employee);

                    adapter_manager.Fill(table_manager);

                    dropdown_employee_searchby_code.DataSource = table_employee;

                    dropdown_employee_searchby_code.DisplayMember = "e_code";

                    dropdown_manager_searchby_code.DataSource = table_manager;

                    dropdown_manager_searchby_code.DisplayMember = "m_code";

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "ComboBoxs | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "ComboBoxs | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void employee_search()
        {
            try
            {
                db_connection.connection.Open();

                string query_search = "";

                if (dropdown_employee_searchby_code.SelectedIndex != -1)
                    query_search = $"select el_code as کد_تاریخ, el_ecode as کد_کارمند, el_enterdate as تاریخ_ورود, el_exitdate as تاریخ_خروج from employee_log where el_ecode={dropdown_employee_searchby_code.Text} and el_enterdate >= '{datetime_employee_from.Text}' and el_exitdate <= '{datetime_employee_to.Text}'";
                else
                    query_search = $"select el_code as کد_تاریخ, el_ecode as کد_کارمند, el_enterdate as تاریخ_ورود, el_exitdate as تاریخ_خروج from employee_log where el_enterdate >= '{datetime_employee_from.Text}' and el_exitdate <= '{datetime_employee_to.Text}'"; ;

                OleDbCommand command_search = new OleDbCommand(query_search, db_connection.connection);

                OleDbDataAdapter adapter_search = new OleDbDataAdapter(command_search);

                DataTable table_search = new DataTable();

                try
                {
                    adapter_search.Fill(table_search);

                    datagridview_employee_date.DataSource = table_search;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Employee Search | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "Employee Search | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void manager_search()
        {
            try
            {
                db_connection.connection.Open();

                string query_search = "";

                if (dropdown_employee_searchby_code.SelectedIndex != -1)
                    query_search = $"select ml_code as کد_تاریخ, ml_mcode as کد_کارمند, ml_enterdate as تاریخ_ورود, ml_exitdate as تاریخ_خروج from manager_log where ml_mcode={dropdown_employee_searchby_code.Text} and ml_enterdate >= '{datetime_employee_from.Text}' and ml_exitdate <= '{datetime_employee_to.Text}'";
                else
                    query_search = $"select ml_code as کد_تاریخ, ml_mcode as کد_کارمند, ml_enterdate as تاریخ_ورود, ml_exitdate as تاریخ_خروج from manager_log where ml_enterdate >= '{datetime_employee_from.Text}' and ml_exitdate <= '{datetime_employee_to.Text}'"; ;

                OleDbCommand command_search = new OleDbCommand(query_search, db_connection.connection);

                OleDbDataAdapter adapter_search = new OleDbDataAdapter(command_search);

                DataTable table_search = new DataTable();

                try
                {
                    adapter_search.Fill(table_search);

                    datagridview_employee_date.DataSource = table_search;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Manager Search | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "Manager Search | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void load_all_data()
        {
            login.check_db();

            datagridviews();

            comboboxs();

            dropdown_manager_searchby_code.SelectedIndex = dropdown_employee_searchby_code.SelectedIndex = -1;
        }

        private void UsersLog_Load(object sender, EventArgs e)
        {
            load_all_data();
            users_log.SelectedTabPage = employee_log;
        }

        private void btn_manager_reset_Click(object sender, EventArgs e)
        {
            load_all_data();
        }

        private void btn_employee_reset_Click(object sender, EventArgs e)
        {
            load_all_data();
        }

        private void btn_employee_search_Click(object sender, EventArgs e)
        {
            if (datetime_employee_from.Text != "" && datetime_employee_to.Text != "")
            {
                employee_search();
            }
        }

        private void btn_manager_search_Click(object sender, EventArgs e)
        {
            if (datetime_manager_from.Text != "" && datetime_manager_to.Text != "")
            {
                manager_search();
            }
        }
    }
}