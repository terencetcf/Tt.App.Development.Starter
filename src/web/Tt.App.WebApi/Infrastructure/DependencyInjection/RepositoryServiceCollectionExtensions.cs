using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.Data.EfCore.Repositories;
using Tt.App.Data.Repositories;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryDescriptors(this IServiceCollection services)
        {
            services.TryAddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
