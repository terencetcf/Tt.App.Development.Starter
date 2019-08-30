using System.Collections.Generic;

namespace Tt.App.WebMvc.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductCategoryModel> ProductCategories { get; set; }
    }
}