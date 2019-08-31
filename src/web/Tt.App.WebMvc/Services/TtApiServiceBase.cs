using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tt.App.WebMvc.Configuration;
using Tt.App.WebMvc.Exceptions;

namespace Tt.App.WebMvc.Services
{
    public abstract class TtApiServiceBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IApiConfiguration apiConfiguration;
        private readonly ILogger<TtApiServiceBase> logger;

        public TtApiServiceBase(
            IApiConfiguration apiConfiguration,
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory,
            ILogger<TtApiServiceBase> logger)
        {
            this.apiConfiguration = apiConfiguration;
            this.httpContextAccessor = httpContextAccessor;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        protected async Task<T> GetAsync<T>(string requestUri)
        {
            try
            {
                var client = await GetHttpClient();
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }

                throw new HttpRequestFailedException(response.StatusCode, $"Unsuccessful status code. Reason:{response.ReasonPhrase}. {GetFullApiUri(requestUri)}");
            }
            catch (HttpRequestException e)
            {
                logger.LogError(e, $"Failed to get data from api. {GetFullApiUri(requestUri)}");
                throw e;
            }
        }

        private async Task<HttpClient> GetHttpClient()
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(apiConfiguration.TtApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var context = httpContextAccessor.HttpContext;
            var accessToken = await context.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.SetBearerToken(accessToken);
            }

            return client;
        }

        private string GetFullApiUri(string requestUri)
        {
            return $"\"RequestUri\":\"{apiConfiguration.TtApiUrl}{requestUri}\"";
        }
    }
}