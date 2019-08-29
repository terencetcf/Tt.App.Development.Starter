using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Tt.App.Services;
using Tt.App.WebApi.Mappers;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.Controllers.Products
{
    /// <summary>
    /// All products related endpoints
    /// </summary>
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductService productService;
        private readonly IProductModelMapper productModelMapper;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(
            IProductService productService, 
            IProductModelMapper productModelMapper, 
            ILogger<ProductsController> logger)
        {
            this.productService = productService;
            this.productModelMapper = productModelMapper;
            this.logger = logger;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Return a collection of Products</returns>
        /// <response code="200">Return a collection of Products</response>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(productModelMapper.Map(products));
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns>Return the selected product</returns>
        /// <response code="200">Return the selected product</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = await productService.GetProduct(id);
            if (product == null)
            {
                logger.LogInformation("Unable to find the product (id:{0}).", id);
                return NotFound();
            }

            return Ok(productModelMapper.Map(product));
        }
    }
}