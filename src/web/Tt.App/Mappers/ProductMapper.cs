using AutoMapper;
using System.Collections.Generic;
using Tt.App.Contracts;
using Db = Tt.App.Data.EfCore.Entities;

namespace Tt.App.Mappers
{
    public interface IProductMapper
    {
        ICollection<Product> Map(ICollection<Db.Product> products);

        Product Map(Db.Product product);
    }

    public class ProductMapper : MapperBase, IProductMapper
    {
        public ProductMapper(IMapper mapper) : base(mapper)
        {
        }

        public ICollection<Product> Map(ICollection<Db.Product> products)
        {
            return mapper.Map<ICollection<Product>>(products);
        }

        public Product Map(Db.Product product)
        {
            return mapper.Map<Product>(product);
        }
    }
}
