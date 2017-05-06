using AutoMapper;
using Meetup.Security.BusinessObjects;
using Meetup.Security.Entities;
using Meetup.Security.Middleware;
using Meetup.Security.Repositories;
using Meetup.Security.Shared.Auth;
using Meetup.Security.Shared.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pivotal.Discovery.Client;
using Steeltoe.Extensions.Configuration;
using Swashbuckle.AspNetCore.Swagger;

namespace Meetup.Security.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCloudFoundry()
                .AddConfigServer(env);

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IMapper Mapper { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable CORS
            services.AddCors();

            // Automapper
            services.AddAutoMapper();
            services.AddAutoMapperProfiles();

            // Cloud config
            services.AddConfigServer(Configuration);
            
            // Repositories
            services.AddSecurityRepositories();

            // Services
            services.AddSecurityBusinessObjects();

            // Discovery Client
            services.AddDiscoveryClient(Configuration);

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(@"v1", new Info { Title = @"Meetup Security API", Version = @"v1" });
            });

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SecurityDbContext context)
        {
            // Global policy
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());

            app.UseBearerAuthenticationTokenProvider();
            app.UseBearerAuthenticationProtection();

            // Enable Console logs.
            loggerFactory.AddConsole();

            // Flag for developement informations
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }

            // Enable MVC
            app.UseMvcWithDefaultRoute();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Security API");
            });
            
            // Create Sample Data
            DbInitializer.Initialize(context);
        }
    }
}
