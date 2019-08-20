using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tt.App.Data.EfCore.UnitTests
{
    public class AppDbContextTests
    {
        private DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HasNoSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("HasNoSeedData");
            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                var products = context.Products.ToList();

                Assert.AreEqual(0, products.Count());
            }
        }

        [Test]
        public void HasSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("HasSeedData");
            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                var products = context.Products.ToList();

                Assert.AreEqual(3, products.Count());
            }
        }
    }
}