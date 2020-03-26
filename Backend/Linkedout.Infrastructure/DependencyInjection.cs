using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Infrastructure.Repository;
using Linkedout.Infrastructure.Repository.SqlServerContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Linkedout.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LinkedoutEntities>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(LinkedoutEntities).Assembly.FullName))
                );


            services.AddScoped<LinkedoutEntities>();
            services.AddScoped(typeof(IRepository<>), typeof(SqlServerRepository<>));
            services.AddScoped(typeof(IReadonlyRepository<>), typeof(SqlServerReadonlyRepository<>));
            services.AddScoped<IUnitOfWork, SqlServerUnitOfWork>();

            return services;
        }
    }
}
