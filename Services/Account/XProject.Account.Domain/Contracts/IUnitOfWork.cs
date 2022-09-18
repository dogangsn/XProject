using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Shared.Accounts;

namespace XProject.Account.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task MigrateDatabase(Tenant _tenant);
    }
}
