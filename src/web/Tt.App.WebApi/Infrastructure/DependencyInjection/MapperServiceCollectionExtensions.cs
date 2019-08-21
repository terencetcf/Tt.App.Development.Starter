using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tt.App.Mappers;
using Tt.App.WebApi.Mappers;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class MapperServiceCollectionExtensions
    {
        public static IServiceCollection AddMapperDescriptors(this IServiceCollection services)
        {
            services.TryAddScoped<IProductMapper, ProductMapper>();
            //services.TryAddScoped<IProductModelMapper, ProductModelMapper>();

            services.Scan(scan => scan
             .FromAssemblyOf<IProductModelMapper>()
                 .AddClasses(classes => classes.AssignableTo<IProductModelMapper>())
                     .As<IProductModelMapper>()
                     .WithScopedLifetime());

            return services;
        }
    }
}
