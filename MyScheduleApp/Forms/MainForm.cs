using Microsoft.VisualBasic.ApplicationServices;
using MyScheduleApp.Models;
using MyScheduleApp.Repositories;
using MyScheduleApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using AppUser = MyScheduleApp.Models.User;
using Microsoft.Data.SqlClient;
using MyScheduleApp.Utility;

namespace MyScheduleApp.Forms
{
    public partial class MainForm : Form
    {
        private int _selectedUserId;
        private string _selectedUserName = "";
        private string _selectedFullName = "";
        private int _userId;
        private string _userName;
        private string _fullName;
        private int _roleID;

        private IScheduleService _scheduleService = null!;
        private IUserService _userService = null!;
        private ILogService _logService = null!;
        private ILoginService _loginService = null!;

        public MainForm(AppUser user, IScheduleService schedule, IUserService userService, ILogService logService)
        {
            InitializeComponent();

            _userId = user.UserId;
            _userName = user.UserName;
            _fullName = user.FullName;
            _roleID = user.RoleId;

            _logService = logService;
            _scheduleService = schedule;
            _userService = userService;

            DayComboBox.Enabled = false;
            ScheduleTextBox.Enabled = false;
            ScheduleAddButton.Enabled = false;
            ScheduleDeleteButton.Enabled = false;
            ClearButton.Enabled = false;
            RestoreButton.Enabled = false;

            for (int year = 2024; year <= 2026; year++)
            {
                YearComboBox.Items.Add(year);
            }

            for (int month = 1; month <= 12; month++)
            {
                MonthComboBox.Items.Add(month);
            }

            UserName.Text = _userName;
            ScheduleEditName.Text = $"{_fullName}さんのスケジュール一覧";
            LoginUser.Text = _userName;

            LoadUserList();
        }

        private void LoadUserList()
        {
            try
            {
                UserList.Items.Clear();

                List<AppUser> GetUserList = _userService.GetUsers();

                foreach (AppUser user in GetUserList)
                {
                    ListViewItem item = new ListViewItem(user.UserId.ToString());
                    item.SubItems.Add(user.UserName);
                    item.SubItems.Add(user.FullName);
                    item.SubItems.Add(user.RoleName);

                    bool IsActive = Convert.ToBoolean(user.Status);
                    string statisText = IsActive ? "有効" : "無効";
                    item.SubItems.Add(statisText);

                    UserList.Items.Add(item);
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("データベースに接続できません。");
            }
            catch (Exception ex)
            {
                Logger.Log($"MainForm error: {ex}");
                MessageBox.Show("ロード中にエラーが発生しました。");
            }
            
        }

        private void ComboBoxYearOrMonth_SelectedIndexChanged(object? sender, EventArgs? e)
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

        private void DayComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (DayComboBox.SelectedItem == null)
            {
                return;
            }

            bool edit = EditSchedule();
            ScheduleTextBox.Enabled = edit;
            ScheduleAddButton.Enabled = edit;
            ScheduleDeleteButton.Enabled = edit;
            ClearButton.Enabled = edit;
            RestoreButton.Enabled = edit;
        }

        private bool EditSchedule()
        {
            if (_roleID == 1 || _roleID == 2)
            {
                return true;
            }
            else if (_roleID == 3 && _selectedUserId == 0)
            {
                return true;
            }
            else if (_roleID == 3 && _selectedUserId == _userId)
            {
                return true;
            }
            return false;
        }

        private int TargetUser()
        {
            if (_selectedUserId != 0)
            {
                return _selectedUserId;
            }
            return _userId;
        }

        private void LoadSchedule()
        {
            try
            {
                DayComboBox.Items.Clear();
                ScheduleList.Items.Clear();

                int year = int.Parse(YearComboBox.SelectedItem?.ToString() ?? "");
                int month = int.Parse(MonthComboBox.SelectedItem?.ToString() ?? "");

                int targetUserId = TargetUser();

                List<Schedule> list = _scheduleService.GetSchedules(targetUserId, year, month);

                int daysInMonth = DateTime.DaysInMonth(year, month);

                for (int day = 1; day <= daysInMonth; day++)
                {
                    DayComboBox.Items.Add(day.ToString());

                    ListViewItem item = new ListViewItem(day.ToString());
                    item.SubItems.Add("");
                    ScheduleList.Items.Add(item);
                }
                foreach (Schedule schedule in list)
                {
                    int day = schedule.Date.Day;
                    string detail = schedule.Details ?? "";

                    ScheduleList.Items[day - 1].SubItems[1].Text = detail;
                }

                DayComboBox.SelectedIndex = -1;
            }
            catch (SqlException)
            {
                MessageBox.Show("データベースに接続できません。");
            }
            catch(Exception ex)
            {
                Logger.Log($"MainForm error: {ex}");
                MessageBox.Show("ロード中にエラーが発生しました");
            }           
        }

