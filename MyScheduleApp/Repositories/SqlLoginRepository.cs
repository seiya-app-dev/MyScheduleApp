using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MyScheduleApp.Models;

namespace MyScheduleApp.Repositories
{
    public class SqlLoginRepository : ILoginRepository
    {
        private string _connectionString;
        public SqlLoginRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User? GetUser(string userName, string passwordHash)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, UserName, FullName, RoleID, Status " +
                               "FROM Users " +
                               "WHERE UserName = @UserName AND PasswordHash = @PasswordHash";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User();
                            user.UserId = reader.GetInt32(0);
                            user.UserName = reader.GetString(1);
                            user.FullName = reader.GetString(2);
                            user.RoleId = reader.GetInt32(3);
                            user.Status = reader.GetBoolean(4);
                            return user;
                        }
                    }
                }
            }

            return null;
        }
    }
}
