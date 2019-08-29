using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tt.App.Data.EfCore.UnitTests
{
    public class DbContextTestBase
    {
        protected DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        protected AppDbContext appDbContext;

        [SetUp]
        public void BaseSetUp()
        {
            BuildDbContext();
        }

        [TearDown]
        public void BaseTearDown()
        {
            appDbContext.Dispose();
            optionsBuilder = null;
        }

        protected void BuildDbContext()
        {
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase("HasSeedData");
            appDbContext = new AppDbContext(optionsBuilder.Options);
            appDbContext.Database.EnsureCreated();
        }
    }
}