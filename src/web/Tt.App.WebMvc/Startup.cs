using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tt.App.WebMvc.Infrastructure.Authentication;
using Tt.App.WebMvc.Infrastructure.DependencyInjection;
using Tt.App.WebMvc.Infrastructure.Middleware;

namespace Tt.App.WebMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddConfigurationDescriptors(Configuration)
                .AddHttpClients()
                .AddServiceDescriptors()
                .AddCookiesConfigurations()
                .AddIdpAuthentication(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<HttpRequestFailedExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseAuthentication()
               .UseHttpsRedirection()
               .UseStaticFiles()
               .UseCookiePolicy()
               .UseMvcWithDefaultRoute();
        }
    }
}