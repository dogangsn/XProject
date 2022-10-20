﻿using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace XProject.Identity.Infrastructure.Persistence
{
    public class ConfigurationDataContext : ConfigurationDbContext
    {
        public ConfigurationDataContext(DbContextOptions<ConfigurationDbContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Console.WriteLine("OnModelCreating invoking...");

            base.OnModelCreating(modelBuilder);

            // Map the entities to different tables here
            //modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResource>().ToTable("mytesttable");

            Console.WriteLine("...OnModelCreating invoked");
        }
    }

    public class ConfigurationDataDesignTimeFactory : IDesignTimeDbContextFactory<ConfigurationDataContext>
    {
        public ConfigurationDataContext CreateDbContext(string[] args)
        {
           // var configuration = new ConfigurationBuilder()
           //.SetBasePath(Directory.GetCurrentDirectory())
           //.AddJsonFile("appsettings.json")
           //.Build();
           // var connectionString = configuration.GetConnectionString("DefaultConnection");
            var dbContextBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>();

            dbContextBuilder.UseSqlServer("Server=DG;Database=AdminIdentityDb;User Id=sa;Password=123D654!;", postGresOptions => postGresOptions.MigrationsAssembly(typeof(ConfigurationDataDesignTimeFactory).GetTypeInfo().Assembly.GetName().Name));
            // DbContextOptions<ConfigurationDbContext> ops = dbContextBuilder.Options;

            // dbContextBuilder.UseSqlServer(connectionString);

            return new ConfigurationDataContext(dbContextBuilder.Options, new ConfigurationStoreOptions());

            //  throw new NotImplementedException();
        }
    }
}
