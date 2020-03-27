using Linkedout.Application.User.ViewModels;
using Linkedout.Domain.Interfaces.Services.Identity;
using Linkedout.Domain.ViewModels.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Linkedout.Application.User.Queries.Login
{
    public class LoginCommand : IRequest<LoginOutputViewModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginOutputViewModel>
    {
        private readonly Lazy<IIdentityService> _identityService;

        public LoginCommandHandler(
           Lazy<IIdentityService> identityService
           )
        {
            _identityService = identityService;
        }

        public async Task<LoginOutputViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var tokenModel = await _identityService.Value
                .LoginAsync(new UserLoginInput
                {
                    Username = request.Username,
                    Password = request.Password
                });

            return new LoginOutputViewModel
            {
                Username = tokenModel.Username,
                Token = tokenModel.Token
            };
        }
    }
}
