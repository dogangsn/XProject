using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Account.Domain.Contracts;
using XProject.Account.Infrastructure.Persistence;
using XProject.Shared.Accounts;

namespace XProject.Account.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected XProjectDbContext _context;
        private readonly IMediator _mediator;

        public UnitOfWork(XProjectDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
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

        public async Task MigrateDatabase(Tenant _tenant)
        {
            var builder = new DbContextOptionsBuilder<XProjectDbContext>();
            builder.UseSqlServer(_tenant.ConnectionString);
            using (var db = new XProjectDbContext(builder.Options, _mediator))
            {
                await db.Database.MigrateAsync();
            }
        }

    }
}
