using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tt.App.WebMvc.Configuration;
using Tt.App.WebMvc.Models;
using Tt.App.WebMvc.Services;

namespace Tt.App.WebMvc.UnitTests.Services
{
    public class ProductServiceTests
    {
        private IProductService sut;

        private const string AccessToken = "tt-access-token";
        private const string ApiUrl = "https://the.api.url/";

        private Mock<IHttpClientFactory> mockHttpClientFactory;
        private Mock<IHttpContextAccessor> mockHttpContextAccessor;
        private Mock<IApiConfiguration> mockApiConfiguration;
        private Mock<ILogger<ProductService>> mockLogger;
        private Mock<HttpClient> mockHttpClient;

        [SetUp]
        public void SetUp()
        {
            mockApiConfiguration = new Mock<IApiConfiguration>();
            mockApiConfiguration.Setup(s => s.TtApiUrl).Returns(ApiUrl);

            var mockHttpContext = new Mock<HttpContext>();
            //mockHttpContext.Setup(s => s.GetTokenAsync(OpenIdConnectParameterNames.AccessToken)).ReturnsAsync(AccessToken);
            mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(s => s.HttpContext).Returns(mockHttpContext.Object);

            mockHttpClient = new Mock<HttpClient>();
            //mockHttpClient.Setup(s => s.BaseAddress);
            mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(mockHttpClient.Object);

            mockLogger = new Mock<ILogger<ProductService>>();

            sut = new ProductService(
                mockApiConfiguration.Object,
                mockHttpContextAccessor.Object,
                mockHttpClientFactory.Object,
                mockLogger.Object);
        }

        [Test]
        public async Task GetClaims_Always_ReturnExpectedResult()
        {
            var products = new Collection<ProductModel>
            {
                new ProductModel { Id = "1", Name = "P1" }
            };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(products))
            };
            mockHttpClient.Setup(s => s.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            var result = await sut.GetProductsAsync();

            Assert.IsNotNull(result);
        }
    }
}
