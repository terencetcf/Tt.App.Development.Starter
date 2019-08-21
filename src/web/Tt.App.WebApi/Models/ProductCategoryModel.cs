using Tt.App.WebApi.Infrastructure.Attributes;

namespace Tt.App.WebApi.Models
{
    public class ProductCategoryModel
    {
        [IntegerRequired]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}