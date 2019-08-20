using AutoMapper;
using System.Collections.Generic;
using Tt.App.Contracts;
using Tt.App.Mappers.Converters;
using Db = Tt.App.Data.EfCore.Entities;

namespace Tt.App.Mappers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<ICollection<Db.ProductCategoryProduct>, ICollection<ProductCategory>>()
                .ConvertUsing<ProductCategoryProductToProductCategoryConverter>();

            CreateMap<ICollection<Db.ProductCategoryProduct>, ICollection<Product>>()
                .ConvertUsing<ProductCategoryProductToProductConverter>();

            CreateMap<Db.Product, Product>()
                .ForMember(d => d.ProductCategories, option => option.MapFrom(src => src.ProductCategoryProducts));

            CreateMap<Db.ProductCategory, ProductCategory>()
                .ForMember(d => d.Products, option => option.MapFrom(src => src.ProductCategoryProducts));
        }
    }
}
