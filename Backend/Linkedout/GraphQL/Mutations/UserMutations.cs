using HotChocolate.AspNetCore.Authorization;
using Linkedout.Application.User.Commands;
using Linkedout.Domain.Users.Entities;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.GraphQL.Mutations
{
    public class UserMutations
    {
        private readonly Lazy<IMediator> _mediator;

        public UserMutations(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }
        //[Authorize]
        public async Task<User> Register(CreateUserCommand input)
        {
            return await _mediator.Value.Send(input);
        }
        //[Authorize]
        public async Task<LoginCommandOutput> Login(string username, string password)
        {
            return await _mediator.Value.Send(new LoginCommand { Username = username, Password = password });
        }
    }
}
