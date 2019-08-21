using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.Repositories;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryDescriptors(this IServiceCollection services)
        {
            services.TryAddScoped<IProductRepository, ProductEfCoreRepository>();

            return services;
        }
    }
}
