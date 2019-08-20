using Microsoft.Extensions.Logging;
using Tt.App.Data.EfCore;

namespace Tt.App.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly AppDbContext appDbContext;
        protected readonly ILogger<RepositoryBase> logger;

        protected bool disposedValue = false;

        public RepositoryBase(AppDbContext appDbContext, ILogger<RepositoryBase> logger)
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    appDbContext.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}
