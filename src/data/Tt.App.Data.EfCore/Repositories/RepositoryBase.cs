using Microsoft.Extensions.Logging;
using System;

namespace Tt.App.Data.EfCore.Repositories
{
    public abstract class RepositoryBase : IDisposable
    {
        protected readonly AppDbContext appDbContext;
        protected readonly ILogger<RepositoryBase> logger;

        protected bool disposedValue = false;

        public RepositoryBase(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
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

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}
