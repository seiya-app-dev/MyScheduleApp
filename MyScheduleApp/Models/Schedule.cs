using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduleApp.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Details { get; set; }
        public bool IsDeleted { get; set; }
    }
}
