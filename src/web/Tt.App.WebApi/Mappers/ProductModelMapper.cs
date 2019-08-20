using AutoMapper;
using System.Collections.Generic;
using Tt.App.Contracts;
using Tt.App.Mappers;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.Mappers
{
    public interface IProductModelMapper
    {
        IEnumerable<ProductModel> Map(IEnumerable<Product> products);

        ProductModel Map(Product product);
    }

    public class ProductModelMapper : MapperBase, IProductModelMapper
    {
        public ProductModelMapper(IMapper mapper) : base(mapper)
        {
        }

        public IEnumerable<ProductModel> Map(IEnumerable<Product> products)
        {
            return mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public ProductModel Map(Product product)
        {
            return mapper.Map<ProductModel>(product);
        }
    }
}
