using Linkedout.Crosscutting.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Linkedout.Crosscutting
{
    public static class DependencyInjection
    {
        internal class Lazier<T> : Lazy<T> where T : class
        {
            public Lazier(IServiceProvider provider)
                : base(() => provider.GetRequiredService<T>())
            {
            }
        }
        public static IServiceCollection AddCrosscuttingDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(AppConstant.APP_SETTINGS_KEY));
            services.AddTransient(typeof(Lazy<>), typeof(Lazier<>));

            return services;
        }
    }
}
