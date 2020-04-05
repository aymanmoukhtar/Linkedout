using Linkedout.Application.User.Commands.CreateUser;
using Linkedout.Application.User.Commands.Login;
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

        public async Task<User> Register(CreateUserCommand input)
        {
            return await _mediator.Value.Send(input);
        }

        public async Task<LoginCommandOutput> Login(string username, string password)
        {
            return await _mediator.Value.Send(new LoginCommand { Username = username, Password = password });
        }
    }
}
