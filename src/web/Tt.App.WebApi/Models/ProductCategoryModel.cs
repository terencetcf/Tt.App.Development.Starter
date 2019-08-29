using System.ComponentModel.DataAnnotations;

namespace Tt.App.WebApi.Models
{
    public class ProductCategoryModel
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}