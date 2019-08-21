namespace Tt.App.Data.EfCore.Entities
{
    public class ProductCategoryProduct
    {
        public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
