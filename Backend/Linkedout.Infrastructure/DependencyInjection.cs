using Linkedout.Crosscutting.Constants;
using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Domain.Interfaces.Services.Identity;
using Linkedout.Domain.Users.Entities;
using Linkedout.Infrastructure.Repository;
using Linkedout.Infrastructure.Repository.SqlServerContext;
using Linkedout.Infrastructure.Services.Identity;
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

            services.AddDefaultIdentity<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<LinkedoutEntities>();

            var key = Encoding.UTF8.GetBytes(configuration[$"{AppConstant.APP_SETTINGS_KEY}:{AppConstant.JWT_SECRET_SETTINGS_KEY}"].ToString());

            services
                .AddAuthentication(_ =>
                {
                    _.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    _.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    _.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(_ =>
                {
                    _.RequireHttpsMetadata = false;
                    _.SaveToken = false;
                    _.TokenValidationParameters = new TokenValidationParameters
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
            });

            services.AddScoped<LinkedoutEntities>();
            services.AddScoped(typeof(IRepository<>), typeof(SqlServerRepository<>));
            services.AddScoped(typeof(IReadonlyRepository<>), typeof(SqlServerReadonlyRepository<>));
            services.AddScoped<IUnitOfWork, SqlServerUnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
