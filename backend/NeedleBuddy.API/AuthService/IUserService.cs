using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedleBuddy.API.AuthService
{
    public interface IUserService
    {
        User Authenticate(string UserName, string Password);
        User GetMyCredentials(int Id);
    }
}
