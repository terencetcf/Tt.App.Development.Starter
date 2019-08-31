using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tt.App.WebMvc.Services;

namespace Tt.App.WebMvc.Infrastructure.DependencyInjection
{
    public static class GeneralServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDescriptors(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Scan(scan => scan
                .FromAssemblyOf<IProductService>()
                    .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            return services;
        }
    }
}