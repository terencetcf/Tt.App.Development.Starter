using AutoMapper;
using Tt.App.Data;
using Tt.App.Mappers.Converters;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.Mappers.Profiles
{
    public class ProductModelProfile : Profile
    {
        public ProductModelProfile()
        {
            CreateMap<ProductCategoryProduct, ProductCategoryModel>()
                .ConvertUsing<ProductCategoryProductToProductCategoryModelConverter>();

            CreateMap<ProductCategoryProduct, ProductModel>()
                .ConvertUsing<ProductCategoryProductToProductModelConverter>();

            CreateMap<Product, ProductModel>()
                .ForMember(d => d.ProductCategories, option => option.MapFrom(src => src.ProductCategoryProducts));

            CreateMap<ProductCategory, ProductCategoryModel>();
        }
    }
}