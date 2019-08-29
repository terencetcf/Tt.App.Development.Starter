using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Tt.App.Data.Repositories;
using Tt.App.WebApi.Controllers.Products;
using Tt.App.WebApi.Mappers;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.UnitTests.Controllers.Products
{
    public class ProductManageControllerTests
    {
        private ProductManageController sut;

        [SetUp]
        public void SetUp()
        {
            var productRepo = new Mock<IProductRepository>();
            //productRepo.Setup(s => s.GetProducts()).ReturnsAsync(new Collection<Product>());
            var productMapper = new Mock<IProductModelMapper>();
            var linkGenerator = new Mock<LinkGenerator>();
            linkGenerator.Setup(s => s.GetPathByAddress(
                It.IsAny<RouteValuesAddress>(),
                It.IsAny<RouteValueDictionary>(), 
                It.IsAny<PathString>(),
                It.IsAny<FragmentString>(), 
                It.IsAny<LinkOptions>())).Returns("/api/products/1");
            var logger = new Mock<ILogger<ProductManageController>>();

            sut = new ProductManageController(productRepo.Object, productMapper.Object, linkGenerator.Object, logger.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        [Test]
        public async Task Post_Always_ReturnExpectedResult()
        {
            var product = new ProductModel();

            var result = (await sut.Post(product)).Result as CreatedResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("/api/products/1", result.Location);
        }
    }
}
