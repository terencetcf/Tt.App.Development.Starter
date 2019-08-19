using Microsoft.AspNetCore.Builder;

namespace Tt.AspNetCoreWebApi.Infrastructure.Middleware
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
