using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SandboxCore.Data.Models;

namespace SandboxCore.Data
{
    public class SandboxCoreDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SandboxCore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Project>()
                .Property(p => p.LastUpdated)
                .HasDefaultValueSql("GetDate()");

            modelBuilder
                .Entity<WorkItem>()
                .Property(wi => wi.LastUpdated)
                .HasDefaultValueSql("GetDate()");

            modelBuilder
                .Entity<ProductCategory>()
                .Property(pc => pc.LastUpdated)
                .HasDefaultValueSql("GetDate()");

            modelBuilder
                .Entity<Product>()
                .Property(p => p.LastUpdated)
                .HasDefaultValueSql("GetDate()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
