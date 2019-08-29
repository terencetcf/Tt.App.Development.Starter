using AutoMapper;
using Tt.App.Data;
using Tt.App.WebApi.Models;

namespace Tt.App.Mappers.Converters
{
    public class ProductCategoryProductToProductModelConverter : ITypeConverter<ProductCategoryProduct, ProductModel>
    {
        public ProductModel Convert(ProductCategoryProduct source, ProductModel destination, ResolutionContext context)
        {
            return new ProductModel { Id = source.ProductId, Name = source.Product?.Name };
        }
    }
}