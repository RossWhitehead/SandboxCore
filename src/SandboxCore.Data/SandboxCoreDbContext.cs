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
        public DbSet<Product> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SandboxCore;Trusted_Connection=True;");
        }
    }
}
