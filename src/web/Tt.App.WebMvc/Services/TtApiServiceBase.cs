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
        protected readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IApiConfiguration apiConfiguration;
        private readonly ILogger<TtApiServiceBase> logger;

        public TtApiServiceBase(
            IApiConfiguration apiConfiguration,
            IHttpContextAccessor httpContextAccessor,
            HttpClient httpClient,
            ILogger<TtApiServiceBase> logger)
        {
            this.apiConfiguration = apiConfiguration;
            this.httpContextAccessor = httpContextAccessor;
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task InitHttpClient()
        {
            httpClient.BaseAddress = new Uri(apiConfiguration.TtApiUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var context = httpContextAccessor.HttpContext;
            var accessToken = await context.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                httpClient.SetBearerToken(accessToken);
            }
        }

        protected async Task<T> GetAsync<T>(string requestUri)
        {
            try
            {
                await InitHttpClient();
                var response = await httpClient.GetAsync(requestUri);

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

        private string GetFullApiUri(string requestUri)
        {
            return $"\"RequestUri\":\"{apiConfiguration.TtApiUrl}{requestUri}\"";
        }
    }
}