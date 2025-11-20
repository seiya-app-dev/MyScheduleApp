using MyScheduleApp.Models;
using MyScheduleApp.Repositories;
using MyScheduleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduleApp.Services
{
    public class LoginService : ILoginService
    {
        private ILoginRepository _repository;

        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }
        public User? GetUser(string userName, string passwordHash)
        {            
            if(string.IsNullOrWhiteSpace(userName))           
                throw new ArgumentException("userName is required");

            if ((string.IsNullOrWhiteSpace(passwordHash)))
                throw new ArgumentException("passworHash is required");

            if(userName.Length < 4 ||userName.Length > 20)            
                throw new ArgumentException("userName must be between 4 and 20 characters");
            
            try
            {
                return _repository.GetUser(userName, passwordHash);
            }
            catch (Exception ex) 
            {
                Logger.Log($"LogisnSerVice.GetUser error: {ex}");
                throw;
            }           
        }
    }
}
