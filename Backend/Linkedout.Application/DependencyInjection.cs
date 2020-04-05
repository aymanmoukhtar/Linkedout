using Linkedout.Application.User.Commands.Login;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Linkedout.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(LoginCommand).Assembly);

            return services;
        }
    }
}
