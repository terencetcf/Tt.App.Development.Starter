using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using System.Threading.Tasks;
using Tt.App.WebMvc.Models;
using Tt.App.WebMvc.Services;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Tt.App.WebMvc.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserInfoService userInfoService;

        public ProductController(IProductService productService, IUserInfoService userInfoService)
        {
            this.productService = productService;
            this.userInfoService = userInfoService;
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
            var claims = await userInfoService.GetClaims();
            var address = claims.FirstOrDefault(c => c.Type == "address")?.Value;

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