        private void UserName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("アプリからログアウトします。よろしいですか？", "スケジュール帳", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm(_loginService, _logService, _userService, _scheduleService);
                loginForm.Show();

                bool log = _logService.AddLog(new Log
                {
                    UserId = _userId,
                    ActionId = 2
                });
            }
        }

        private void ScheduleAddButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (DayComboBox.SelectedItem == null)
                {
                    MessageBox.Show("年、月、日をすべて選択して下さい。");
                    return;
                }

                if (string.IsNullOrEmpty(ScheduleTextBox.Text))
                {
                    MessageBox.Show("予定を入力してください。");
                    return;
                }

                DateTime selectedDate = new DateTime(
                     int.Parse(YearComboBox.Text.ToString()),
                     int.Parse(MonthComboBox.Text.ToString()),
                     int.Parse(DayComboBox.Text.ToString()));

                string newSchedule = ScheduleTextBox.Text;
                int targetUserId = TargetUser();

                DialogResult result = MessageBox.Show($"{selectedDate:yyyy年MM月dd日}に予定を登録します。よろしいですか？", "スケジュール帳", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    _scheduleService.AddSchedule(targetUserId, selectedDate, newSchedule);

                    MessageBox.Show("新しい予定を登録しました。");

                    LoadSchedule();
                    ComboBoxYearOrMonth_SelectedIndexChanged(null, null);
                    DayComboBox.SelectedIndex = -1;
                    ScheduleTextBox.Text = "";

                    bool log = _logService.AddLog(new Log
                    {
                        UserId = _userId,
                        TargetUserId = targetUserId,
                        ActionId = 3
                    });
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("データベースに接続できません");
            }
            catch(Exception ex)
            {
                Logger.Log($"MainForm error: {ex}");
                MessageBox.Show("保存中にエラーが発生しました。");
            }
            
        }

        private void ScheduleDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DayComboBox.SelectedItem == null)
                {
                    MessageBox.Show("年、月、日をすべて選択して下さい。");
                    return;
                }

                DateTime selectedDate = new DateTime(
                    int.Parse(YearComboBox.Text.ToString()),
                    int.Parse(MonthComboBox.Text.ToString()),
                    int.Parse(DayComboBox.Text.ToString()));

                int targetUserId = TargetUser();

                DialogResult result = MessageBox.Show($"{selectedDate:yyyy年MM月dd日}の予定を削除します。よろしいですか？", "スケジュール帳", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    _scheduleService.DeleteSchedule(targetUserId, selectedDate);
                    MessageBox.Show("予定を削除しました。");

                    LoadSchedule();
                    ComboBoxYearOrMonth_SelectedIndexChanged(null, null);
                    DayComboBox.SelectedIndex = -1;
                    ScheduleTextBox.Text = "";

                    bool log = _logService.AddLog(new Log
                    {
                        UserId = _userId,
                        TargetUserId = targetUserId,
                        ActionId = 4
                    });
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("データベースに接続できません");
            }
            catch (Exception ex)
            {
                Logger.Log($"MainForm error: {ex}");
                MessageBox.Show("削除中にエラーが発生しました。");
            }           
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            string message = "入力内容をすべてクリアしますか？";
            DialogResult dialog = MessageBox.Show(message, "スケジュール帳", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                YearComboBox.SelectedIndex = -1;
                MonthComboBox.SelectedIndex = -1;
                DayComboBox.SelectedIndex = -1;
                ScheduleTextBox.Text = "";

                ScheduleList.Items.Clear();
                ScheduleTextBox.Enabled = false;
                ScheduleAddButton.Enabled = false;
                ScheduleDeleteButton.Enabled = false;
                RestoreButton.Enabled = false;
                ClearButton.Enabled = false;

                MessageBox.Show("入力内容をクリアしました。");
            }
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (YearComboBox.SelectedItem == null || MonthComboBox.SelectedItem == null || DayComboBox.SelectedItem == null)
                {
                    MessageBox.Show("年、月、日をすべて選択して下さい。");
                    return;
                }

                DateTime selectedDate = new DateTime(
                    int.Parse(YearComboBox.Text.ToString()),
                    int.Parse(MonthComboBox.Text.ToString()),
                    int.Parse(DayComboBox.Text.ToString())
                    );

                int targetUserId = TargetUser();

                DialogResult result = MessageBox.Show($"{selectedDate:yyyy年MM月dd日}の予定を復元します。よろしいですか？", "スケジュール帳", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int restoreCount = _scheduleService.RestoreSchedule(targetUserId, selectedDate);
                    if (restoreCount == 0)
                    {
                        MessageBox.Show("復元できる予定がありません。");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("予定を復元しました");

                        LoadSchedule();
                        ComboBoxYearOrMonth_SelectedIndexChanged(null, null);
                        DayComboBox.SelectedIndex = -1;
                        ScheduleTextBox.Text = "";

                        bool log = _logService.AddLog(new Log
                        {
                        UserId = _userId,
                        TargetUserId = targetUserId,
                        ActionId = 5
                        });
                    }
                }           
            }
            catch(SqlException)
            {
                MessageBox.Show("データベースに接続できません");
            }
            catch(Exception ex)
            {
                Logger.Log($"MainForm error : {ex}");
                MessageBox.Show("復元中にエラーが発生しました。");
            }
        }

        private void ScheduleEditButton_Click(object sender, EventArgs e)
        {
            int selecteUserId = int.Parse(UserList.SelectedItems[0].SubItems[0].Text);
            string selectedUserName = UserList.SelectedItems[0].SubItems[1].Text;
            string selectedFullName = UserList.SelectedItems[0].SubItems[2].Text;
            string selectedStatus = UserList.SelectedItems[0].SubItems[4].Text;

            _selectedUserId = selecteUserId;
            _selectedUserName = selectedUserName;
            _selectedFullName = selectedFullName;

            MainFormTab.SelectedTab = ScheduleTab;
            ScheduleEditName.Text = $"{_selectedFullName}さんのスケジュール一覧";
            YearComboBox.SelectedIndex = -1;
            MonthComboBox.SelectedIndex = -1;
            DayComboBox.SelectedIndex = -1;
            ScheduleList.Items.Clear();

            ScheduleTextBox.Enabled = false;
            ScheduleAddButton.Enabled = false;
            ScheduleDeleteButton.Enabled = false;
            ClearButton.Enabled = false;
            RestoreButton.Enabled = false;
            ScheduleList.Items.Clear();
            ScheduleTextBox.Text = "";
        }

        private void NewUserAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (NewUserAddForm form = new NewUserAddForm(_userService))
                {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("新しいユーザーを登録しました。");

                        LoadUserList();

                        bool log = _logService.AddLog(new Log
                        {
                        UserId = _userId,                    
                        ActionId = 6
                        });
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("データベースに接続できません");
            }
            catch(Exception ex)
            {
                Logger.Log($"MainForm error : {ex}");
                MessageBox.Show("登録中にエラーが発生しました。");
            }
            
        }

        private void UserEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                int selecteUserId = int.Parse(UserList.SelectedItems[0].SubItems[0].Text);

                _selectedUserId = selecteUserId;

                using (UserEditForm form = new UserEditForm(selecteUserId, _userService))
                {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("ユーザー情報を更新しました。");

                        LoadUserList();

                        bool log = _logService.AddLog(new Log
                        {
                        UserId = _userId,
                        TargetUserId = selecteUserId,
                        ActionId = 7
                        });
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("データベースに接続できません");
            }
            catch (Exception ex)
            {
                Logger.Log($"MainForm error : {ex}");
                MessageBox.Show("更新中にエラーが発生しました。");
            }            
        }

        private void UserList_MouseClick(object sender, MouseEventArgs e)
        {
            UserListSelected();
        }

        private void UserListSelected()
        {
            if (UserList.SelectedItems.Count > 0)
            {
                int selectedUserId = int.Parse(UserList.SelectedItems[0].SubItems[0].Text);

                if (_roleID == 1)
                {
                    ScheduleEditButton.Enabled = true;
                    NewUserAddButton.Enabled = true;
                    UserEditButton.Enabled = true;
                }
                else if (selectedUserId == _userId)
                {
                    ScheduleEditButton.Enabled = true;
                    NewUserAddButton.Enabled = false;
                    UserEditButton.Enabled = true;
                }
                else
                {
                    ScheduleEditButton.Enabled = true;
                    NewUserAddButton.Enabled = false;
                    UserEditButton.Enabled = false;
                }
            }
            else
            {
                ScheduleEditButton.Enabled = true;
                NewUserAddButton.Enabled = false;
                UserEditButton.Enabled = false;
            }
        }

        public void LogListLoad()
        {
            try
            {
                List<Log> GetLog = _logService.GetLogs();

                foreach(Log log in GetLog)
                {
                    ListViewItem item = new ListViewItem(log.LogId.ToString());
                    item.SubItems.Add(log.UserName);
                    item.SubItems.Add(log.TargetUserName);
                    item.SubItems.Add(log.ActionName);
                    item.SubItems.Add(log.ActionDate.ToString("yyyy/MM/dd HH:mm"));
                    LogList.Items.Add(item);
                }

            }
            catch(SqlException)
            {
                MessageBox.Show("データベースに接続できません");
            }
            catch (Exception ex)
            {
                Logger.Log($"MainForm error : {ex}");
                MessageBox.Show("ログのロード中にエラーが発生しました。");
            }
        }

        private void MainFormTab_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (e.TabPage == LogListTab)
            {
                if (_roleID != 1)
                {
                    MessageBox.Show("管理者権限が必要です。", "スケジュール帳");
                    e.Cancel = true;
                    return;
                }

                LogList.Items.Clear();
                LogListLoad();
            }
        }
    }
}
