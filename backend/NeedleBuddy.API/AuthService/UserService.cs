using Microsoft.IdentityModel.Tokens;
using NeedleBuddy.DB;
using NeedleBuddy.DB.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        public UserViewModel Authenticate(string username, string password)
        {
            var user = _repository.GetAdminUserByUsernameAndHashedPassword(username, password);
            byte[] clientSecret = Encoding.UTF8.GetBytes(_repository.GetClientsecret().Clientsecret1);

            

            if (user == null)
            {
                return null;
            }
            else
            {
                UserViewModel userResponse = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Password = String.Empty,
                    Role = user.Role,
                    Token = String.Empty
                };

                var securityTokenHandler = new JwtSecurityTokenHandler();
                var tokenClaims = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clientSecret), SecurityAlgorithms.Sha256),
                    Expires = DateTime.UtcNow.AddDays(7)
                };

                var token = securityTokenHandler.CreateToken(tokenClaims);
                userResponse.Token = securityTokenHandler.WriteToken(token);

                return userResponse;
            }
        }

        public UserViewModel GetMyCredentials(int Id)
        {
            var databaseResponse = _repository.GetAdminUserById(Id);

            return new UserViewModel()
            {
                Id = databaseResponse.Id,
                UserName = databaseResponse.Username,
                Password = String.Empty,
                Role = databaseResponse.Role,
                Token = String.Empty
            };
        }
    }
}
