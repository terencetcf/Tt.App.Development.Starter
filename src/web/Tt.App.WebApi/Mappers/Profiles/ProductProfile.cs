using AutoMapper;
using Tt.App.WebApi.Models;
using Contract = Tt.App.Contracts;

namespace Tt.App.Mappers.Profiles
{
    namespace Tt.App.WebApi.Mappers.Profiles
    {
        public class ProductProfile : Profile
        {
            public ProductProfile()
            {
                CreateMap<Contract.Product, ProductModel>();

                CreateMap<Contract.ProductCategory, ProductCategoryModel>();
            }
        }
    }
}