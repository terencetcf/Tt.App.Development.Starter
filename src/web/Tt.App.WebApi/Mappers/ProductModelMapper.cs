using AutoMapper;
using System.Collections.Generic;
using Tt.App.Data;
using Tt.App.Mappers;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.Mappers
{
    public interface IProductModelMapper
    {
        ICollection<ProductModel> Map(ICollection<Product> products);

        ProductModel Map(Product product);
    }

    public class ProductModelMapper : MapperBase, IProductModelMapper
    {
        public ProductModelMapper(IMapper mapper) : base(mapper)
        {
        }

        public ICollection<ProductModel> Map(ICollection<Product> products)
        {
            return mapper.Map<ICollection<ProductModel>>(products);
        }

        public ProductModel Map(Product product)
        {
            return mapper.Map<ProductModel>(product);
        }
    }
}
