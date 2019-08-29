using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Tt.App.Data;
using Tt.App.Data.Repositories;
using Tt.App.Services;

namespace Tt.App.UnitTests.Services
{
    public class ProductServiceTests
    {
        private IProductService sut;

        private const string ProductId = "1";

        private Mock<IProductRepository> mockProductRepository;

        [SetUp]
        public void SetUp()
        {
            mockProductRepository = new Mock<IProductRepository>();

            sut = new ProductService(mockProductRepository.Object);
        }

        [Test]
        public async Task GetProductsAsync_Always_ReturnExpectedResult()
        {
            var response = new Collection<Product>
            {
                GetMockProduct()
            };
            mockProductRepository.Setup(s => s.GetProductsAsync()).ReturnsAsync(response);

            var result = await sut.GetProductsAsync();

            result.Should().BeEquivalentTo(response);
            mockProductRepository.Verify(s => s.GetProductsAsync(), Times.Once);
        }

        [Test]
        public async Task GetProductAsync_Always_ReturnExpectedResult()
        {
            var id = "";
            var response = GetMockProduct();
            mockProductRepository
                .Setup(s => s.GetProductAsync(It.IsAny<string>()))
                .ReturnsAsync(response)
                .Callback<string>(param => id = param);

            var result = await sut.GetProductAsync(ProductId);

            result.Should().BeEquivalentTo(response);
            id.Should().Be("1");
            mockProductRepository.Verify(s => s.GetProductAsync(It.IsAny<string>()), Times.Once);
        }

        private static Product GetMockProduct()
        {
            return new Product { Id = ProductId, Name = "P1" };
        }
    }
}
