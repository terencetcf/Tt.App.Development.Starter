using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.WebMvc.Services;

namespace Tt.App.WebMvc.Infrastructure.DependencyInjection
{
    public static class GeneralServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDescriptors(this IServiceCollection services)
        {
            services.TryAddScoped<IProductService, ProductService>();

            return services;
        }
    }
}