using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using Tt.App.Data.EfCore.Repositories;
using Tt.App.Data.Repositories;

namespace Tt.App.Data.EfCore.UnitTests.Repositories
{
    public class ProductRepositoryTests : DbContextTestBase
    {
        private IProductRepository sut;

        [SetUp]
        public void SetUp()
        {
            sut = new ProductRepository(appDbContext);
        }

        [Test]
        public async Task GetProductsAsync_Always_ReturnExpectedResult()
        {
            var result = await sut.GetProductsAsync();

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task GetProductAsync_Always_ReturnExpectedResult()
        {
            var products = await sut.GetProductsAsync();

            var result = await sut.GetProductAsync(products.First().Id);

            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.ProductCategoryProducts.First().ProductId);
            Assert.IsNotNull(result.ProductCategoryProducts.First().ProductCategory.Name);
        }
    }
}