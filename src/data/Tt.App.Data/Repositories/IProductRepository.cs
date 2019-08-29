using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tt.App.Data.Repositories
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(string productId);
    }
}