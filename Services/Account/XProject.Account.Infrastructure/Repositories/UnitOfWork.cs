using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Account.Domain.Contracts;
using XProject.Account.Infrastructure.Persistence;

namespace XProject.Account.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected XProjectDbContext _context;
        public UnitOfWork(XProjectDbContext context)
        {
            _context = context;
        }

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

        public Task MigrateDatabase(string connectionString)
        {
            throw new NotImplementedException();
        }

    }
}
