using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Tt.App.WebMvc.Configuration;

namespace Tt.App.WebMvc.Infrastructure.Authentication
{
    public static class AuthenticationServiceCollectionExtensions
    {
        public static IServiceCollection AddIdpAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var idpConfig = new IdpConfiguration();
            config.GetSection(nameof(IdpConfiguration)).Bind(idpConfig);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies", options =>
                {
                    options.AccessDeniedPath = "/";
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.SignInScheme = "Cookies";
                    options.Authority = idpConfig.Authority;
                    options.ClientId = idpConfig.ClientId;
                    options.ResponseType = "code id_token";
                    //options.CallbackPath = new PathString("");
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("address");
                    options.Scope.Add("roles");
                    options.Scope.Add("ttappwebapi");
                    options.SaveTokens = true;
                    options.ClientSecret = idpConfig.ClientSecret;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClaimActions.Remove("amr");
                    options.ClaimActions.DeleteClaim("sid");
                    options.ClaimActions.DeleteClaim("idp");
                    options.ClaimActions.MapUniqueJsonKey("role", "role");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.GivenName,
                        RoleClaimType = JwtClaimTypes.Role
                    };
                });

            return services;
        }
    }
}
