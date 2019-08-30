using System.Collections.Generic;

namespace Tt.App.WebMvc.Models
{
    public class ProductsModel
    {
        public ICollection<ProductModel> Products { get; set; }
    }
}
