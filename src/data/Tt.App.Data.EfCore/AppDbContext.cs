using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

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

            var cat1Id = Guid.NewGuid().ToString();
            var cat2Id = Guid.NewGuid().ToString();

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = cat1Id, Name = "Category 1" },
                new ProductCategory { Id = cat2Id, Name = "Category 2" }
                );

            var product1Id = Guid.NewGuid().ToString();
            var product2Id = Guid.NewGuid().ToString();
            var product3Id = Guid.NewGuid().ToString();

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = product1Id, Name = "Product 1" },
                new Product { Id = product2Id, Name = "Product 2" },
                new Product { Id = product3Id, Name = "Product 3" }
                );

            modelBuilder.Entity<ProductCategoryProduct>().HasData(
                new ProductCategoryProduct { ProductCategoryId = cat1Id, ProductId = product1Id },
                new ProductCategoryProduct { ProductCategoryId = cat2Id, ProductId = product2Id },
                new ProductCategoryProduct { ProductCategoryId = cat1Id, ProductId = product3Id }
                );
        }
    }
}