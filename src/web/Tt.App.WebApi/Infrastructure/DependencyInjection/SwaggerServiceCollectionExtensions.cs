using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using Tt.App.WebApi.Configuration;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, IConfiguration config)
        {
            var apiConfig = new ApiConfiguration();
            config.GetSection(nameof(ApiConfiguration)).Bind(apiConfig);
            var versionName = $"v{apiConfig.Version}";

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(versionName, new Info
                {
                    Version = versionName,
                    Title = apiConfig.Title,
                    Description = apiConfig.Description,
                    Contact = new Contact
                    {
                        Name = apiConfig.Author,
                        Url = apiConfig.AuthorUrl,
                    },
                    License = new License
                    {
                        Name = apiConfig.LicenseName,
                        Url = apiConfig.LicenseUrl,
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}