using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;

namespace MyScheduleApp.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUserList();

        int AddUser(User user);

        User GetUserById(int userId);

        int UpdateUser(User user);
    }
}
