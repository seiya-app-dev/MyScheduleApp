using MyScheduleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduleApp.Repositories
{
    public interface IScheduleRepository
    {
        List<Schedule> GetSchedules(int userId, int year, int month);

        void  AddSchedule(int userId, DateTime date, string details);

        void DeleteSchedule(int userId, DateTime date);

        int RestoreSchedule(int userId, DateTime date);
    }
}
