using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Data.Models;

namespace SandboxCore.WebApi.Models
{
    public static class ModelFactory
    {
        public static ProjectModel Create(Project project)
        {
            return new ProjectModel()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName
            };
        }
    }
}
