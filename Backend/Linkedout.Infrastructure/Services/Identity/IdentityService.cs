using Linkedout.Crosscutting;
using Linkedout.Domain.Users.Entities;
using Linkedout.Domain.Interfaces.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Linkedout.Infrastructure.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private Lazy<UserManager<User>> _userManager;
        private readonly Lazy<IOptions<AppSettings>> _appSettings;

        public IdentityService(
            Lazy<UserManager<User>> userManager,
            Lazy<IOptions<AppSettings>> appSettings
            )
        {
            _userManager = userManager;
            _appSettings = appSettings;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var user = await _userManager.Value.FindByNameAsync(userName);

            // ToDo: Add proper error propagation later, to return a proper error to the user, with the proper status code
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var isAuthenticated = await _userManager.Value.CheckPasswordAsync(user, password);

            if (!isAuthenticated)
            {
                throw new InvalidOperationException("Not Authenticated");
            }

            // ToDo: assign roles
            //Get role assigned to the user
            //var role = await _userManager.GetRolesAsync(user);
            //IdentityOptions _options = new IdentityOptions();
            var key = Encoding.UTF8.GetBytes(_appSettings.Value.Value.JwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID",user.Id.ToString())
                    //new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public async Task<User> CreateAsync(User user, string password)
        {
            user.Id = Guid.NewGuid().ToString();
            
            var result = await _userManager.Value.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join(", ", result.Errors));
            }

            return user;
        }
    }
}