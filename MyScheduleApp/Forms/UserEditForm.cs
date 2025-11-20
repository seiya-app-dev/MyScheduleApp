using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyScheduleApp.Repositories;
using MyScheduleApp.Services;
using System.Configuration;
using System.Security.Cryptography;
using MyScheduleApp.Models;

namespace MyScheduleApp.Forms
{
    public partial class UserEditForm : Form
    {
        private int _userId;
        private IUserService _userService;

        public UserEditForm(int userId, IUserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;           
            
            LoadUser();

            NewUserErrorLabel.Text = "";
            PasswordErrorLabel.Text = "";
            FullNameErrorLabel.Text = "";
            RoleErrorLabel.Text = "";
            RoleComboBox.Items.AddRange(new object[] { "管理者", "一般ユーザー", "ゲスト" });
        }

        private void LoadUser()
        {
            PasswordTextBox.Text = "********";

            User user = _userService.GetUserById(_userId);
            
            UserTextBox.Text = user.UserName;
            FullNameTextBox.Text = user.FullName;
            RoleComboBox.Text = user.RoleName;
            StatusCheckBox.Checked = user.Status;

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string userName = UserTextBox.Text;
            string password = PasswordTextBox.Text;
            string fullName = FullNameTextBox.Text;
            string role = RoleComboBox.Text;
            bool status = StatusCheckBox.Checked;

            string passwordHash = GetHash(password);

            int roleId = 0;

            if (role == "管理者")
            {
                roleId = 1;
            }
            else if (role == "一般ユーザー")
            {
                roleId = 2;
            }
            else if (role == "ゲスト")
            {
                roleId = 3;
            }

            bool exisitError = false;

            if (exisitError == false)
            {
                DialogResult dialog = MessageBox.Show("この内容で更新しますか？", "スケジュール帳", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    User user = new User()
                    {
                        UserId = _userId,
                        UserName = userName,
                        PasswordHash = passwordHash,
                        FullName = fullName,
                        RoleId = roleId,
                        Status = status,
                    };

                    bool success = _userService.UpdateUser(user);

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ユーザーの登録に失敗しました。");
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else if (dialog == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private string GetHash(string password)
        {
            using(SHA256 sHA256 = SHA256.Create())
            {
                byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
