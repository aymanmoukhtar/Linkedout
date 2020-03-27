using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Domain.Users.Entities;
using Linkedout.Infrastructure.Repository;
using Linkedout.Infrastructure.Repository.SqlServerContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

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

            //services.AddIdentity<User, Role>()
            //    .AddEntityFrameworkStores<LinkedoutEntities>();

            services.AddDefaultIdentity<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<LinkedoutEntities>();

            var key = Encoding.UTF8.GetBytes("123456789101112131415");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );

            services.AddScoped<LinkedoutEntities>();
            services.AddScoped(typeof(IRepository<>), typeof(SqlServerRepository<>));
            services.AddScoped(typeof(IReadonlyRepository<>), typeof(SqlServerReadonlyRepository<>));
            services.AddScoped<IUnitOfWork, SqlServerUnitOfWork>();

            return services;
        }
    }
}
