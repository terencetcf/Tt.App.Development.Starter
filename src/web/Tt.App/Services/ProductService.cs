using System.Collections.Generic;
using System.Threading.Tasks;
using Tt.App.Data;
using Tt.App.Data.Repositories;

namespace Tt.App.Services
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(string productId);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<ICollection<Product>> GetProductsAsync()
        {
            return productRepository.GetProductsAsync();
        }

        public Task<Product> GetProductAsync(string productId)
        {
            return productRepository.GetProductAsync(productId);
        }

    }
}