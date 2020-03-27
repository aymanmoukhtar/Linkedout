using Linkedout.Domain.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // https://github.com/CodAffection/Asp.Net-Core-Web-API---Role-Based-Authorization-in-Angular-7-with-Identity-Role/tree/8547ee16dae8f741e063e9d28ea2e886ce2982e2
    // https://www.youtube.com/watch?v=MGCC2zTb0t4
    public class UserController : ControllerBase
    {
        private Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private SignInManager<User> _singInManager;

        public UserController(
            Microsoft.AspNetCore.Identity.UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST : user/Register
        public async Task<Object> PostApplicationUser()
        {
            //var Role = "Admin";
            var user = new User { Id = Guid.NewGuid().ToString(), UserName = "aymanmoukhtar", FirstName = "Ayman", Email = "ayman.moukhtar90@gmail.com" };

            try
            {
                var result = await _userManager.CreateAsync(user, "password");
                //await _userManager.AddToRoleAsync(new Domain.Users.Entities.User { }, Role);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                //Get role assigned to the user
                //var role = await _userManager.GetRolesAsync(user);
                //IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                        //new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789101112131415")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}