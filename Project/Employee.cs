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
    public partial class Employee : DevExpress.XtraEditors.XtraForm
    {
        public Employee()
        {
            InitializeComponent();
        }

        Login login = new Login();

        public void check_session()
        {
            try
            {
                db_connection.connection.Open();

                string query = $"select * from employee where e_telephone='{session.user_telephone}' and e_password='{session.user_password}'";

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

                string query = $"select * from employee where e_code={session.user_id}";

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

                                string query_update = $"update employee set e_name='{txtbox_name.Text}', e_telephone='{txtbox_telephone.Text}', e_password='{password}' where e_telephone='{session.user_telephone}'";

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

        private void activity()
        {
            try
            {
                db_connection.connection.Open();

                string query_user = $"select e_score from employee where e_code={session.user_id}";

                OleDbCommand command_user = new OleDbCommand(query_user, db_connection.connection);

                OleDbDataAdapter adapter_user = new OleDbDataAdapter(command_user);

                DataTable table_user = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_level = $"select el_level_name from employee_level where el_level_code={session.user_level}";

                OleDbCommand command_level = new OleDbCommand(query_level, db_connection.connection);

                OleDbDataAdapter adapter_level = new OleDbDataAdapter(command_level);

                DataTable table_level = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_expertise = $"select ex_name from expertise where ex_code={session.user_expertise}";

                OleDbCommand command_expertise = new OleDbCommand(query_expertise, db_connection.connection);

                OleDbDataAdapter adapter_expertise = new OleDbDataAdapter(command_expertise);

                DataTable table_expertise = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_all_tasks = $"select count(t_code) from task where t_emcode={session.user_id}";

                OleDbCommand command_all_tasks = new OleDbCommand(query_all_tasks, db_connection.connection);

                OleDbDataAdapter adapter_all_tasks = new OleDbDataAdapter(command_all_tasks);

                DataTable table_all_tasks = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_all_scores = $"select sum(t_score) from task where t_status=4 and t_emcode={session.user_id}";

                OleDbCommand command_all_scores = new OleDbCommand(query_all_scores, db_connection.connection);

                OleDbDataAdapter adapter_all_scores = new OleDbDataAdapter(command_all_scores);

                DataTable table_all_scores = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_all_done_tasks = $"select count(t_code) from task where t_status=4 and t_emcode={session.user_id}";

                OleDbCommand command_all_done_tasks = new OleDbCommand(query_all_done_tasks, db_connection.connection);

                OleDbDataAdapter adapter_all_done_tasks = new OleDbDataAdapter(command_all_done_tasks);

                DataTable table_all_done_tasks = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_all_doing_tasks = $"select count(t_code) from task where t_status=3 and t_emcode={session.user_id}";

                OleDbCommand command_all_doing_tasks = new OleDbCommand(query_all_doing_tasks, db_connection.connection);

                OleDbDataAdapter adapter_all_doing_tasks = new OleDbDataAdapter(command_all_doing_tasks);

                DataTable table_all_doing_tasks = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_all_available_tasks = $"select count(t_code) from task where t_status=2 and t_emcode={session.user_id}";

                OleDbCommand command_all_available_tasks = new OleDbCommand(query_all_available_tasks, db_connection.connection);

                OleDbDataAdapter adapter_all_available_tasks = new OleDbDataAdapter(command_all_available_tasks);

                DataTable table_all_available_tasks = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                string query_all_ended_tasks = $"select count(t_code) from task where t_status=1 and t_emcode={session.user_id}";

                OleDbCommand command_all_ended_tasks = new OleDbCommand(query_all_ended_tasks, db_connection.connection);

                OleDbDataAdapter adapter_all_ended_tasks = new OleDbDataAdapter(command_all_ended_tasks);

                DataTable table_all_ended_tasks = new DataTable();

                // ------------------------------------------------------------------------------------------ //

                try
                {
                    adapter_user.Fill(table_user);

                    adapter_level.Fill(table_level);

                    adapter_expertise.Fill(table_expertise);

                    lbl_employee_data.Text = session.user_id;

                    lbl_score_data.Text = table_user.Rows[0][0].ToString();

                    lbl_level_data.Text = table_level.Rows[0][0].ToString();

                    lbl_expertise_data.Text = table_expertise.Rows[0][0].ToString();

                    adapter_all_tasks.Fill(table_all_tasks);

                    adapter_all_scores.Fill(table_all_scores);

                    adapter_all_done_tasks.Fill(table_all_done_tasks);

                    adapter_all_doing_tasks.Fill(table_all_doing_tasks);

                    adapter_all_available_tasks.Fill(table_all_available_tasks);

                    adapter_all_ended_tasks.Fill(table_all_ended_tasks);

                    lbl_all_tasks_count_data.Text = table_all_tasks.Rows[0][0].ToString();

                    lbl_all_task_scores_data.Text = table_all_scores.Rows[0][0].ToString();

                    lbl_all_done_tasks_data.Text = table_all_done_tasks.Rows[0][0].ToString();

                    lbl_all_doing_tasks_data.Text = table_all_doing_tasks.Rows[0][0].ToString();

                    lbl_all_available_tasks_data.Text = table_all_available_tasks.Rows[0][0].ToString();

                    lbl_all_ended_tasks_data.Text = table_all_ended_tasks.Rows[0][0].ToString();

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Activity | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Activity | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void enter_exit_statistics()
        {
            try
            {
                db_connection.connection.Open();

                string query_log = $"select EL_EnterDate as تاریخ_ورود, EL_ExitDate as تاریخ_خروج from employee_log where not el_exitdate='-' and el_ecode={session.user_id}";

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
                    string query_enter = $"insert into employee_log(EL_ECode, EL_EnterDate, EL_ExitDate) values({session.user_id}, '{DateTime.Today.ToShortDateString()}', '-')";

                    OleDbCommand command_enter = new OleDbCommand(query_enter, db_connection.connection);

                    int result = command_enter.ExecuteNonQuery();

                    db_connection.connection.Close();

                    if (result == 1)
                        MessageBox.Show($"خوش آمدید {session.user_name}", "پنل کارمندان", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string query_date_id = "select * from employee_log";

                    OleDbCommand command_date_id = new OleDbCommand(query_date_id, db_connection.connection);

                    OleDbDataAdapter adapter_date_id = new OleDbDataAdapter(command_date_id);

                    DataTable table_date_id = new DataTable();

                    adapter_date_id.Fill(table_date_id);

                    int date_it = int.Parse(table_date_id.Rows[table_date_id.Rows.Count - 1][0].ToString());

                    string query_exit = $"update employee_log set el_exitdate='{DateTime.Today.ToShortDateString()}' where el_code={date_it}";

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

                string query_ended_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_emcode={session.user_id} and t_level={session.user_level} and t_re={session.user_expertise} and t_status=1";

                string query_available_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_emcode={session.user_id} and t_level={session.user_level} and t_re={session.user_expertise} and t_status=2";

                string query_doing_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_emcode={session.user_id} and t_level={session.user_level} and t_re={session.user_expertise} and t_status=3";

                string query_done_tasks = $"select t_code as کد_تسک, t_emcode as کد_کارمند, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_status as وضعیت_تسک, t_score as امتیاز_تسک, t_start as تاریخ_شروع, t_end as تاریخ_اتمام from task where t_emcode={session.user_id} and t_level={session.user_level} and t_re={session.user_expertise} and t_status=4";

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

        private void available_tasks()
        {
            try
            {
                db_connection.connection.Open();

                string query_free_available = $"select t_code as کد_تسک, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_score as امتیاز_تسک, t_end as تاریخ_اتمام from task where t_emcode is NULL and t_level={session.user_level} and t_re={session.user_expertise} and t_status=2";

                string query_available = $"select t_code as کد_تسک, t_name as نام_تسک, t_level as سطح_تسک, t_re as تخصص_مورد_نیاز, t_score as امتیاز_تسک, t_end as تاریخ_اتمام from task where t_emcode={session.user_id} and t_level={session.user_level} and t_re={session.user_expertise} and t_status=2";

                OleDbCommand command_free_available = new OleDbCommand(query_free_available, db_connection.connection);

                OleDbCommand command_available = new OleDbCommand(query_available, db_connection.connection);

                OleDbDataAdapter adapter_free_available = new OleDbDataAdapter(command_free_available);

                OleDbDataAdapter adapter_available = new OleDbDataAdapter(command_available);

                DataTable table_free_available = new DataTable();

                DataTable table_available = new DataTable();

                string query = "select * from expertise";

                OleDbCommand command = new OleDbCommand(query, db_connection.connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                DataTable table_expertise = new DataTable();

                try
                {
                    adapter.Fill(table_expertise);

                    adapter_free_available.FillSchema(table_free_available, SchemaType.Source);

                    table_free_available.Columns[2].DataType = typeof(string);
                    table_free_available.Columns[3].DataType = typeof(string);

                    adapter_free_available.Fill(table_free_available);

                    for (int i = 0; i < table_free_available.Rows.Count; i++)
                    {
                        if (table_free_available.Rows[i][2].ToString() == "1")
                            table_free_available.Rows[i][2] = "کارآموز";

                        else if (table_free_available.Rows[i][2].ToString() == "2")
                            table_free_available.Rows[i][2] = "مبتدی";

                        else if (table_free_available.Rows[i][2].ToString() == "3")
                            table_free_available.Rows[i][2] = "حرفه ای";
                    }

                    for (int a = 0; a < table_free_available.Rows.Count; a++)
                    {
                        for (int b = 0; b < table_expertise.Rows.Count; b++)
                        {
                            if (table_free_available.Rows[a][3].ToString() == table_expertise.Rows[b][0].ToString())
                                table_free_available.Rows[a][3] = table_expertise.Rows[b][1];
                        }
                    }

                    adapter_available.FillSchema(table_available, SchemaType.Source);

                    table_available.Columns[2].DataType = typeof(string);
                    table_available.Columns[3].DataType = typeof(string);

                    adapter_available.Fill(table_available);

                    for (int i = 0; i < table_available.Rows.Count; i++)
                    {
                        if (table_available.Rows[i][2].ToString() == "1")
                            table_available.Rows[i][2] = "کارآموز";

                        else if (table_available.Rows[i][2].ToString() == "2")
                            table_available.Rows[i][2] = "مبتدی";

                        else if (table_available.Rows[i][2].ToString() == "3")
                            table_available.Rows[i][2] = "حرفه ای";
                    }

                    for (int a = 0; a < table_available.Rows.Count; a++)
                    {
                        for (int b = 0; b < table_expertise.Rows.Count; b++)
                        {
                            if (table_available.Rows[a][3].ToString() == table_expertise.Rows[b][0].ToString())
                                table_available.Rows[a][3] = table_expertise.Rows[b][1];
                        }
                    }

                    datagridview_free_available_tasks.DataSource = table_free_available;

                    datagridview_available_tasks.DataSource = table_available;

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Available Tasks | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Available Tasks | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void task_comboboxs()
        {
            try
            {
                db_connection.connection.Open();

                string query_combobox_create = $"select t_code from task where (t_emcode is NULL or t_emcode={session.user_id}) and t_level={session.user_level} and t_re={session.user_expertise} and t_status=2";

                string query_combobox_done = $"select t_code from task where t_emcode={session.user_id} and t_level={session.user_level} and t_re={session.user_expertise} and t_status=3";

                OleDbCommand command_combobox_create = new OleDbCommand(query_combobox_create, db_connection.connection);

                OleDbCommand command_combobox_done = new OleDbCommand(query_combobox_done, db_connection.connection);

                OleDbDataAdapter adapter_combobox_create = new OleDbDataAdapter(command_combobox_create);

                OleDbDataAdapter adapter_combobox_done = new OleDbDataAdapter(command_combobox_done);

                DataTable table_combobox_create = new DataTable();

                DataTable table_combobox_done = new DataTable();

                try
                {
                    adapter_combobox_create.Fill(table_combobox_create);

                    adapter_combobox_done.Fill(table_combobox_done);

                    dropdown_select_start_task.DataSource = table_combobox_create;

                    dropdown_select_start_task.DisplayMember = "t_code";

                    dropdown_select_stop_task.DataSource = table_combobox_done;

                    dropdown_select_stop_task.DisplayMember = "t_code";

                    db_connection.connection.Close();
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "ComboBoxs | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "ComboBoxs | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            db_connection.connection.Close();
        }

        private void task_start()
        {
            if (dropdown_select_start_task.SelectedIndex != -1)
            {
                try
                {
                    db_connection.connection.Open();

                    string query_check = $"select * from task where t_code={dropdown_select_start_task.Text} and (t_emcode is NULL or t_emcode={session.user_id}) and t_level={session.user_level} and t_re={session.user_expertise} and t_status=2";

                    OleDbCommand command_check = new OleDbCommand(query_check, db_connection.connection);

                    OleDbDataAdapter adapter_check = new OleDbDataAdapter(command_check);

                    DataTable table_check = new DataTable();

                    try
                    {
                        adapter_check.Fill(table_check);

                        if (table_check.Rows.Count > 0)
                        {
                            string query_start = "";

                            DateTime start_time = DateTime.Parse(DateTime.Today.ToShortDateString());
                            DateTime end_time = DateTime.Parse(table_check.Rows[0][8].ToString());

                            int datetime_result = DateTime.Compare(start_time, end_time);

                            int status = 1;
                            bool success = false;

                            if (datetime_result <= 0)
                            {
                                status = 3;
                                success = true;
                            }

                            if (status == 3)
                                query_start = $"update task set t_emcode={session.user_id}, t_start='{DateTime.Today.ToShortDateString()}', t_status={status} where t_code={dropdown_select_start_task.Text}";
                            else
                                query_start = $"update task set t_emcode={session.user_id}, t_start='-', t_status={status} where t_code={dropdown_select_start_task.Text}";

                            OleDbCommand command_start = new OleDbCommand(query_start, db_connection.connection);

                            int result = command_start.ExecuteNonQuery();

                            db_connection.connection.Close();

                            if (result == 1)
                            {
                                load_all_data();

                                EmployeePage.SelectedTabPage = tabcontrol_task;

                                if (success)
                                    MessageBox.Show("تسک مورد نظر شروع شد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("تسک تا قبل از زمان اتمام، شروع نشد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("خطایی در هنگام شروع تسک رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            db_connection.connection.Close();

                            activity();
                            task_activity();
                            available_tasks();
                            task_comboboxs();

                            MessageBox.Show("تسکی برای شروع یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                            

                        db_connection.connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Task Start | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Task Start | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                db_connection.connection.Close();
            }
            else
                MessageBox.Show("تسکی برای شروع انتخاب نکرده اید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void task_stop()
        {
            if (dropdown_select_stop_task.SelectedIndex != -1)
            {
                try
                {
                    db_connection.connection.Open();

                    string query_check = $"select * from task where t_emcode={session.user_id} and t_level={session.user_level} and t_re={session.user_expertise} and t_status=3";

                    OleDbCommand command_check = new OleDbCommand(query_check, db_connection.connection);

                    OleDbDataAdapter adapter_check = new OleDbDataAdapter(command_check);

                    DataTable table_check = new DataTable();

                    try
                    {
                        adapter_check.Fill(table_check);

                        if (table_check.Rows.Count > 0)
                        {
                            DateTime start_time = DateTime.Parse(DateTime.Today.ToShortDateString());
                            DateTime end_time = DateTime.Parse(table_check.Rows[0][8].ToString());

                            int score = int.Parse(table_check.Rows[0][6].ToString());

                            int datetime_result = DateTime.Compare(start_time, end_time);

                            int status = 1;
                            bool success = false;

                            if (datetime_result <= 0)
                            {
                                status = 4;
                                success = true;
                            }

                            string query_stop = $"update task set t_status={status} where t_code={dropdown_select_stop_task.Text}";

                            OleDbCommand command_stop = new OleDbCommand(query_stop, db_connection.connection);

                            int result = command_stop.ExecuteNonQuery();

                            if (result == 1)
                            {
                                string query_score = $"update employee set e_score = e_score + {score} where e_code={session.user_id}";

                                OleDbCommand command_score = new OleDbCommand(query_score, db_connection.connection);

                                command_score.ExecuteNonQuery();

                                db_connection.connection.Close();

                                load_all_data();

                                EmployeePage.SelectedTabPage = tabcontrol_task;

                                if (success)
                                    MessageBox.Show($"تسک مورد نظر خاتمه یافت | امتیاز کسب شده : {table_check.Rows[0][6].ToString()}", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("تسک تا قبل از زمان اتمام، خاتمه پیدا نکرد", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("خطایی در هنگام شروع تسک رخ داد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            db_connection.connection.Close();

                            activity();
                            task_activity();
                            available_tasks();
                            task_comboboxs();

                            MessageBox.Show("تسکی برای شروع یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        db_connection.connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("خطایی در هنگام دریافت اطلاعات از دیتابیس رخ داد", "Task Stop | Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("خطایی در هنگام ارتباط با دیتابیس رخ داد", "Task Stop | Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                db_connection.connection.Close();
            }
            else
                MessageBox.Show("تسکی برای اتمام انتخاب نکرده اید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void fix_corrupt_date()
        {
            try
            {
                db_connection.connection.Open();

                try
                {
                    string query_fix = $"update employee_log set el_exitdate='خطا در ثبت' where el_exitdate='-' and el_ecode={session.user_id}";

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

            activity();

            task_activity();

            available_tasks();

            task_comboboxs();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            this.Text += $" | کد : {session.user_id}";

            EmployeePage.SelectedTabPage = tabcontrol_profile;

            fix_corrupt_date();

            load_all_data();

            set_enter_log();
        }

        private void checkbox_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_showpassword.Checked)
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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            edit_profile();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_all_data();

            MessageBox.Show("تمامی اطلاعات تازه سازی شدند", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_start_task_Click(object sender, EventArgs e)
        {
            task_start();
        }

        private void btn_stop_task_Click(object sender, EventArgs e)
        {
            task_stop();
        }

        private void Employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            set_exit_log();
        }
    }
}