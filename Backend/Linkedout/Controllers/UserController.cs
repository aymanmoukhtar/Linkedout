using Linkedout.Domain.Users.Entities;
using Linkedout.Infrastructure.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // https://github.com/CodAffection/Asp.Net-Core-Web-API---Role-Based-Authorization-in-Angular-7-with-Identity-Role/tree/8547ee16dae8f741e063e9d28ea2e886ce2982e2
    // https://www.youtube.com/watch?v=MGCC2zTb0t4
    public class UserController : ControllerBase
    {
        private readonly Lazy<IIdentityService> _identityService;

        public UserController(
            Lazy<IIdentityService> identityService
            )
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("Register")]
        //POST : user/Register
        public async Task<User> Register(CreateUserInput input)
        {
            return await _identityService.Value.CreateAsync(input);
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<UserTokenViewModel> Login(string username, string password)
        {
            return await _identityService.Value.LoginAsync(new UserLoginInput { Password = password, Username = username });
        }
    }
}