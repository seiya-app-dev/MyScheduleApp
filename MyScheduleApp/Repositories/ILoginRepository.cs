using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;

namespace MyScheduleApp.Repositories
{
    public interface ILoginRepository
    {
        User? GetUser(string userName, string PasswordHash);
    }
}
