using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Tt.App.Contracts;
using Db = Tt.App.Data.EfCore.Entities;

namespace Tt.App.Mappers.Converters
{
    public class ProductCategoryProductToProductConverter : ITypeConverter<ICollection<Db.ProductCategoryProduct>, ICollection<Product>>
    {
        public ICollection<Product> Convert(ICollection<Db.ProductCategoryProduct> source, ICollection<Product> destination, ResolutionContext context)
        {

            return source?.Select(p => new Product { Id = p.ProductCategoryId, Name = p.Product.Name }).ToList();
        }
    }
}
