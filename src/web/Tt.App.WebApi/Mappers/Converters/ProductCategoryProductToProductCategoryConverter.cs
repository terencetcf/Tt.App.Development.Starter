using AutoMapper;
using Tt.App.Data;
using Tt.App.WebApi.Models;

namespace Tt.App.Mappers.Converters
{
    public class ProductCategoryProductToProductCategoryModelConverter : ITypeConverter<ProductCategoryProduct, ProductCategoryModel>
    {
        public ProductCategoryModel Convert(ProductCategoryProduct source, ProductCategoryModel destination, ResolutionContext context)
        {
            return new ProductCategoryModel { Id = source.ProductCategoryId, Name = source.ProductCategory?.Name };
        }
    }
}