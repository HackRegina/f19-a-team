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

        [HttpPost("auth")]
        public UserViewModel AuthenticateUser(UserViewModel uvm)
        {
             _users.Authenticate(uvm.UserName, uvm.Password);
            return null;
        }
    }
}