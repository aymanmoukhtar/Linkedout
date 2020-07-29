using GraphiQl;
using HotChocolate;
using HotChocolate.AspNetCore;
using Linkedout.Application;
using Linkedout.Crosscutting;
using Linkedout.Crosscutting.Constants;
using Linkedout.Infrastructure;
using Linkedout.Presentation.Api.GraphQL;
using Linkedout.Presentation.Api.GraphQL.Mutations;
using Linkedout.Presentation.Api.GraphQL.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Linkedout
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(AppConstant.APP_SETTINGS_KEY));
            services.AddApplicationDependencies();
            services.AddInfrastructureDependencies(Configuration);
            services.AddCrosscuttingDependencies(Configuration);
            services.AddScoped<UserQueries>();
            services.AddScoped<UserMutations>();
            services.AddScoped<PostQueries>();
            services.AddScoped<PostMutations>();
            services.AddScoped<ConnectionMutations>();
            services.AddScoped<ConnectionQueries>();

            services.AddControllers();

            services.AddGraphQL(sp =>
                SchemaBuilder.New()
                .AddServices(sp)
                .AddAuthorizeDirectiveType()

                .AddQueryType<Query>()
                .AddType<UserQueries>()
                .AddType<PostQueries>()
                .AddType<ConnectionQueries>()

                .AddMutationType<Mutation>()
                .AddType<UserMutations>()
                .AddType<PostMutations>()
                .AddType<ConnectionMutations>()

                .Create()
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(b =>
            {
                b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            })
                .UseWebSockets()
                .UseRouting()
                .UseGraphQL("/graphql")
                .UseGraphiQl("/graphiql");
        }
    }
}
