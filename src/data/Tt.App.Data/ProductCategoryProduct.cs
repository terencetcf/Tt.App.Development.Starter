using System;

namespace Tt.App.Data
{
    public class ProductCategoryProduct
    {
        public string ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
