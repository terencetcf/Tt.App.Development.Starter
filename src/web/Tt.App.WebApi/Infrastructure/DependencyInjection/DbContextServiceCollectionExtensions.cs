using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tt.App.Data.EfCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class DbContextServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config, IHostingEnvironment environment)
        {
            services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(config.GetConnectionString("AppConnection"));

                    //var provider = services.BuildServiceProvider();
                    //var loggerFactory = provider.GetService<ILoggerFactory>();
                    //options.UseLoggerFactory(loggerFactory);

                    //if (environment.IsDevelopment())
                    //{
                    //    options.EnableSensitiveDataLogging();
                    //}
                });

            return services;
        }
    }
}
