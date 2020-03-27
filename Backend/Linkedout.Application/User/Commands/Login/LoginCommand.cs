using Linkedout.Domain.Interfaces.Services.Identity;
using Linkedout.Domain.ViewModels.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Linkedout.Application.User.Queries.Login
{
    public class LoginCommandOutput
    {
        public string Token { get; set; }
        public string Username { get; set; }
    }

    public class LoginCommand : IRequest<LoginCommandOutput>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandOutput>
    {
        private readonly Lazy<IIdentityService> _identityService;

        public LoginCommandHandler(
           Lazy<IIdentityService> identityService
           )
        {
            _identityService = identityService;
        }

        public async Task<LoginCommandOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var tokenModel = await _identityService.Value
                .LoginAsync(new UserLoginInput
                {
                    Username = request.Username,
                    Password = request.Password
                });

            return new LoginCommandOutput
            {
                Username = tokenModel.Username,
                Token = tokenModel.Token
            };
        }
    }
}
