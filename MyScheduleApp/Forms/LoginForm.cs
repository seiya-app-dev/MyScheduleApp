using MyScheduleApp.Models;
using MyScheduleApp.Repositories;
using MyScheduleApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using MyScheduleApp.Utility;

namespace MyScheduleApp.Forms
{
    public partial class LoginForm : Form
    {
        private ILoginService _loginService;
        private IUserService _userService;
        private IScheduleService _scheduleService;        
        private ILogService _logService;

        public LoginForm(ILoginService loginService, ILogService logService, IUserService userService, IScheduleService scheduleService)
        {
            InitializeComponent();
            _loginService = loginService;
            _logService = logService;
            _userService = userService;
            _scheduleService = scheduleService;

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text;
                string password = PasswordTextBox.Text;

                string PasswordHash = GetHash(password);

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("ユーザー名とパスワードを入力してください。");
                    return;
                }

                User? user = _loginService.GetUser(userName, PasswordHash);

                if (user != null)
                {
                    MessageBox.Show($"ようこそ、{user.FullName}さん");
                    MainForm main = new MainForm(user, _scheduleService, _userService, _logService);
                    main.Show();
                    this.Hide();

                    bool success = _logService.AddLog(new Log
                    {
                        UserId = user.UserId,
                        ActionId = 1,
                    });
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("データベースに接続できませんでした。");
            }
            catch(Exception ex)
            {
                Logger.Log($"LoginForm error: {ex}");
                MessageBox.Show("ログイン中にエラーが発生しました。");
            }
            
        }

        private string GetHash(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
