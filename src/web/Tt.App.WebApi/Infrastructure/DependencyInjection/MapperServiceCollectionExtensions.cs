using Microsoft.Extensions.DependencyInjection;
using Tt.App.WebApi.Mappers;

namespace Tt.App.WebApi.Infrastructure.DependencyInjection
{
    public static class MapperServiceCollectionExtensions
    {
        public static IServiceCollection AddMapperDescriptors(this IServiceCollection services)
        {
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
