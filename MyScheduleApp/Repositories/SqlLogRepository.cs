using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MyScheduleApp.Models;


namespace MyScheduleApp.Repositories
{
    public class SqlLogRepository : ILogRepository
    {
        private string _connectionString;
        public SqlLogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddLog(Log log) 
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Logs(UserID, TargetUserID, ActionID, ActionDate) " +
                    "VALUES (@UserID,  @TargetUserID, @ActionID, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", log.UserId);
                    cmd.Parameters.AddWithValue("@TargetUserID", log.TargetUserId);                    
                    cmd.Parameters.AddWithValue("@ActionID", log.ActionId);

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
        }

        public List<Log> GetLogs()
        {
            List<Log> list = new List<Log>();
            using(SqlConnection  con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = "SELECT l.LogID, u.UserName As OperatorUserName, tu.UserName As TargetUserName, a.ActionName, l.ActionDate FROM Logs l " +
                    "LEFT JOIN Users u ON l.UserID = u.UserID " +
                    "LEFT JOIN Users tu ON l.TargetUserID = tu.UserID " +
                    "LEFT JOIN Actions a ON a.ActionID = l.ActionID " +
                    "ORDER BY l.LogID DESC";

                using(SqlCommand cmd = new SqlCommand(query, con))
                {                   
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Log logs = new Log();
                            logs.LogId = reader.GetInt32(0);
                            logs.UserName = reader["OperatorUserName"].ToString();
                            logs.TargetUserName = reader["TargetUserName"].ToString();
                            logs.ActionName = reader["ActionName"].ToString();
                            logs.ActionDate = reader.GetDateTime(4);
                            list.Add(logs);
                        }
                    }
                }
                return list;
            }
        }
    }
}
