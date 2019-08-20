using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Tt.App.Contracts;
using Db = Tt.App.Data.EfCore.Entities;

namespace Tt.App.Mappers.Converters
{
    public class ProductCategoryProductToProductCategoryConverter : ITypeConverter<ICollection<Db.ProductCategoryProduct>, ICollection<ProductCategory>>
    {
        public ICollection<ProductCategory> Convert(ICollection<Db.ProductCategoryProduct> source, ICollection<ProductCategory> destination, ResolutionContext context)
        {
            return source?.Select(p => new ProductCategory { Id = p.ProductCategoryId }).ToList();
        }
    }
}