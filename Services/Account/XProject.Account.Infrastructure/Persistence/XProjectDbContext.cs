using MediatR;
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
        private readonly IMediator _mediator;
        public XProjectDbContext(DbContextOptions options, IMediator mediator) : base(options)
        { 
            _mediator = mediator;   
        }

        public DbSet<Products> Products { get; set; }

    }
}
