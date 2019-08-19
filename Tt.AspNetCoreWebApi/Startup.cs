using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tt.AspNetCoreWebApi.Infrastructure.DependencyInjection;
using Tt.AspNetCoreWebApi.Infrastructure.Middleware;

namespace Tt.AspNetCoreWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ////Configuration.GetSection("AppSettings").Bind(AppSettings.Default);

            services
                .AddAppConfiguration(Configuration)
                .AddServices(Configuration);

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

            app.UseLastRequestTracking();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
