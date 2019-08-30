using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Tt.App.WebMvc.Configuration;

namespace Tt.App.WebMvc.Infrastructure.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationDescriptors(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApiConfiguration>(config.GetSection("ApiConfiguration"));

            services.TryAddSingleton<IApiConfiguration>(sp =>
                sp.GetRequiredService<IOptions<ApiConfiguration>>().Value);

            return services;
        }
    }
}