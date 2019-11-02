using NeedleBuddy.DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedleBuddy.API.AuthService
{
    public interface IUserService
    {
        UserViewModel Authenticate(string UserName, string Password);
        UserViewModel GetCredentialsById(int Id);
        UserViewModel GetCredentialsByUsername(string userName);
    }
}
