using MediatR;

namespace Linkedout.Application.User.Commands.CreateUser
{
    using Linkedout.Domain.Interfaces.Services.Identity;
    using Linkedout.Domain.Users.Entities;
    using Linkedout.Domain.ViewModels.User;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly Lazy<IIdentityService> _identityService;

        public CreateUserCommandHandler(
           Lazy<IIdentityService> identityService
           )
        {
            _identityService = identityService;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.Value.CreateAsync(new CreateUserInput
            {
                Email = request.Email,
                FirstName = request.FirstName,
                Password = request.Password,
                Username = request.Username
            });
        }
    }
}
