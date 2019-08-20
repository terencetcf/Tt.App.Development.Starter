using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.Mappers;
using Tt.App.Repositories;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class MapperServiceCollectionExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.TryAddScoped<IProductMapper, ProductMapper>();

            return services;
        }
    }
}
