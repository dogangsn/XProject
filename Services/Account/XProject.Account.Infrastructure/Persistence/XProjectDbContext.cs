using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Account.Domain.Entities;

namespace XProject.Account.Infrastructure.Persistence
{
    public class XProjectDbContext : DbContext
    {
        public XProjectDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Products> Products { get; set; }

    }
}
