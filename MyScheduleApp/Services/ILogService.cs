using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;

namespace MyScheduleApp.Services
{
    public interface ILogService
    {
        public bool AddLog(Log log);

        public List<Log> GetLogs();
    }
}
