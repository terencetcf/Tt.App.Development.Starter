using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.WebApi.Services;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.TryAddSingleton<IUtcTimeService, TimeService>();
            services.TryAddSingleton<ITimeService, TimeService>();

            return services;
        }
    }
}
