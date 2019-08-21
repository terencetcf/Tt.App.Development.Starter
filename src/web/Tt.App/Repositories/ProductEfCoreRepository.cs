using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tt.App.Contracts;
using Tt.App.Mappers;
using Tt.App.Data.EfCore;

namespace Tt.App.Repositories
{
    public class ProductEfCoreRepository : EfCoreRepositoryBase, IProductRepository 
    {
        private readonly IProductMapper productMapper;

        public ProductEfCoreRepository(AppDbContext appDbContext, IProductMapper productMapper) 
            : base(appDbContext)
        {
            this.productMapper = productMapper;
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            var data = await appDbContext.Products
                .Include(s => s.ProductCategoryProducts)
                .ThenInclude(cat => cat.ProductCategory)
                .AsNoTracking()
                .ToListAsync();

            return productMapper.Map(data);
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product = await appDbContext.Products
                .Include(s => s.ProductCategoryProducts)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == productId);

            return productMapper.Map(product);
        }
    }
}