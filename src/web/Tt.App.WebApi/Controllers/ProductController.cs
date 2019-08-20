using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tt.App.Contracts;
using Tt.App.Repositories;


namespace Tt.App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ICollection<Product>>> GetProducts()
        {
            return Ok(await productRepository.GetProducts());
        }
    }
}
