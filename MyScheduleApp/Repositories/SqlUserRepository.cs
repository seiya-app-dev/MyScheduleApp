using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using MyScheduleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppUser = MyScheduleApp.Models.User;

namespace MyScheduleApp.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private string _connectionString;

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<AppUser> GetUserList()
        {
            List<AppUser> users = new List<AppUser>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query =
                    "SELECT u.UserID, u.UserName, u.FullName, r.RoleName, u.Status " +
                    "FROM Users u " +
                    "INNER JOIN Roles r ON u.RoleId = r.RoleId " +
                    "ORDER BY u.UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AppUser u = new AppUser();
                            u.UserId = reader.GetInt32(0);
                            u.UserName = reader.GetString(1);
                            u.FullName = reader.GetString(2);
                            u.RoleName = reader.GetString(3);
                            u.Status = reader.GetBoolean(4);

                            users.Add(u);
                        }
                    }
                }
            }
            return users;
        }

        public int AddUser(AppUser user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = "INSERT INTO " +
                    "Users(UserName, PasswordHash, FullName, RoleID, Status, IsDeleted) " +
                    "Values (@UserName, @PasswordHash, @FullName, @RoleID, @Status, 0) ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@RoleID", user.RoleId);
                    cmd.Parameters.AddWithValue("@Status", user.Status);

                    int count = cmd.ExecuteNonQuery();
                    return count;

                }
            }
        }

        public AppUser GetUserById(int userId)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT u.UserName, u.FullName, r.RoleName, u.Status " +
                    "FROM Users u INNER JOIN Roles r ON u.RoleID = r.RoleID " +
                    "WHERE UserID = @UserID";

                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AppUser
                            {
                                UserName = reader.GetString(0),
                                FullName = reader.GetString(1),
                                RoleName = reader.GetString(2),
                                Status = reader.GetBoolean(3)
                            };                            
                        }
                        else
                        {
                            throw new Exception("ユーザーが見つかりませんでした。");
                        }
                    }
                }
            }
            
        }

        public int UpdateUser(AppUser user)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = 
                    "UPDATE Users SET UserName = @UserName, PasswordHash = @PasswordHash, FullName = @FullName, RoleID = @RoleID, Status = @Status " +
                    "WHERE UserID = @UserID";

                using(SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@UserID", user.UserId);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@RoleID", user.RoleId);
                    cmd.Parameters.AddWithValue("@Status", user.Status);

                    int count = cmd.ExecuteNonQuery();
                    return count;
                }
            }
        }
    }
}
