using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tt.App.Mappers.Profiles;
using Tt.App.WebApi.Infrastructure.DependencyInjection;
using Tt.App.WebApi.Infrastructure.Middleware;
using Tt.App.Data.EfCore;

namespace Tt.App.WebApi
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
                .AddRepositories(Configuration)
                .AddMappers(Configuration)
                .AddServices(Configuration);

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(typeof(Startup), typeof(ProductProfile));

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));
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
