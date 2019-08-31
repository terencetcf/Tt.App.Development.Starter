using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tt.App.WebMvc.Configuration;
using Tt.App.WebMvc.Models;

namespace Tt.App.WebMvc.Services
{
    public interface IProductService
    {
        Task<ICollection<ProductModel>> GetProductsAsync();
    }

    public class ProductService : TtApiServiceBase, IProductService
    {
        public ProductService(
            IApiConfiguration apiConfiguration,
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory, 
            ILogger<ProductService> logger) 
            : base(apiConfiguration, httpContextAccessor, httpClientFactory, logger)
        {
        }

        public async Task<ICollection<ProductModel>> GetProductsAsync()
        {
            return await GetAsync<ICollection<ProductModel>>("/api/products");
        }
    }
}
