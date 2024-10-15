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
    public partial class Manager : DevExpress.XtraEditors.XtraForm
    {
        public Manager()
        {
            InitializeComponent();
        }

        bool check = false; 

        Login login = new Login();

        public void check_session()
        {
            try
            {
                db_connection.connection.Open();

                string query = $"select * from manager where m_telephone='{session.user_telephone}' and m_password='{session.user_password}'";

                OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);

                    db_connection.connection.Close();

                    if (table.Rows.Count < 1)
                    {
                        MessageBox.Show("لطفا مجدد لاگین کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        set_exit_log();

                        this.Hide();

                        login.ShowDialog();

                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Check Session | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Check Session | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();

        }

        private void load_profile()
        {
            txtbox_name.Clear();

            txtbox_telephone.Clear();

            txtbox_old_password.Clear();

            txtbox_new_password.Clear();

            try
            {
                db_connection.connection.Open();

                string query = $"select * from manager where m_code={session.user_id}";

                OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);

                    db_connection.connection.Close();

                    txtbox_name.Text = table.Rows[0][1].ToString();
                    txtbox_telephone.Text = table.Rows[0][2].ToString();
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Refresh Data | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Refresh Data | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void edit_profile()
        {
            if (txtbox_name.Text != "" && txtbox_telephone.Text != "" && txtbox_old_password.Text != "" && txtbox_new_password.Text != "")
            {
                string old_password = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(txtbox_old_password.Text)).Select(txt => txt.ToString("x2")));

                if (old_password == session.user_password)
                {
                    try
                    {
                        db_connection.connection.Open();

                        string query_check = $"select * from employee, manager where e_telephone='{txtbox_telephone.Text}' or m_telephone='{txtbox_telephone.Text}'";

                        OleDbCommand command = new OleDbCommand(query_check, db_connection.connection);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                        DataTable table = new DataTable();

                        try
                        {
                            adapter.Fill(table);

                            db_connection.connection.Close();

                            if (table.Rows.Count > 0 && txtbox_telephone.Text != session.user_telephone)
                            {
                                load_profile();

                                MessageBox.Show("این شماره قبلا در سیستم ثبت شده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                string password = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(txtbox_new_password.Text)).Select(txt => txt.ToString("x2")));

                                string query_update = $"update manager set m_name='{txtbox_name.Text}', m_telephone='{txtbox_telephone.Text}', m_password='{password}' where m_telephone='{session.user_telephone}'";

                                db_connection.connection.Open();

                                OleDbCommand command_update = new OleDbCommand(query_update, db_connection.connection);

                                int result = command_update.ExecuteNonQuery();

                                db_connection.connection.Close();

                                if (result == 1)
                                {
                                    MessageBox.Show("ویرایش پروفایل انجام شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    check_session();

                                    load_profile();
                                }
                                else
                                    MessageBox.Show("ویرایش پروفایل با خطا روبرو شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "EditProfile | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Edit Profile | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }

                    db_connection.connection.Close();
                }
                else
                {
                    load_profile();

                    MessageBox.Show("پسورد قبلی شما اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("دیتایی برای تغییر اطلاعات وارد نکرده اید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void enter_exit_statistics()
        {
            try
            {
                db_connection.connection.Open();

                string query_log = $"select ML_EnterDate as تاریخ_ورود, ML_ExitDate as تاریخ_خروج from manager_log where not ml_exitdate='-' and ml_mcode={session.user_id}";

                OleDbCommand command_log = new OleDbCommand(query_log, db_connection.connection);

                OleDbDataAdapter adapter_log = new OleDbDataAdapter(command_log);

                DataTable table_log = new DataTable();

                try
                {
                    adapter_log.Fill(table_log);

                    datagridview_date.DataSource = table_log;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Enter/Exit | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Enter/Exit | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void set_enter_log()
        {
            try
            {
                db_connection.connection.Open();

                try
                {
                    string query_enter = $"insert into manager_log(mL_mCode, ml_EnterDate, ml_ExitDate) values({session.user_id}, '{DateTime.Today.ToShortDateString()}', '-')";

                    OleDbCommand command_enter = new OleDbCommand(query_enter, db_connection.connection);

                    int result = command_enter.ExecuteNonQuery();

                    db_connection.connection.Close();

                    if (result == 1)
                        MessageBox.Show($"خوش آمدید {session.user_name}", "پنل مدیران کل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "EnterLog | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "EnterLog | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void set_exit_log()
        {
            try
            {
                db_connection.connection.Open();

                try
                {
                    string query_date_id = "select * from manager_log";

                    OleDbCommand command_date_id = new OleDbCommand(query_date_id, db_connection.connection);

                    OleDbDataAdapter adapter_date_id = new OleDbDataAdapter(command_date_id);

                    DataTable table_date_id = new DataTable();

                    adapter_date_id.Fill(table_date_id);

                    int date_it = int.Parse(table_date_id.Rows[table_date_id.Rows.Count - 1][0].ToString());

                    string query_exit = $"update manager_log set ml_exitdate='{DateTime.Today.ToShortDateString()}' where ml_code={date_it}";

                    OleDbCommand command_exit = new OleDbCommand(query_exit, db_connection.connection);

                    command_exit.ExecuteNonQuery();

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "ExitLog | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "ExitLog | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void task_activity()
        {
            try
            {
                db_connection.connection.Open();

                string query_ended_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_status=1";

                string query_available_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_status=2";

                string query_doing_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_status=3";

                string query_done_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_status=4";

                OleDbCommand command_ended_tasks = new OleDbCommand(query_ended_tasks, db_connection.connection);

                OleDbCommand command_available_tasks = new OleDbCommand(query_available_tasks, db_connection.connection);

                OleDbCommand command_doing_tasks = new OleDbCommand(query_doing_tasks, db_connection.connection);

                OleDbCommand command_done_tasks = new OleDbCommand(query_done_tasks, db_connection.connection);

                OleDbDataAdapter adapter_ended_tasks = new OleDbDataAdapter(command_ended_tasks);

                OleDbDataAdapter adapter_available_tasks = new OleDbDataAdapter(command_available_tasks);

                OleDbDataAdapter adapter_doing_tasks = new OleDbDataAdapter(command_doing_tasks);

                OleDbDataAdapter adapter_done_tasks = new OleDbDataAdapter(command_done_tasks);

                DataTable table_ended_tasks = new DataTable();

                DataTable table_available_tasks = new DataTable();

                DataTable table_doing_tasks = new DataTable();

                DataTable table_done_tasks = new DataTable();

                string query = "select * from expertise";

                OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                DataTable table_expertise = new DataTable();

                try
                {
                    adapter.Fill(table_expertise);

                    adapter_ended_tasks.FillSchema(table_ended_tasks, SchemaType.Source);

                    table_ended_tasks.Columns[3].DataType = typeof(string);
                    table_ended_tasks.Columns[4].DataType = typeof(string);
                    table_ended_tasks.Columns[5].DataType = typeof(string);

                    adapter_ended_tasks.Fill(table_ended_tasks);

                    for (int i = 0; i < table_ended_tasks.Rows.Count; i++)
                    {
                        if (table_ended_tasks.Rows[i][3].ToString() == "1")
                            table_ended_tasks.Rows[i][3] = "کارآموز";

                        else if (table_ended_tasks.Rows[i][3].ToString() == "2")
                            table_ended_tasks.Rows[i][3] = "مبتدی";

                        else if (table_ended_tasks.Rows[i][3].ToString() == "3")
                            table_ended_tasks.Rows[i][3] = "حرفه ای";
                    }

                    for (int a = 0; a < table_ended_tasks.Rows.Count; a++)
                    {
                        for (int b = 0; b < table_expertise.Rows.Count; b++)
                        {
                            if (table_ended_tasks.Rows[a][4].ToString() == table_expertise.Rows[b][0].ToString())
                                table_ended_tasks.Rows[a][4] = table_expertise.Rows[b][1];
                        }
                    }

                    for (int i = 0; i < table_ended_tasks.Rows.Count; i++)
                    {
                        if (table_ended_tasks.Rows[i][5].ToString() == "1")
                            table_ended_tasks.Rows[i][5] = "انجام نشده";
                    }

                    adapter_available_tasks.FillSchema(table_available_tasks, SchemaType.Source);

                    table_available_tasks.Columns[3].DataType = typeof(string);
                    table_available_tasks.Columns[4].DataType = typeof(string);
                    table_available_tasks.Columns[5].DataType = typeof(string);

                    adapter_available_tasks.Fill(table_available_tasks);

                    for (int i = 0; i < table_available_tasks.Rows.Count; i++)
                    {
                        if (table_available_tasks.Rows[i][3].ToString() == "1")
                            table_available_tasks.Rows[i][3] = "کارآموز";

                        else if (table_available_tasks.Rows[i][3].ToString() == "2")
                            table_available_tasks.Rows[i][3] = "مبتدی";

                        else if (table_available_tasks.Rows[i][3].ToString() == "3")
                            table_available_tasks.Rows[i][3] = "حرفه ای";
                    }

                    for (int a = 0; a < table_available_tasks.Rows.Count; a++)
                    {
                        for (int b = 0; b < table_expertise.Rows.Count; b++)
                        {
                            if (table_available_tasks.Rows[a][4].ToString() == table_expertise.Rows[b][0].ToString())
                                table_available_tasks.Rows[a][4] = table_expertise.Rows[b][1];
                        }
                    }

                    for (int i = 0; i < table_available_tasks.Rows.Count; i++)
                    {
                        if (table_available_tasks.Rows[i][5].ToString() == "2")
                            table_available_tasks.Rows[i][5] = "موجود";
                    }

                    adapter_doing_tasks.FillSchema(table_doing_tasks, SchemaType.Source);

                    table_doing_tasks.Columns[3].DataType = typeof(string);
                    table_doing_tasks.Columns[4].DataType = typeof(string);
                    table_doing_tasks.Columns[5].DataType = typeof(string);

                    adapter_doing_tasks.Fill(table_doing_tasks);

                    for (int i = 0; i < table_doing_tasks.Rows.Count; i++)
                    {
                        if (table_doing_tasks.Rows[i][3].ToString() == "1")
                            table_doing_tasks.Rows[i][3] = "کارآموز";

                        else if (table_doing_tasks.Rows[i][3].ToString() == "2")
                            table_doing_tasks.Rows[i][3] = "مبتدی";

                        else if (table_doing_tasks.Rows[i][3].ToString() == "3")
                            table_doing_tasks.Rows[i][3] = "حرفه ای";
                    }

                    for (int a = 0; a < table_doing_tasks.Rows.Count; a++)
                    {
                        for (int b = 0; b < table_expertise.Rows.Count; b++)
                        {
                            if (table_doing_tasks.Rows[a][4].ToString() == table_expertise.Rows[b][0].ToString())
                                table_doing_tasks.Rows[a][4] = table_expertise.Rows[b][1];
                        }
                    }

                    for (int i = 0; i < table_doing_tasks.Rows.Count; i++)
                    {
                        if (table_doing_tasks.Rows[i][5].ToString() == "3")
                            table_doing_tasks.Rows[i][5] = "درحال انجام";
                    }

                    adapter_done_tasks.FillSchema(table_done_tasks, SchemaType.Source);

                    table_done_tasks.Columns[3].DataType = typeof(string);
                    table_done_tasks.Columns[4].DataType = typeof(string);
                    table_done_tasks.Columns[5].DataType = typeof(string);

                    adapter_done_tasks.Fill(table_done_tasks);

                    for (int i = 0; i < table_done_tasks.Rows.Count; i++)
                    {
                        if (table_done_tasks.Rows[i][3].ToString() == "1")
                            table_done_tasks.Rows[i][3] = "کارآموز";

                        else if (table_done_tasks.Rows[i][3].ToString() == "2")
                            table_done_tasks.Rows[i][3] = "مبتدی";

                        else if (table_done_tasks.Rows[i][3].ToString() == "3")
                            table_done_tasks.Rows[i][3] = "حرفه ای";
                    }

                    for (int a = 0; a < table_done_tasks.Rows.Count; a++)
                    {
                        for (int b = 0; b < table_expertise.Rows.Count; b++)
                        {
                            if (table_done_tasks.Rows[a][4].ToString() == table_expertise.Rows[b][0].ToString())
                                table_done_tasks.Rows[a][4] = table_expertise.Rows[b][1];
                        }
                    }

                    for (int i = 0; i < table_done_tasks.Rows.Count; i++)
                    {
                        if (table_done_tasks.Rows[i][5].ToString() == "4")
                            table_done_tasks.Rows[i][5] = "انجام شده";
                    }

                    datagridview_end_task.DataSource = table_ended_tasks;

                    datagridview_my_available_task.DataSource = table_available_tasks;

                    datagridview_doing_task.DataSource = table_doing_tasks;

                    datagridview_done_task.DataSource = table_done_tasks;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Task Activity | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Task Activity | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void employee_to_task_comboboxs()
        {
            if (check)
            {
                if (dropdown_task_level.SelectedIndex != -1 && dropdown_task_expertise.SelectedIndex != -1)
                {
                    try
                    {
                        db_connection.connection.Open();

                        int level = dropdown_task_level.SelectedIndex + 1;

                        string query = $"select * from employee where e_level={level} and e_expertise={dropdown_task_expertise.Text}";

                        OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                        DataTable table = new DataTable();

                        try
                        {
                            adapter.Fill(table);

                            db_connection.connection.Close();

                            dropdown_only_one.DataSource = table;
                            dropdown_only_one.DisplayMember = "e_code";
                        }
                        catch
                        {
                            MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "ETT Comboboxs | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "ETT Comboboxs | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }

                    db_connection.connection.Close();
                }
            }
        }

        private void task_comboboxs()
        {
            try
            {
                db_connection.connection.Open();

                string query_level = "select * from employee_level";

                OleDbCommand command_level = new OleDbCommand(query_level, db_connection.connection);

                OleDbDataAdapter adapter_level = new OleDbDataAdapter(command_level);

                DataTable table_level = new DataTable();

                string query_expertise = "select * from expertise";

                OleDbCommand command_expertise = new OleDbCommand(query_expertise, db_connection.connection);

                OleDbDataAdapter adapter_expertise = new OleDbDataAdapter(command_expertise);

                DataTable table_expertise = new DataTable();

                string query_delete_task = "select * from task";

                OleDbCommand command_delete_task = new OleDbCommand(query_delete_task, db_connection.connection);

                OleDbDataAdapter adapter_delete_task = new OleDbDataAdapter(command_delete_task);

                DataTable table_delete_task = new DataTable();

                try
                {
                    adapter_level.Fill(table_level);

                    adapter_expertise.Fill(table_expertise);

                    adapter_delete_task.Fill(table_delete_task);

                    db_connection.connection.Close();

                    dropdown_task_level.DataSource = table_level;

                    dropdown_task_level.DisplayMember = "el_level_name";

                    dropdown_task_expertise.DataSource = table_expertise;

                    dropdown_task_expertise.DisplayMember = "ex_code";

                    dropdown_delete_task.DataSource = table_delete_task;

                    dropdown_delete_task.DisplayMember = "t_code";

                    dropdown_task_expertise.SelectedIndex = 0;

                    check = true;
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Task ComboBoxs | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Task ComboBoxs | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void task_create()
        {
            if (txtbox_task_name.Text != "" && txtbox_task_score.Text != "" && dropdown_task_level.SelectedIndex != -1 && dropdown_task_expertise.SelectedIndex != -1 && txtbox_task_end.Text != "")
            {
                int number = 0;
                bool result = int.TryParse(txtbox_task_score.Text, out number);

                if (result)
                {
                    try
                    {
                        db_connection.connection.Open();

                        int level = dropdown_task_level.SelectedIndex + 1;

                        string query_check_level = $"select * from employee_level where el_level_code={level}";

                        OleDbCommand command_check_level = new OleDbCommand(query_check_level, db_connection.connection);

                        OleDbDataAdapter adapter_check_level = new OleDbDataAdapter(command_check_level);

                        DataTable table_check_level = new DataTable();

                        string query_check_expertise = $"select * from expertise where ex_code={dropdown_task_expertise.Text}";

                        OleDbCommand command_check_expertise = new OleDbCommand(query_check_expertise, db_connection.connection);

                        OleDbDataAdapter adapter_check_expertise = new OleDbDataAdapter(command_check_expertise);

                        DataTable table_check_expertise = new DataTable();

                        string query_check_employee = $"select * from employee where e_code={dropdown_only_one.Text}";

                        OleDbCommand command_check_employee = new OleDbCommand(query_check_employee, db_connection.connection);

                        OleDbDataAdapter adapter_check_employee = new OleDbDataAdapter(command_check_employee);

                        DataTable table_check_employee = new DataTable();

                        try
                        {
                            adapter_check_level.Fill(table_check_level);

                            adapter_check_expertise.Fill(table_check_expertise);

                            adapter_check_employee.Fill(table_check_employee);

                            if (table_check_level.Rows.Count > 0)
                            {
                                if (table_check_expertise.Rows.Count > 0)
                                {
                                    if (table_check_employee.Rows.Count > 0)
                                    {
                                        string query_create_task = "";

                                        if (checkbox_only_one.Checked && dropdown_only_one.SelectedIndex != -1)
                                            query_create_task = $"insert into task (t_emcode, t_name, t_level, t_re, t_score, t_end) values({dropdown_only_one.Text}, '{txtbox_task_name.Text}', {level}, {dropdown_task_expertise.Text}, {txtbox_task_score.Text}, '{txtbox_task_end.Text}')";
                                        else
                                            query_create_task = $"insert into task (t_name, t_level, t_re, t_score, t_end) values('{txtbox_task_name.Text}', {level}, {dropdown_task_expertise.Text}, {txtbox_task_score.Text}, '{txtbox_task_end.Text}')";

                                        OleDbCommand command_create_task = new OleDbCommand(query_create_task, db_connection.connection);

                                        int result_create = command_create_task.ExecuteNonQuery();

                                        string name = txtbox_task_name.Text;

                                        txtbox_task_name.Clear();
                                        txtbox_task_score.Clear();
                                        txtbox_task_end.Clear();

                                        if (result_create == 1)
                                        {
                                            db_connection.connection.Close();

                                            load_all_data();

                                            MessageBox.Show($"تسک شما با نام '{name}' ساخته شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show("عملیات ساخت تسک با خطا روبرو شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                        MessageBox.Show("کارمند مورد نظر یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    MessageBox.Show("تخصص مورد نظر یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                                MessageBox.Show("سطح کارمند مورد نظر یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            db_connection.connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Tast Create | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Tast Create | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }

                    db_connection.connection.Close();
                }
                else
                    MessageBox.Show("امتیازی برای تسک مورد نظر وارد نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("شما اطلاعات مورد نیاز جهت ایجاد تسک را وارد نکرده اید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void task_delete()
        {
            if (dropdown_delete_task.SelectedIndex != -1)
            {
                try
                {
                    db_connection.connection.Open();

                    string query_check = $"select * from task where t_code={dropdown_delete_task.Text}";

                    OleDbCommand command_check = new OleDbCommand(query_check, db_connection.connection);

                    OleDbDataAdapter adapter_check = new OleDbDataAdapter(command_check);

                    DataTable table_check = new DataTable();

                    try
                    {
                        adapter_check.Fill(table_check);

                        if (table_check.Rows.Count > 0)
                        {
                            string query_check_data = $"select * from task, employee where t_code={dropdown_delete_task.Text} and e_code=t_emcode and t_status=4";

                            OleDbCommand command_check_data = new OleDbCommand(query_check_data, db_connection.connection);

                            OleDbDataAdapter adapter_check_data = new OleDbDataAdapter(command_check_data);

                            DataTable table_check_data = new DataTable();

                            adapter_check_data.Fill(table_check_data);

                            if (table_check_data.Rows.Count > 0)
                            {
                                string query_update = $"update employee set e_score=e_score-{table_check_data.Rows[0][6].ToString()} where e_code={table_check_data.Rows[0][1].ToString()}";
                                string query_delete = $"delete from task where t_code={dropdown_delete_task.Text}";

                                OleDbCommand command_update = new OleDbCommand(query_update, db_connection.connection);

                                int result1 = command_update.ExecuteNonQuery();

                                OleDbCommand command_delete = new OleDbCommand(query_delete, db_connection.connection);

                                int result2 = command_delete.ExecuteNonQuery();

                                db_connection.connection.Close();

                                if (result1 == 1 && result2 == 1)
                                {
                                    load_all_data();

                                    MessageBox.Show("تسک مورد نظر با موفقیت حذف شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("خطایی در هنگام حذف تسک مورد نظر رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                string query_delete = $"delete from task where t_code={dropdown_delete_task.Text}";

                                OleDbCommand command_delete = new OleDbCommand(query_delete, db_connection.connection);

                                int result = command_delete.ExecuteNonQuery();

                                db_connection.connection.Close();

                                if (result == 1)
                                {
                                    load_all_data();

                                    MessageBox.Show("تسک مورد نظر با موفقیت حذف شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("خطایی در هنگام حذف تسک مورد نظر رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                            MessageBox.Show("تسک مورد نظر جهت حذف یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        db_connection.connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Tast Delete | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Tast Delete | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                db_connection.connection.Close();
            }
            else
                MessageBox.Show("تسکی برای حذف انتخاب نکرده اید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void employee_and_expertise_grids()
        {
            try
            {
                db_connection.connection.Open();

                string query_employee = "select e_code as کد_کارمند, e_name as نام_و_نام_خانوادگی, e_telephone as تلفن_کارمند, e_level as سطح_کارمند, e_expertise as مهارت_کارمند, e_score as امتیاز_کارمند from employee";

                string query_expertise = "select ex_code as کد_مهارت, ex_name as نام_مهارت from expertise";

                OleDbCommand command_employee = new OleDbCommand(query_employee, db_connection.connection);

                OleDbCommand command_expertise = new OleDbCommand(query_expertise, db_connection.connection);

                OleDbDataAdapter adapter_employee = new OleDbDataAdapter(command_employee);

                OleDbDataAdapter adapter_expertise = new OleDbDataAdapter(command_expertise);

                DataTable table_employee = new DataTable();

                DataTable table_expertise = new DataTable();

                try
                {
                    adapter_employee.FillSchema(table_employee, SchemaType.Source);

                    table_employee.Columns[3].DataType = typeof(string);
                    table_employee.Columns[4].DataType = typeof(string);

                    adapter_employee.Fill(table_employee);
                    adapter_expertise.Fill(table_expertise);

                    for (int i = 0; i < table_employee.Rows.Count; i++)
                    {
                        if (table_employee.Rows[i][3].ToString() == "1")
                            table_employee.Rows[i][3] = "کارآموز";

                        else if (table_employee.Rows[i][3].ToString() == "2")
                            table_employee.Rows[i][3] = "مبتدی";

                        else if (table_employee.Rows[i][3].ToString() == "3")
                            table_employee.Rows[i][3] = "حرفه ای";
                    }

                    for (int a = 0; a < table_employee.Rows.Count; a++)
                    {
                        for (int b = 0; b < table_expertise.Rows.Count; b++)
                        {
                            if (table_employee.Rows[a][4].ToString() == table_expertise.Rows[b][0].ToString())
                                table_employee.Rows[a][4] = table_expertise.Rows[b][1];
                        }
                    }

                    datagridview_employee.DataSource = table_employee;

                    datagridview_expertise.DataSource = table_expertise;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Eae | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Eae | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void employee_comboboxs()
        {
            try
            {
                db_connection.connection.Open();

                string query_expertise = "select * from expertise";

                OleDbCommand command_expertise = new OleDbCommand(query_expertise, db_connection.connection);

                OleDbDataAdapter adapter_expertise = new OleDbDataAdapter(command_expertise);

                DataTable table_expertise = new DataTable();

                string query_delete_employee = "select * from employee";

                OleDbCommand command_delete_employee = new OleDbCommand(query_delete_employee, db_connection.connection);

                OleDbDataAdapter adapter_delete_employee = new OleDbDataAdapter(command_delete_employee);

                DataTable table_delete_employee = new DataTable();

                try
                {
                    adapter_expertise.Fill(table_expertise);

                    adapter_delete_employee.Fill(table_delete_employee);

                    db_connection.connection.Close();

                    combobox_expertise.DataSource = table_expertise;
                    combobox_expertise.DisplayMember = "ex_code";

                    dropdown_delete_employee.DataSource = table_delete_employee;
                    dropdown_delete_employee.DisplayMember = "e_code";
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Employee ComboBoxs | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Employee ComboBoxs | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void expertise_comboboxs()
        {
            try
            {
                db_connection.connection.Open();

                string query_expertise = "select * from expertise";

                OleDbCommand command_expertise = new OleDbCommand(query_expertise, db_connection.connection);

                OleDbDataAdapter adapter_expertise = new OleDbDataAdapter(command_expertise);

                DataTable table_expertise = new DataTable();

                try
                {
                    adapter_expertise.Fill(table_expertise);

                    db_connection.connection.Close();

                    dropdown_delete_expertise.DataSource = table_expertise;
                    dropdown_delete_expertise.DisplayMember = "ex_code";
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Employee ComboBoxs | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Employee ComboBoxs | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void employee_create()
        {
            if (txtbox_employee_name.Text != "" && txtbox_employee_telephone.Text != "" && txtbox_employee_password.Text != "" && combobox_expertise.SelectedIndex > -1)
            {
                if (txtbox_employee_telephone.Text[0] == '0' && txtbox_employee_telephone.Text[1] == '9' && txtbox_employee_telephone.Text.Length == 11)
                {
                    try
                    {
                        db_connection.connection.Open();

                        string query = $"select * from employee, manager where e_telephone='{txtbox_employee_telephone.Text}' or m_telephone='{txtbox_employee_telephone.Text}'";

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
                                int level_code = combobox_level.SelectedIndex + 1;

                                string employee_name = txtbox_employee_name.Text;

                                string employee_telephone = txtbox_employee_telephone.Text;

                                string employee_password = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(txtbox_employee_password.Text)).Select(txt => txt.ToString("x2")));

                                string query_insert = $"insert into employee (e_name, e_telephone, e_password, e_level, e_expertise) values('{employee_name}', '{employee_telephone}', '{employee_password}', {level_code}, {combobox_expertise.Text})";

                                OleDbCommand query_command = new OleDbCommand(query_insert, db_connection.connection);

                                int result = query_command.ExecuteNonQuery();

                                db_connection.connection.Close();

                                if (result == 1)
                                {
                                    txtbox_employee_name.Clear();
                                    txtbox_employee_password.Clear();
                                    txtbox_employee_telephone.Clear();
                                    combobox_expertise.SelectedIndex = -1;
                                    combobox_level.SelectedIndex = -1;

                                    load_all_data();

                                    MessageBox.Show("عملیات ایجاد کارمند با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("خطایی هنگام ایجاد کارمند رخ داد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Employee Create | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "Employee Create | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }

                    db_connection.connection.Close();
                }
                else
                    MessageBox.Show("شماره تلفن وارد شده نامعتبر می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("فیلد های مورد نظر نمیتوانند خالی باشند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void employee_delete()
        {
            if (dropdown_delete_employee.SelectedIndex != -1)
            {
                try
                {
                    db_connection.connection.Open();

                    string query_check = $"select * from employee where e_code={dropdown_delete_employee.Text}";

                    OleDbCommand command_check = new OleDbCommand(query_check, db_connection.connection);

                    OleDbDataAdapter adapter_check = new OleDbDataAdapter(command_check);

                    DataTable table_check = new DataTable();

                    try
                    {
                        adapter_check.Fill(table_check);

                        if (table_check.Rows.Count > 0)
                        {
                            DialogResult result = MessageBox.Show("تمامی اطلاعات این کارمند حذف خواهد شد، ایا اطمینان کامل دارید؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
                            {
                                string query_delete_log = $"delete from employee_log where el_ecode={dropdown_delete_employee.Text}";

                                string query_delete_task = $"delete from task where t_emcode={dropdown_delete_employee.Text}";

                                string query_delete = $"delete from employee where e_code={dropdown_delete_employee.Text}";

                                OleDbCommand command_delete_log = new OleDbCommand(query_delete_log, db_connection.connection);

                                OleDbCommand command_delete_task = new OleDbCommand(query_delete_task, db_connection.connection);

                                OleDbCommand command_delete = new OleDbCommand(query_delete, db_connection.connection);

                                command_delete_log.ExecuteNonQuery();

                                command_delete_task.ExecuteNonQuery();

                                int result_delete = command_delete.ExecuteNonQuery();

                                db_connection.connection.Close();

                                if (result_delete == 1)
                                {
                                    load_all_data();

                                    MessageBox.Show("کارمند مورد نظر حذف شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                            MessageBox.Show("کارمند مورد نظر جهت حذف یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        db_connection.connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Employee Delete | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "Employee Delete | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                db_connection.connection.Close();
            }
            else
                MessageBox.Show("کارمندی برای حذف انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void employee_filter(string entext, string fatext)
        {
            try
            {
                db_connection.connection.Open();

                string query = $"select e_code as کد_کارمند, {entext} as {fatext} from employee";

                string query_expertise = "select * from expertise";

                OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                OleDbCommand command_expertise = new OleDbCommand(query_expertise, db_connection.connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                OleDbDataAdapter adapter_expertise = new OleDbDataAdapter(command_expertise);

                DataTable table = new DataTable();

                DataTable table_expertise = new DataTable();

                try
                {
                    adapter.Fill(table);

                    datagridview_employee.DataSource = table;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Employee Filter | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "Employee Filter | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void expertise_create()
        {
            if (txtbox_expertise.Text != "")
            {
                try
                {
                    db_connection.connection.Open();

                    string query_create = $"insert into expertise (ex_name) values('{txtbox_expertise.Text}')";

                    OleDbCommand command_create = new OleDbCommand(query_create, db_connection.connection);

                    try
                    {
                        int result = command_create.ExecuteNonQuery();

                        db_connection.connection.Close();

                        if (result == 1)
                        {
                            txtbox_expertise.Clear();

                            load_all_data();

                            MessageBox.Show("تخصص مورد نظر با موفقیت ساخته شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("خطایی هنگام ایجاد تخصص رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch
                    {
                        MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Expertise Create | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "Expertise Create | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                db_connection.connection.Close();
            }
            else
                MessageBox.Show("اطلاعاتی برای ایجاد تخصص وارد نکرده اید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void expertise_delete()
        {
            if (dropdown_delete_expertise.SelectedIndex != -1)
            {
                try
                {
                    db_connection.connection.Open();

                    string query_check = $"select * from expertise where ex_code={dropdown_delete_expertise.Text}";

                    OleDbCommand command_check = new OleDbCommand(query_check, db_connection.connection);

                    OleDbDataAdapter adapter_check = new OleDbDataAdapter(command_check);

                    DataTable table_check = new DataTable();

                    string query_exist = $"select * from employee where e_expertise={dropdown_delete_expertise.Text}";

                    OleDbCommand command_exist = new OleDbCommand(query_exist, db_connection.connection);

                    OleDbDataAdapter adapter_exist = new OleDbDataAdapter(command_exist);

                    DataTable table_exist = new DataTable();

                    try
                    {
                        adapter_exist.Fill(table_exist);

                        if (table_exist.Rows.Count < 1)
                        {
                            adapter_check.Fill(table_check);

                            if (table_check.Rows.Count > 0)
                            {
                                string query_delete = $"delete from expertise where ex_code={dropdown_delete_expertise.Text}";

                                OleDbCommand command_delete = new OleDbCommand(query_delete, db_connection.connection);

                                int result = command_delete.ExecuteNonQuery();

                                db_connection.connection.Close();

                                if (result == 1)
                                {
                                    load_all_data();

                                    MessageBox.Show("تخصص مورد نظر حذف شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("خطایی هنگام حذف تخصص رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                                MessageBox.Show("تخصصی جهت حذف یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("این تخصص توسط کارمندان انتخاب شده و قابل حذف نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        db_connection.connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("خطایی هنگام دریافت اطلاعات از دیتابیس رخ داد", "Expertise Delete | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی هنگام ارتباط با دیتابیس رخ داد", "Expertise Delete | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                db_connection.connection.Close();
            }
            else
                MessageBox.Show("اطلاعات مورد نظر جهت حذف تخصص وارد نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void fix_corrupt_date()
        {
            try
            {
                db_connection.connection.Open();

                try
                {
                    string query_fix = $"update manager_log set ml_exitdate='خطا در ثبت' where ml_exitdate='-' and ml_mcode={session.user_id}";

                    OleDbCommand command_fix = new OleDbCommand(query_fix, db_connection.connection);

                    int result = command_fix.ExecuteNonQuery();

                    db_connection.connection.Close();

                    if (result > 0)
                        MessageBox.Show("شما یک خروج غیرمنتظره داشتید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Corrupt | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Corrupt | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void load_all_data()
        {
            login.check_db();

            load_profile();

            enter_exit_statistics();

            task_activity();

            task_comboboxs();

            employee_comboboxs();

            expertise_comboboxs();

            employee_and_expertise_grids();

            combobox_expertise.SelectedIndex = dropdown_delete_employee.SelectedIndex = dropdown_delete_expertise.SelectedIndex = dropdown_delete_task.SelectedIndex = dropdown_task_level.SelectedIndex = dropdown_task_expertise.SelectedIndex = -1;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            this.Text += $" | کد : {session.user_id}";

            fix_corrupt_date();

            load_all_data();

            set_enter_log();

            ManagerPage.SelectedTabPage = tabcontrol_profile;
        }

        private void btn_users_log_Click(object sender, EventArgs e)
        {
            UsersLog form = new UsersLog();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_show_password.Checked)
            {
                txtbox_old_password.Properties.PasswordChar = '\0';
                txtbox_new_password.Properties.PasswordChar = '\0';
            }
            else
            {
                txtbox_old_password.Properties.PasswordChar = '*';
                txtbox_new_password.Properties.PasswordChar = '*';
            }
        }

        private void checkbox_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_showpassword.Checked)
                txtbox_employee_password.Properties.PasswordChar = '\0';
            else
                txtbox_employee_password.Properties.PasswordChar = '*';
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            edit_profile();
        }

        private void checkbox_only_one_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_only_one.Checked)
                dropdown_only_one.Enabled = true;
            else
                dropdown_only_one.Enabled = false;
        }

        private void Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            set_exit_log();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_all_data();

            MessageBox.Show("تمامی اطلاعات تازه سازی شدند", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dropdown_task_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            employee_to_task_comboboxs();
        }

        private void dropdown_task_expertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            employee_to_task_comboboxs();
        }

        private void btn_add_task_Click(object sender, EventArgs e)
        {
            task_create();
        }

        private void btn_delete_task_Click(object sender, EventArgs e)
        {
            task_delete();
        }

        private void btn_add_employee_Click(object sender, EventArgs e)
        {
            employee_create();
        }

        private void btn_delete_employee_Click(object sender, EventArgs e)
        {
            employee_delete();
        }

        private void btn_add_expertise_Click(object sender, EventArgs e)
        {
            expertise_create();
        }

        private void btn_delete_expertise_Click(object sender, EventArgs e)
        {
            expertise_delete();
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (toggleswitch_team.Checked)
                btn_name.Enabled = btn_level.Enabled = btn_expertise.Enabled = btn_telephone.Enabled = btn_score.Enabled = true;
            else
            {
                btn_name.Enabled = btn_level.Enabled = btn_expertise.Enabled = btn_telephone.Enabled = btn_score.Enabled = false;

                employee_and_expertise_grids();
            }
        }

        private void btn_name_Click(object sender, EventArgs e)
        {
            employee_filter("e_name", "نام_کارمند");
        }

        private void btn_score_Click(object sender, EventArgs e)
        {
            employee_filter("e_score", "امتیاز_کارمند");
        }

        private void btn_expertise_Click(object sender, EventArgs e)
        {
            employee_filter("e_expertise", "مهارت");
        }

        private void btn_telephone_Click(object sender, EventArgs e)
        {
            employee_filter("e_telephone", "شماره_تلفن");
        }

        private void btn_level_Click(object sender, EventArgs e)
        {
            employee_filter("e_level", "سطح_کارمند");
        }
    }
}