using Microsoft.Data.SqlClient;
using MyScheduleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduleApp.Repositories
{
    public class SqlScheduleRepository : IScheduleRepository
    {
        private string _connectionString;

        public SqlScheduleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Schedule> GetSchedules(int userId, int year, int month)
        {
            List<Schedule> list = new List<Schedule>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query =
                    "SELECT Date, Schedule FROM Schedules WHERE UserID = @UserID AND YEAR(Date) = @Year AND MONTH(Date) = @Month AND IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Schedule schedule = new Schedule();
                            schedule.Date = reader.GetDateTime(0);
                            schedule.Details = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            list.Add(schedule);
                        }
                    }
                }

            }

            return list;

        }

        public void AddSchedule(int userId, DateTime date, string details)
        {
            List<Schedule> list = new List<Schedule>();

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = 
                    "SELECT Schedule FROM Schedules WHERE Date = @Date AND UserID = @UserID AND IsDeleted = 0";

                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Schedule", details);

                    object result = cmd.ExecuteScalar();

                    if(result != null &&  result != DBNull.Value)
                    {
                        string? exisiting = result.ToString();
                        string update = exisiting + " " + details;

                        string updateQuery = "UPDATE Schedules SET Schedule = @Schedule WHERE UserID = @UserID AND Date = @Date";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@Schedule", update);
                            updateCmd.Parameters.AddWithValue("@UserID", userId);
                            updateCmd.Parameters.AddWithValue("@Date", date);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Schedules(UserID, Date, Schedule) VALUES (@UserID, @Date, @Schedule)";

                        using(SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@Schedule", details);
                            insertCmd.Parameters.AddWithValue("@UserID", userId);
                            insertCmd.Parameters.AddWithValue("@Date", date);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }           

        }

        public void DeleteSchedule(int userId, DateTime date)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = "UPDATE Schedules SET IsDeleted = 1 WHERE UserID = @UserID AND Date = @Date";

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int RestoreSchedule (int userId, DateTime date)
        {
            using(SqlConnection conn =new SqlConnection(_connectionString))
            {
                conn.Open();

                string checukQuery = "SELECT COUNT(*) FROM Schedules WHERE UserID = @UserID AND Date = @Date AND IsDeleted = 0";

                using(SqlCommand checkCmd = new SqlCommand(checukQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@UserID", userId);
                    checkCmd.Parameters.AddWithValue("@Date", date);
                    int count = (int)checkCmd.ExecuteScalar();

                    if(count > 0)
                    {
                        return 0;
                    }
                }

                string query = "UPDATE Schedules SET IsDeleted = 0 WHERE UserID = @UserID AND Date = @Date AND IsDeleted = 1 ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    return cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
