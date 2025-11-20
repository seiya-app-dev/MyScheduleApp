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
using System.Security.Cryptography;
using MyScheduleApp.Models;

namespace MyScheduleApp.Forms
{
    public partial class NewUserAddForm : Form
    {
        private IUserService _userService;

        public NewUserAddForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;

            NewUserErrorLabel.Text = "";
            PasswordErrorLabel.Text = "";
            FullNameErrorLabel.Text = "";
            RoleErrorLabel.Text = "";
        }

        private void NewUserAddButton_Click(object sender, EventArgs e)
        {
            string userName = NewUserTextBox.Text;
            string password = PasswordTextBox.Text;
            string fullName = FullNameTextBox.Text;
            string? role = RoleComboBox.SelectedItem?.ToString();
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
            bool isValid =
                ValidateUserCase.ValidateAll(userName, password, fullName, out string? userNameError, out string? passwordError, out string? fullNameError);

            NewUserErrorLabel.Text = userNameError ?? "";
            PasswordErrorLabel.Text = passwordError ?? "";
            FullNameErrorLabel.Text = fullNameError ?? "";

            if (RoleComboBox.SelectedItem == null)
            {
                RoleErrorLabel.Text = "権限を選択してください。";
                exisitError = true;
            }
            else
            {
                RoleErrorLabel.Text = "";
            }

            if (exisitError == false)
            {
                DialogResult dialog = MessageBox.Show("この内容でユーザー登録しますか？", "スケジュール帳", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    User user = new User()
                    {
                        UserName = userName,
                        PasswordHash = passwordHash,
                        FullName = fullName,
                        RoleId = roleId,
                        Status = status,
                    };

                    bool success = _userService.AddUser(user);

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
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

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
