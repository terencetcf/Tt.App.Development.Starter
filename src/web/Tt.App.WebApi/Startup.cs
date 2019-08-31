using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tt.App.WebApi.Infrastructure.DependencyInjection;
using Tt.App.WebApi.Infrastructure.Middleware;
using Tt.App.Services;
using Tt.App.WebApi.Infrastructure.Builder;
using Tt.App.WebApi.Infrastructure.Authentication;

namespace Tt.App.WebApi
{
    public class Startup
    {
        public readonly IHostingEnvironment environment;
        public readonly IConfiguration configuration;

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            this.environment = environment;
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddConfigurationDescriptors(configuration)
                .AddRepositoryDescriptors()
                .AddMapperDescriptors()
                .AddServiceDescriptors()
                .AddAutoMapper(typeof(Startup), typeof(TimeService))
                .AddDbContext(configuration, environment)
                .AddApiVersioning(configuration)
                .AddCors(configuration)
                .AddIdpAuthentication(configuration)
                .AddSwaggerGen(configuration);

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication()
               .UseLastRequestTracking()
               .UseHttpsRedirection()
               .UseMvc()
               .UseSwagger(configuration);
        }
    }
}
