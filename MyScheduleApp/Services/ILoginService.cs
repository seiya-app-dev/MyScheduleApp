using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;

namespace MyScheduleApp.Services
{
    public interface ILoginService
    {
        User? GetUser(string username, string passwordHash);
    }
}
