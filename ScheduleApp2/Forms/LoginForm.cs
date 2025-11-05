using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleApp2.Forms
{
    public partial class LoginForm : Form
    {
        string connectionString = @"Data Source = localhost; Initial Catalog = ScheduleAppDB_New; Integrated Security = True;";


        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = UserNameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("ユーザー名またはパスワードが正しくありません。");
                return;
            }

            string passwordHash = ComputeSha256Hash(password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string SqlQuery = "SELECT UserID, FullName, RoleID, Status FROM Users WHERE UserName = @UserName AND PasswordHash = @PasswordHash AND IsDeleted = 0";
                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userID = reader.GetInt32(0);
                            string fullName = reader.GetString(1);
                            int roleID = reader.GetInt32(2);
                            bool status = reader.GetBoolean(3);

                            if (!status)
                            {
                                MessageBox.Show("このユーザーは無効化されています。");
                                return;
                            }

                            MessageBox.Show($"ようこそ {fullName}さん");

                            MainForm mainForm = new MainForm(userID, userName, fullName, roleID);
                            mainForm.Show();
                            this.Hide();

                            AddLog(userID, "ログイン");

                        }
                        else
                        {
                            MessageBox.Show("ユーザー名またはパスワードが間違っています。");
                        }
                    }
                }
            }
        }

        private string ComputeSha256Hash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void AddLog(int userId, string action, DateTime? actionDate = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO Logs (UserID, Action, ActionDate) VALUES (@UserID, @Action, @ActionDate)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Action", action);
                    command.Parameters.AddWithValue("@ActionDate", (object)actionDate ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
        }
    }
 }
