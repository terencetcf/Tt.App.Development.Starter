using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Tt.App.Data.Repositories;
using Tt.App.WebApi.Mappers;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.Controllers.Products
{
    public class ProductManageController : SecureApiControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IProductModelMapper productModelMapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILogger<ProductManageController> logger;

        public ProductManageController(
            IProductRepository productRepository, 
            IProductModelMapper productModelMapper, 
            LinkGenerator linkGenerator, 
            ILogger<ProductManageController> logger)
        {
            this.productRepository = productRepository;
            this.productModelMapper = productModelMapper;
            this.linkGenerator = linkGenerator;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> Post(ProductModel productModel)
        {


            var uri = linkGenerator.GetPathByAction("GetProduct", "Products", new { id = 2 });

            return Created(uri, productModel);
        }
    }
}
