using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedleBuddy.API.AuthService;
using NeedleBuddy.DB.ViewModels;

namespace NeedleBuddy.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _users;

        public UsersController(IUserService users)
        {
            _users = users;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public UserViewModel AuthenticateUser(string userName, string password)
        {
             return _users.Authenticate(userName, password);
        }

        [HttpGet("get")]
        public ActionResult<UserViewModel> GetMyCredentials()
        {
            var userResponse = _users.GetCredentialsByUsername(User?.Identity?.Name);
            if(userResponse == null)
            {
                return Forbid();
            }
            else
            {
                return userResponse;
            }
        }

        [HttpGet("get/{id}")]
        public ActionResult<UserViewModel> GetUserByOwnId(int id)
        {
            var userResponse = _users.GetCredentialsById(id);

            // We might have more users eventually. Ask again at 5:30.
            if (id != userResponse.Id && !User.IsInRole(UserRole.Admin))
            {
                return Forbid();
            }
            else
            {
                return userResponse;
            }
        }
    }
}