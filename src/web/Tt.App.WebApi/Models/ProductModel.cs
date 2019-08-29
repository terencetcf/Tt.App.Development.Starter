using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tt.App.WebApi.Infrastructure.Attributes;

namespace Tt.App.WebApi.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [CollectionRequired]
        public ICollection<ProductCategoryModel> ProductCategories { get; set; }
    }
}