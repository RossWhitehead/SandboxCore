using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SandboxCore.Data.Models;

namespace SandboxCore.Data
{
    public class QueryDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SandboxCore;Trusted_Connection=True;");
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override int SaveChanges()
        {
            throw new InvalidOperationException("The query context is read-only");
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new InvalidOperationException("The query context is read-only");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new InvalidOperationException("The query context is read-only");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new InvalidOperationException("The query context is read-only");
        }
    }
}
