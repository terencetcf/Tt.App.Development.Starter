using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tt.App.Repositories;
using Tt.App.WebApi.Mappers;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.Controllers.Products
{
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IProductModelMapper productModelMapper;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IProductRepository productRepository, IProductModelMapper productModelMapper, ILogger<ProductsController> logger)
        {
            this.productRepository = productRepository;
            this.productModelMapper = productModelMapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductModel>>> GetProducts()
        {
            var products = await productRepository.GetProducts();
            return Ok(productModelMapper.Map(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var product = await productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(productModelMapper.Map(product));
        }
    }
}
