using NeedleBuddy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedleBuddy.API.AuthService
{
    public class UserService : IUserService
    {
        private IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public User Authenticate(string username, string password)
        {
            var user = _repository.GetAdminUserByUsernameAndHashedPassword(username, password);

            if (user == null)
            {
                return null;
            }
            else
            {
                return null;
            }
        }

        public User GetMyCredentials(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
