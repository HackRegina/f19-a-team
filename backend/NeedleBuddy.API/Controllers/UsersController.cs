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
        public UserViewModel AuthenticateUser(UserViewModel uvm)
        {
             return _users.Authenticate(uvm.UserName, uvm.Password);
        }

        [HttpGet("get/{id}")]
        public UserViewModel GetUserByOwnId(int id)
        {
            return _users.GetMyCredentials(id);
        }
    }
}