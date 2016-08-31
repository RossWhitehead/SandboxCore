using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Service.Models;

namespace SandboxCore.Service.Services.Interfaces
{
    public interface IProjectService
    {
        IReadOnlyCollection<Project> GetAllProjects();
    }
}
