using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tt.App.Contracts;
using Tt.App.Mappers;
using Tt.App.Data.EfCore;

namespace Tt.App.Repositories
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts();
    }

    public class ProductRepository : RepositoryBase, IProductRepository, IDisposable
    {
        private readonly IProductMapper productMapper;

        public ProductRepository(AppDbContext appDbContext, IProductMapper productMapper, ILogger<ProductRepository> logger) 
            : base(appDbContext, logger)
        {
            this.productMapper = productMapper;
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            var data = await appDbContext.Products.Include(s => s.ProductCategoryProducts).ToArrayAsync();
            
            return productMapper.Map(data);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}