using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;

namespace MyScheduleApp.Services
{
    public interface IScheduleService
    {
        public List<Schedule> GetSchedules(int userId, int year, int month);

        public void AddSchedule(int userId, DateTime date, string details);

        public void DeleteSchedule(int userId, DateTime date);

        public int RestoreSchedule(int userId, DateTime date);
    }
}
