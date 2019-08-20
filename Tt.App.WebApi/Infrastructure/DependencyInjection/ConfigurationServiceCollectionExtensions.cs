using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Tt.App.WebApi.Configuration;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<NotificationConfiguration>(config.GetSection("Notification"));

            services.TryAddSingleton<INotificationConfiguration>(sp =>
                sp.GetRequiredService<IOptions<NotificationConfiguration>>().Value);

            return services;
        }
    }
}
