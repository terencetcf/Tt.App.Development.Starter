using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.Repositories;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.TryAddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
