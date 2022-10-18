using System;
using System.Collections.Generic;
using System.Text;

namespace XProject.Identity.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
    }
}
