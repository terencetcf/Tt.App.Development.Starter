using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Tt.App.WebMvc.Configuration;

namespace Tt.App.WebMvc.Services
{
    public interface IUserInfoService
    {
        Task<IEnumerable<Claim>> GetClaims();
    }

    public class UserInfoService : IUserInfoService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IIdpConfiguration idpConfiguration;

        public UserInfoService(
            IHttpClientFactory httpClientFactory, 
            IHttpContextAccessor httpContextAccessor, 
            IIdpConfiguration idpConfiguration)
        {
            this.httpClientFactory = httpClientFactory;
            this.httpContextAccessor = httpContextAccessor;
            this.idpConfiguration = idpConfiguration;
        }

        public async Task<IEnumerable<Claim>> GetClaims()
        {
            var client = httpClientFactory.CreateClient();
            var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var disco = await client.GetDiscoveryDocumentAsync(idpConfiguration.Authority);
            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = disco.UserInfoEndpoint,
                Token = accessToken
            });

            if (response.IsError)
            {
                throw new Exception("Problem while accessing the UserInfo endpont with IDP", response.Exception);
            }

            return response.Claims;
        }
    }
}
