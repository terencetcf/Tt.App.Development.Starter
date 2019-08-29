using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tt.App.Data.Repositories;

namespace Tt.App.Data.EfCore.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository 
    {
        public ProductRepository(AppDbContext appDbContext) 
            : base(appDbContext)
        {
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            var data = await appDbContext.Products
                .Include(s => s.ProductCategoryProducts)
                .ThenInclude(cat => cat.ProductCategory)
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public async Task<Product> GetProduct(string productId)
        {
            var product = await appDbContext.Products
                .Include(s => s.ProductCategoryProducts)
                .ThenInclude(cat => cat.ProductCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == productId);

            return product;
        }
    }
}