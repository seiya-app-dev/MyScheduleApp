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
    public partial class NewUserAddForm : Form
    {
        private string connectionString = @"Data Source = localhost; Initial Catalog = ScheduleAppDB_New; Integrated Security = True;";

        public NewUserAddForm()
        {
            InitializeComponent();
            RoleComboBox.Items.AddRange(new object[] { "管理者", "一般ユーザー", "ゲスト" });
            RoleComboBox.SelectedIndex = -1;
            UserNameErrorLabel.Text = "";
            PasswordErrorLabel.Text = "";
            FullNameErrorLabel.Text = "";
            RoleErrorLabel.Text = "";
        }

        private void NewUserAddButton_Click(object sender, EventArgs e)
        {
            string userName = NewUserTextBox.Text;
            string password = NewUserPasswordTextBox.Text;
            string fullName = NewUserFullNameTextBox.Text;
            string role = RoleComboBox.SelectedItem?.ToString();
            int roleID = 0;

            if(role == "管理者")
            {
                roleID = 1;
            } else if(role == "一般ユーザー") 
            {
                roleID = 2;
            }else if (role == " ゲスト")
            {
                roleID = 3;
            }
            bool status = StatusCheckBox.Checked;

            bool ExisitError = false;

            bool isValid = ValidateCase.ValidateAll(userName, password, fullName, out string userNameError, out string passwordError, out string fullNameError);

            UserNameErrorLabel.Text = userNameError ?? "";
            PasswordErrorLabel.Text = passwordError ?? "";
            FullNameErrorLabel.Text = fullNameError ?? "";

            if (RoleComboBox.SelectedItem == null)
            {
                RoleErrorLabel.Text = "権限を選択してください。";
                ExisitError = true;
            }
            else
            {
                RoleErrorLabel.Text = "";
            }

            if (ExisitError)
            {
                return;
            }

            DialogResult dialog = MessageBox.Show("この内容でユーザー登録しますか？", "スケジュール帳", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.No)
            {
                return;
            }
            
            string passwordHash = ComputeSha256Hash(password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Users(UserName, PasswordHash, FullName, RoleID, Status, IsDeleted) VALUES (@UserName, @PasswordHash, @FullName, @RoleID, @Status, 0)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.Parameters.AddWithValue("@Status", status);
                    
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ユーザー登録に失敗しました。");
                        this.DialogResult = DialogResult.Cancel;
                    }                    
                }
            }
        }

        private string ComputeSha256Hash(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
