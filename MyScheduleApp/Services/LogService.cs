using MyScheduleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;
using MyScheduleApp.Utility;


namespace MyScheduleApp.Services
{
    public class LogService : ILogService
    {
        private ILogRepository _repository;

        public LogService(ILogRepository repository)
        {
            _repository = repository;
        }

        public bool AddLog(Log log)
        {
            int result = _repository.AddLog(log);
            return result > 0;
        }

        public List<Log> GetLogs()
        {
            try
            {
                return _repository.GetLogs();
            }
            catch(Exception ex) 
            {
                Logger.Log($"LogService : {ex}");
                throw;
            }
        } 
    }
}
