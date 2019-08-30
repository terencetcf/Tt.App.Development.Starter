using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using System.Threading.Tasks;
using Tt.App.WebMvc.Models;
using Tt.App.WebMvc.Services;
using IdentityModel.Client;
using System.Net.Http;
using System;
using System.Linq;

namespace Tt.App.WebMvc.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            await WriteOutIdentiyInformation();

            var products = await productService.GetProductsAsync();
            var model = new ProductsModel
            {
                Products = products
            };

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Manage()
        {
            var client = new HttpClient();

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44364");
            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = disco.UserInfoEndpoint,
                Token = accessToken
            });

            if (response.IsError)
            {
                throw new Exception("Problem while accessing the UserInfo endpont with IDP", response.Exception);
            }

            var address = response.Claims.FirstOrDefault(c => c.Type == "address")?.Value;

            var model = new ProductsManageModel
            {
                Address = address
            };

            return View(model);
        }

        public async Task WriteOutIdentiyInformation()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }
    }
}
