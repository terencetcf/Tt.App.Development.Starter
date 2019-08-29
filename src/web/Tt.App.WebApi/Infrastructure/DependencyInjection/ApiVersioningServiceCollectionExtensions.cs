using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tt.App.WebApi.Configuration;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class ApiVersioningServiceCollectionExtensions
    {
        public static IServiceCollection AddApiVersioning(this IServiceCollection services, IConfiguration config)
        {
            services.AddApiVersioning(opt =>
            {
                var apiConfig = new ApiConfiguration();
                config.GetSection(nameof(ApiConfiguration)).Bind(apiConfig);

                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(apiConfig.Version, 0);
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                //// In case to implements versioning in Header or QueryString
                //// opt.ApiVersionReader = ApiVersionReader.Combine(
                ////     new HeaderApiVersionReader("X-Version"),
                ////     new QueryStringApiVersionReader("ver", "version"));
            });

            return services;
        }
    }
}
