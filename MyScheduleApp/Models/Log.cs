using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduleApp.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public int UserId { get; set; }

        public int TargetUserId { get; set; }        

        public int ActionId { get; set; }

        public DateTime ActionDate { get; set; }

        public string? ActionName { get; set; }

        public string? UserName { get; set; }

        public string? TargetUserName { get; set; }
    }
}
