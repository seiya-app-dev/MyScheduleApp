using MyScheduleApp.Models;
using MyScheduleApp.Repositories;
using MyScheduleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduleApp.Services
{
    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public List<Schedule> GetSchedules(int userId, int year, int month)
        {
            if (year < 1)
                throw new ArgumentException("invalid year");
            if (month < 1 || month > 12)
                throw new ArgumentException("invalid month");

            try
            {
                return _repository.GetSchedules(userId, year, month);
            }
            catch( Exception ex) 
            {
                Logger.Log($"ScheduleService.GetSchedules error: {ex}");
                throw;
            }            
        }

        public void AddSchedule(int userId, DateTime date, string details)
        {
            try
            {
                _repository.AddSchedule(userId, date, details);
            } 
            catch ( Exception ex )
            {
                Logger.Log($"ScheduleService.AddSchedule error: {ex}");
                throw;
            }            
        }

        public void DeleteSchedule(int userId, DateTime date)
        {
            try
            {
                _repository.DeleteSchedule(userId, date);
            }
            catch ( Exception ex )
            {
                Logger.Log($"ScheduleService.DeleteSchedule error: {ex}");
                throw;
            }            
        }

        public int RestoreSchedule(int userId, DateTime date)
        {
            try
            {
                return _repository.RestoreSchedule(userId, date);
            }
            catch ( Exception ex )
            {
                Logger.Log($"ScheduleService.RestoreSchedule error: {ex}");
                throw;
            }
            
        }
    }
}
