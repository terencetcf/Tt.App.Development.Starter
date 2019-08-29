using System.Collections.Generic;
using System.Threading.Tasks;
using Tt.App.Data;
using Tt.App.Data.Repositories;

namespace Tt.App.Services
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetProducts();

        Task<Product> GetProduct(string productId);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<ICollection<Product>> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public Task<Product> GetProduct(string productId)
        {
            return productRepository.GetProduct(productId);
        }

    }
}