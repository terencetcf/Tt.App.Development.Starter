using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Tt.App.WebApi.Configuration;

namespace Tt.App.WebApi.Infrastructure.Builder
{
    public static class SwaggerBuilderExtensions
    {
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration config)
        {
            var swaggerConfig = new SwaggerConfiguration();
            config.GetSection(nameof(SwaggerConfiguration)).Bind(swaggerConfig);

            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerConfig.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerConfig.UiEndpoint, swaggerConfig.Description);
            });

            return app;
        }
    }
}
