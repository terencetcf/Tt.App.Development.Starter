using Microsoft.Extensions.Logging;
using System;
using Tt.App.Data.EfCore;

namespace Tt.App.Repositories
{
    public abstract class EfCoreRepositoryBase : IDisposable
    {
        protected readonly AppDbContext appDbContext;
        protected readonly ILogger<EfCoreRepositoryBase> logger;

        protected bool disposedValue = false;

        public EfCoreRepositoryBase(AppDbContext appDbContext)
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
