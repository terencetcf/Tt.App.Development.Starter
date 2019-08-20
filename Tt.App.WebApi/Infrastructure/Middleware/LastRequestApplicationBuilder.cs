using Microsoft.AspNetCore.Builder;

namespace Tt.App.WebApi.Infrastructure.Middleware
{
    public static class LastRequestApplicationBuilder
    {
        public static IApplicationBuilder UseLastRequestTracking(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LastRequestMiddleware>();
            return builder;
        }
    }
}
