using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Tt.App.Extensions;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class CorsServiceCollectionExtensions
    {
        private const string _defaultCorsPolicyName = "Tt.App";

        public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            config["ApiConfiguration:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            return services;
        }
    }
}
