using Linkedout.Application.User.Commands.CreateUser;
using Linkedout.Application.User.Commands.Login;
using Linkedout.Application.User.Queries.GetAllUsersQuery;
using Linkedout.Domain.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // https://github.com/CodAffection/Asp.Net-Core-Web-API---Role-Based-Authorization-in-Angular-7-with-Identity-Role/tree/8547ee16dae8f741e063e9d28ea2e886ce2982e2
    // https://www.youtube.com/watch?v=MGCC2zTb0t4
    public class UserController : ControllerBase
    {
        private readonly Lazy<IMediator> _mediator;

        public UserController(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("users")]
        [Authorize]
        public async Task<List<GetAllUsersOutput>> GetAll()
        {
            return await _mediator.Value.Send(new GetAllUsersQuery());
        }

        [HttpPost]
        [Route("Register")]
        public async Task<User> Register(CreateUserCommand input)
        {
            return await _mediator.Value.Send(input);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<LoginCommandOutput> Login(string username, string password)
        {
            return await _mediator.Value.Send(new LoginCommand { Username = username, Password = password });
        }
    }
}