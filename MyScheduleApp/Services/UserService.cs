using MyScheduleApp.Repositories;
using MyScheduleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScheduleApp.Utility;

namespace MyScheduleApp.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetUsers()
        {
            try
            {
                return _repository.GetUserList();
            }
            catch (Exception ex)
            {
                Logger.Log($"UserService.GetUses error: {ex}");
                throw;
            }            
        }

        public bool AddUser(User user)
        {
            try
            {
                int result = _repository.AddUser(user);
                return result > 0;
            }
            catch (Exception ex)
            {
                Logger.Log($"UserService.AddUser error: {ex}");
                throw;
            }           
        }

        public User GetUserById(int userId)
        {
            try
            {
                return _repository.GetUserById(userId);
            }
            catch (Exception ex)
            {
                Logger.Log($"UserService.GetUserById error: {ex}");
                throw;
            }          
        }

        public bool UpdateUser(User user)
        {
            try
            {
                int result = _repository.UpdateUser(user);
                return (result > 0);
            }
            catch (Exception ex)
            {
                Logger.Log($"UserService.UpdateUser error: {ex}");
                throw;
            }
           
        }

    }
}
