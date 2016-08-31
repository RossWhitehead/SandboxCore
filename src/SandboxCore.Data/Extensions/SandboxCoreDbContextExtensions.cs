using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Data.Models;

namespace SandboxCore.Data.Extensions
{
    public static class SandboxCoreDbContextExtensions
    {
        public static void SeedData(this SandboxCoreDbContext dbContext)
        {
            if (dbContext.Projects.Count() == 0)
            {
                dbContext.Projects.AddRange(
                    new Project() { ProjectName = "Project 1" },
                    new Project() { ProjectName = "Project 2" },
                    new Project() { ProjectName = "Project 3" }
                    );
                dbContext.SaveChanges();
            }
        }
    }
}
