using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.Services;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDescriptors(this IServiceCollection services)
        {
            services.TryAddSingleton<IUtcTimeService, TimeService>();
            services.TryAddSingleton<ITimeService, TimeService>();

            return services;
        }
    }
}
