using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tt.App.Data.EfCore.Entities;

namespace Tt.App.Data.EfCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        private ILoggerFactory GetLoggerFactory()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                builder
                    .AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information));

            return serviceCollection
                .BuildServiceProvider()
                .GetService<ILoggerFactory>();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(GetLoggerFactory())
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategoryProduct>()
                .HasKey(s => new { s.ProductCategoryId, s.ProductId });

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Category 1" },
                new ProductCategory { Id = 2, Name = "Category 2" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" },
                new Product { Id = 3, Name = "Product 3" }
                );

            modelBuilder.Entity<ProductCategoryProduct>().HasData(
                new ProductCategoryProduct { ProductCategoryId = 1, ProductId = 1 },
                new ProductCategoryProduct { ProductCategoryId = 2, ProductId = 2 },
                new ProductCategoryProduct { ProductCategoryId = 1, ProductId = 3 }
                );
        }
    }
}