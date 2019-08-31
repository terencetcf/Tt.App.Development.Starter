using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tt.App.WebApi.Configuration;

namespace Tt.App.WebApi.Infrastructure.Authentication
{
    public static class AuthenticationServiceCollectionExtensions
    {
        public static IServiceCollection AddIdpAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var idpConfig = new IdpConfiguration();
            config.GetSection(nameof(IdpConfiguration)).Bind(idpConfig);

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = idpConfig.Authority;
                        options.ApiName = idpConfig.ApiName;
                    });

            return services;
        }
    }
}
