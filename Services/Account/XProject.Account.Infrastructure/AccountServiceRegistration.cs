using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Account.Domain.Contracts;
using XProject.Account.Infrastructure.Persistence;
using XProject.Account.Infrastructure.Repositories;
using XProject.Shared.Accounts;

namespace XProject.Account.Infrastructure
{
    public static class AccountServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<XProjectDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.Configure<TenantDbSettings>(configuration.GetSection("TemantDbSettings"));
            //services.AddSingleton<ITenantDbSettings>(sp =>
            //{
            //    return sp.GetRequiredService<TenantDbSettings>();
            //});


        }
    }
}
