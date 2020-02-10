using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILoggerFactory LoggerFactory;
        private readonly IHostEnvironment HostEnvironment;

        #region DI
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ILoggerFactory loggerFactory,
            IHostEnvironment hostEnvironment
        ) : base(options)
        {
            LoggerFactory = loggerFactory;
            HostEnvironment = hostEnvironment;
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (HostEnvironment.IsDevelopment())
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLoggerFactory(LoggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Distributor> Distributors { get; set; }
    }
}
