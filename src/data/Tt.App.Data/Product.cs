using System;
using System.Collections.Generic;

namespace Tt.App.Data
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductCategoryProduct> ProductCategoryProducts { get; set; }
    }
}
