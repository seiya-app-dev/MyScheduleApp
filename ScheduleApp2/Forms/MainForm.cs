using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleApp2.Forms //
{
    public partial class MainForm : Form
    {
        private int _selectedUserId;
        private string _selectedUserName;
        private string _selectedFullName;        
        private int _userId;
        private string _userName;
        private string _fullName;
        private int _roleID;

        public MainForm(int userId, string userName, string fullName, int roleID)
        {
            InitializeComponent();
            _userId = userId;
            _userName = userName;
            _fullName = fullName;
            _roleID = roleID;
        }

        string connectionString = @"Data Source = localhost; Initial Catalog = ScheduleAppDB_New; Integrated Security = True;";

        private void ScheduleApp2_Load(object sender, EventArgs e)
        {            
            for (int year = 2024; year <= 2026; year++)
            {
                YearComboBox.Items.Add(year);
            }

            for (int month = 1; month <= 12; month++)
            {
                MonthComboBox.Items.Add(month);
            }

            UserNameLinkLabel.Text = _userName;
            ScheduleListLabel.Text = $"{_fullName}さんのスケジュール一覧";
            UserLinkLabel.Text = _userName;

        } 
               
        private void ComboBoxYearOrMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YearComboBox.SelectedItem == null || MonthComboBox.SelectedItem == null)
            {
                DayComboBox.Enabled = false;
                return;
            }

            DayComboBox.SelectedIndexChanged -= DayComboBox_SelectedIndexChanged;
            DayComboBox.Enabled = true;

            LoadSchedule();            

            bool edit = EditSchedule();
            if (!edit)
            {
                DayComboBox.Enabled = false;
            }

            DayComboBox.SelectedIndexChanged += DayComboBox_SelectedIndexChanged;
        }

        private void LoadSchedule()
        {
            int year = int.Parse(YearComboBox.SelectedItem.ToString());
            int month = int.Parse(MonthComboBox.SelectedItem.ToString());

            DayComboBox.Items.Clear();
            int daysInMonth = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= daysInMonth; day++)
            {
                DayComboBox.Items.Add(day);
            }

            ScheduleList.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int targetUserId;                
                if(_selectedUserId !=0)
                {
                    targetUserId = _selectedUserId;                    
                }
                else
                {
                    targetUserId = _userId;                    
                }               
                
                string sqlQuery = "SELECT Date, Schedule FROM Schedules WHERE UserID = @UserID AND YEAR(Date) = @year AND MONTH(Date) = @month AND (IsDeleted = 0 OR IsDeleted IS NULL)";
                using (SqlCommand loadCommand = new SqlCommand(sqlQuery, connection))
                {
                    loadCommand.Parameters.AddWithValue("@UserID", targetUserId);
                    loadCommand.Parameters.AddWithValue("@year", year);
                    loadCommand.Parameters.AddWithValue("@month", month);

                    connection.Open();
                    SqlDataReader reader = loadCommand.ExecuteReader();
                    ScheduleList.Items.Clear();

                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        ListViewItem item = new ListViewItem(day.ToString());
                        item.SubItems.Add("");
                        ScheduleList.Items.Add(item);
                    }
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        string schedule = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        int day = date.Day;

                        ScheduleList.Items[day - 1].SubItems[1].Text = schedule;
                    }
                }                   
                connection.Close();                               
            }
        }

        private void DayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DayComboBox.SelectedItem == null)
            {
                return;
            }

            bool edit = EditSchedule();
            ScheduleTextBox.Enabled = edit;
            SaveButton.Enabled = edit;
            DeleteButton.Enabled = edit;
            ClearButton.Enabled = edit;
            RestoreButton.Enabled = edit;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (DayComboBox.SelectedItem == null)
            {
                MessageBox.Show("年、月、日をすべて選択してください。");
                return;
            }

            string newSchedule = ScheduleTextBox.Text;
            if (string.IsNullOrEmpty(newSchedule))
            {
                MessageBox.Show("予定が入力されていません。");
                LoadSchedule();
                return;
            }

            DateTime selectedDate = new DateTime(
                int.Parse(YearComboBox.SelectedItem.ToString()),
                int.Parse(MonthComboBox.SelectedItem.ToString()),
                int.Parse(DayComboBox.SelectedItem.ToString())
                );

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int targetUserId;
                if (_selectedUserId != 0)
                {
                    targetUserId = _selectedUserId;
                }
                else
                {
                    targetUserId = _userId;
                }

                string selectQuery = "SELECT [Schedule] FROM Schedules WHERE [Date] = @Date AND UserID = @UserID AND IsDeleted = 0";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Date", selectedDate);
                    selectCommand.Parameters.AddWithValue("@UserID", targetUserId);

                    object result = selectCommand.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string exisiting = result.ToString();
                        string update = exisiting + " " + newSchedule;

                        string updateQuery = "UPDATE Schedules SET [Schedule] = @Schedule WHERE [Date] = @Date AND UserID = @UserID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@UserID", targetUserId);
                        updateCommand.Parameters.AddWithValue("@Schedule", update);
                        updateCommand.Parameters.AddWithValue("@Date", selectedDate);
                        updateCommand.ExecuteNonQuery();

                        MessageBox.Show("予定を更新しました。");
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Schedules ([UserID], [Date], [Schedule]) VALUES (@UserID, @Date, @Schedule)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@UserID", targetUserId);
                        insertCommand.Parameters.AddWithValue("@Date", selectedDate);
                        insertCommand.Parameters.AddWithValue("@Schedule", newSchedule);
                        insertCommand.ExecuteNonQuery();

                        MessageBox.Show("新しい予定を登録しました。");
                    }
                }
                AddLog(_userId, "予定登録", selectedDate, targetUserId);

            }
            LoadSchedule();
            ComboBoxYearOrMonth_SelectedIndexChanged(null, null);
            DayComboBox.SelectedIndex = -1;
            ScheduleTextBox.Text = "";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DayComboBox.SelectedItem == null)
            {
                MessageBox.Show("年、月、日をすべて選択してください。");
                return;
            }

            DateTime selectedDate = new DateTime(
                int.Parse(YearComboBox.SelectedItem.ToString()),
                int.Parse(MonthComboBox.SelectedItem.ToString()),
                int.Parse(DayComboBox.SelectedItem.ToString())
                );

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int targetUserId;
                if (_selectedUserId != 0)
                {
                    targetUserId = _selectedUserId;
                }
                else
                {
                    targetUserId = _userId;
                }

                string selectQuery = "SELECT [Schedule] FROM Schedules WHERE [Date] = @Date AND UserID = @UserID";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@UserID", targetUserId);
                selectCommand.Parameters.AddWithValue("@Date", selectedDate);

                object result = selectCommand.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show("既存の予定がありません。");
                    return;
                }

                string message = $"{selectedDate:yyyy年MM月dd日}の予定を削除してもよろしいですか？";
                DialogResult dialog = MessageBox.Show(message, "スケジュール帳", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    string deleteQuery = "UPDATE Schedules SET IsDeleted = 1 WHERE [Date] = @Date AND UserID = @UserID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@UserID", targetUserId);
                    deleteCommand.Parameters.AddWithValue("@Date", selectedDate);
                    deleteCommand.ExecuteNonQuery();

                    MessageBox.Show("予定を削除しました。");
                    LoadSchedule();

                }

                AddLog(_userId, "予定削除", selectedDate, targetUserId);

                connection.Close();

                ComboBoxYearOrMonth_SelectedIndexChanged(null, null);                
                ScheduleTextBox.Text = "";
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("入力内容をすべてクリアしますか？", "スケジュール帳", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                YearComboBox.SelectedIndex = -1;
                MonthComboBox.SelectedIndex = -1;
                DayComboBox.SelectedIndex = -1;

                ScheduleTextBox.Enabled = false;
                SaveButton.Enabled = false;
                DeleteButton.Enabled = false;
                ClearButton.Enabled = false;
                RestoreButton.Enabled = false;
                ScheduleList.Items.Clear();
                ScheduleTextBox.Text = "";
                ScheduleTextBox.Enabled = false;

                MessageBox.Show("入力内容をクリアしました");
            }
        }

        private void UserNameLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = "アプリからログアウトします。よろしいですか？";
            DialogResult dialog = MessageBox.Show(message, "スケジュール帳", MessageBoxButtons.YesNo);
           
            if (dialog == DialogResult.Yes)
            {
                this .Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                AddLog(_userId, "ログアウト");

            }
        }

        private void LoadUserList(object sender, EventArgs e)
        {
            LoadUserListView();
        }

        private void LoadUserListView()
        {
            UserListView.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string SqlQuery = "SELECT u.UserID, u.UserName, u.FullName, r.Role, u.Status FROM Users u INNER JOIN Roles r ON u.RoleID = r.RoleID ";

                int targetUserId;
                if (_selectedUserId != 0)
                {
                    targetUserId = _selectedUserId;
                }
                else
                {
                    targetUserId = _userId;
                }

                SqlCommand command = new SqlCommand(SqlQuery, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["UserID"].ToString());
                        item.SubItems.Add((reader["UserName"].ToString()));
                        item.SubItems.Add((reader["FullName"].ToString()));
                        item.SubItems.Add((reader["Role"].ToString()));
                        
                        bool IsActive = Convert.ToBoolean(reader["Status"]);
                        string statisText = IsActive ? "有効" : "無効";
                        item.SubItems.Add(statisText);

                        UserListView.Items.Add(item);
                    }
                    connection.Close();
                }
            }
        }

        private void UserListView_MouseClick(object sender, MouseEventArgs e)
        {
            UserListVIewSelected();
        }
               
        private void UserListVIewSelected()
        {
            if (UserListView.SelectedItems.Count > 0)
            {
                int selectedUserId = int.Parse(UserListView.SelectedItems[0].SubItems[0].Text);

                if (_roleID == 1 )
                {
                    ScheduleEditButton.Enabled = true;
                    NewUserAddButton.Enabled = true;
                    EditButton.Enabled = true;
                }
                else if(selectedUserId == _userId)
                {
                    ScheduleEditButton.Enabled = true;
                    NewUserAddButton.Enabled = false;
                    EditButton.Enabled = true;
                }
                else
                {
                    ScheduleEditButton.Enabled = true;
                    NewUserAddButton.Enabled = false;
                    EditButton.Enabled = false;
                }
            }
            else
            {
                ScheduleEditButton.Enabled = true;
                NewUserAddButton.Enabled = false;
                EditButton.Enabled = false;
            }
        }

        private void ScheduleEditButton_Click(object sender, EventArgs e)
        {
            int selecteUserId = int.Parse(UserListView.SelectedItems[0].SubItems[0].Text);
            string selectedUserName = UserListView.SelectedItems[0].SubItems[1].Text;
            string selectedFullName = UserListView.SelectedItems[0].SubItems[2].Text;
            string selectedStatus = UserListView.SelectedItems[0].SubItems[4].Text;

            _selectedUserId = selecteUserId;
            _selectedUserName = selectedUserName;
            _selectedFullName = selectedFullName;

            if (selectedStatus == "無効")
            {
                MessageBox.Show("無効なユーザーのため、スケジュール編集できません。", "スケジュール帳", MessageBoxButtons.OK);
                return;
            }

            MainFormTab.SelectedTab = ScheduleListTab;
            ScheduleListLabel.Text = $"{_selectedFullName}さんのスケジュール一覧";
            YearComboBox.SelectedIndex = -1;
            MonthComboBox.SelectedIndex = -1;
            DayComboBox.SelectedIndex = -1;
            ScheduleList.Items.Clear();

            ScheduleTextBox.Enabled = false;
            SaveButton.Enabled = false;
            DeleteButton.Enabled = false;
            ClearButton.Enabled = false;
            RestoreButton.Enabled = false;
            ScheduleList.Items.Clear();
            ScheduleTextBox.Text = "";            
                        
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if(UserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("編集するユーザーを選択してください。", "スケジュール帳", MessageBoxButtons.OK);
                return;
            }

            int selectedID = int.Parse(UserListView.SelectedItems[0].Text);           
            
            using (UserEditForm editForm = new UserEditForm(selectedID))
            {
                if(editForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("ユーザー情報を更新しました。");
                    LoadUserListView();

                    AddLog(_userId, "ユーザー編集", DateTime.Now, selectedID);

                }
            }
        }

        private void NewUserAddButton_Click(object sender, EventArgs e)
        {
            using (NewUserAddForm addForm = new NewUserAddForm())
            {
                if(addForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("新しいユーザーを登録しました。");
                    LoadUserListView();

                    AddLog(_userId, "新規ユーザー追加");

                }
            }
        }   
                
        private bool EditSchedule()
        {
            if (_roleID == 1 || _roleID == 2)
            {
                return true;
            }
            else if(_roleID == 3 && _selectedUserId == 0)
            {
                return true;
            }
            else if(_roleID == 3 && _selectedUserId == _userId)
            {
                return true;
            }
            return false;
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            if(DayComboBox.SelectedItem == null)
            {
                MessageBox.Show("年、月、日をすべて選択してください。");
                return;
            }

            DateTime selectedDate = new DateTime(
                int.Parse(YearComboBox.SelectedItem.ToString()),
                int.Parse(MonthComboBox.SelectedItem.ToString()),
                int.Parse(DayComboBox.SelectedItem.ToString())
                );

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int targetUserId;
                if (_selectedUserId != 0)
                {
                    targetUserId = _selectedUserId;
                }
                else
                {
                    targetUserId = _userId;
                }

                string NotRestoreQuery = "SELECT COUNT(*) FROM Schedules WHERE Date = @Date AND UserID = @UserID AND IsDeleted = 1";

                using (SqlCommand NotRestoreCommand = new SqlCommand(NotRestoreQuery, connection))
                {
                    NotRestoreCommand.Parameters.AddWithValue("@UserID", targetUserId);
                    NotRestoreCommand.Parameters.AddWithValue("@Date", selectedDate);
                    int NoRestoreCount = (int)NotRestoreCommand.ExecuteScalar();
                    if (NoRestoreCount == 0)
                    {
                        MessageBox.Show("削除済みの予定がありません。");
                        return;
                    }
                }

                string checkQuery = "SELECT COUNT(*) FROM Schedules WHERE Date = @Date AND UserID = @UserID AND IsDeleted = 0";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserID", targetUserId);
                    checkCommand.Parameters.AddWithValue("@Date", selectedDate);
                    int exisitCount = (int)checkCommand.ExecuteScalar();
                    if (exisitCount > 0)
                    {
                        MessageBox.Show("同じ日付に有効な予定が存在するため、復元できません。");
                        return;
                    }
                }

                string message = $"{selectedDate:yyyy年MM月dd日} の予定を復元しますか？";
                DialogResult result = MessageBox.Show(message, "スケジュール帳", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string restoreQuery = "UPDATE Schedules SET IsDeleted = 0 WHERE Date = @Date AND UserID = @UserID";

                    using (SqlCommand restoreCommand = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCommand.Parameters.AddWithValue("@UserID", targetUserId);
                        restoreCommand.Parameters.AddWithValue("@Date", selectedDate);
                        restoreCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("予定を復元しました");

                    ComboBoxYearOrMonth_SelectedIndexChanged(null, null);                    
                    ScheduleTextBox.Text = "";

                    AddLog(_userId, "予定復元", selectedDate, targetUserId);

                }

                LoadSchedule();
            }
        }

        private void AddLog(int userId, string action, DateTime? actionDate = null, int? targetUserId = null)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string query = "INSERT INTO Logs (UserID, Action, ActionDate, TargetUserID) VALUES (@UserID, @Action, @ActionDate, @TargetUserID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Action", action);
                    command.Parameters.AddWithValue("@ActionDate", (object)actionDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TargetUserID", (object)targetUserId ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
        }

        private void LogListLoad()
        {
            LogListView.Items.Clear();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT LogID, UserID, Action, ActionDate, CreatedAt, TargetUserID FROM Logs ORDER BY LogID DESC";

                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["LogID"].ToString());
                            item.SubItems.Add(reader["UserID"].ToString());
                            item.SubItems.Add(reader["Action"].ToString());
                            item.SubItems.Add(reader["ActionDate"].ToString());
                            item.SubItems.Add(reader["CreatedAt"].ToString());
                            item.SubItems.Add(reader["TargetUserID"].ToString());
                            LogListView.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void MainFormTab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage == LogListTab)
            {
                if (_roleID != 1)
                {
                    MessageBox.Show("管理者権限が必要です。", "スケジュール帳");
                    e.Cancel = true;
                    return;
                }

                LogListLoad();
            }
            
            
        }
    }
}
