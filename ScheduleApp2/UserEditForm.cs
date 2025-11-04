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

namespace ScheduleApp2
{
    public partial class UserEditForm : Form
    {
        private int _userId;        
        private string connectionString = @"Data Source = localhost; Initial Catalog = ScheduleAppDB_New; Integrated Security = True;";

        public UserEditForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            RoleComboBox.Items.AddRange(new object[] { "管理者", "一般ユーザー", "ゲスト" });
            RoleComboBox.SelectedIndex = -1;

            LoadUserInfo();            
            UserNameErrorLabel.Text = "";
            PasswordErrorLabel.Text = "";
            FullNameErrorLabel.Text = "";
            RoleErrorLabel.Text = "";
        }

        private void LoadUserInfo()
        {
            UserPasswordTextBox.Text = "********";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT u.UserName, u.FullName, r.RoleName, u.Status FROM Users AS u LEFT JOIN Roles AS r ON u.RoleID = r.RoleID WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", _userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            UserNameTextBox.Text = reader["UserName"].ToString();                            
                            UserFullNameTextBox.Text = reader["FullName"].ToString();
                            
                            
                            string roleName = reader["RoleName"].ToString();
                            RoleComboBox.SelectedItem = roleName;

                            bool status = Convert.ToBoolean(reader["Status"]);
                            StatusCheckBox.Checked = status;
                        }
                    }
                }
            }
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserEditAddButton_Click(object sender, EventArgs e)
        {
            string userName = UserNameTextBox.Text;
            string fullName = UserFullNameTextBox.Text;
            string roleName = RoleComboBox.SelectedItem.ToString();
            bool status = StatusCheckBox.Checked;

            string newPassword = UserPasswordTextBox.Text;
            string newPasswordHash = null;

            if(!string.IsNullOrEmpty(newPassword) && newPassword != "********")
            {
                newPasswordHash = HashPassword(newPassword);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string roleQuery = "SELECT RoleID FROM Roles WHERE RoleName = @RoleName";
                int roleId;

                using (SqlCommand roleCommand = new SqlCommand(roleQuery, connection))
                {
                    roleCommand.Parameters.AddWithValue("@RoleName", roleName);
                    roleId = (int)roleCommand.ExecuteScalar();
                }

                string updateQuery;
                
                if(!string.IsNullOrEmpty(newPassword))
                {
                    updateQuery = "UPDATE Users SET UserName = @UserName, FullName = @FullName, RoleID = @RoleID, Status =@Status, PasswordHash = @PasswordHash WHERE UserID = @UserID";
                }
                else
                {
                    updateQuery = "UPDATE Users SET UserName = @UserName, FullName = @FullName, RoleID = @RoleID, Status =@Status WHERE UserID = @UserID";
                }

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@RoleID", roleId);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@UserID", _userId);

                    if (newPasswordHash != null)
                    {
                        command.Parameters.AddWithValue("@PasswordHash", newPasswordHash);
                    }

                    command.ExecuteNonQuery();

                }              
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private string HashPassword(string password)
        {
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
    }
}
