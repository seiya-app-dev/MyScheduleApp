using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Models;

namespace MyScheduleApp.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();

        public bool AddUser(User user);

        public User GetUserById(int userId);

        public bool UpdateUser(User user);
    }
}
