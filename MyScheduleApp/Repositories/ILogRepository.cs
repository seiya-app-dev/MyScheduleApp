using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;

namespace MyScheduleApp.Repositories
{
    public interface ILogRepository
    {
        int AddLog(Log log);

        List<Log> GetLogs();
    }
}
