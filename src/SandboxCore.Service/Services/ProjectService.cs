using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SandboxCore.Data;
using SandboxCore.Service.Models;
using SandboxCore.Service.Services.Interfaces;

namespace SandboxCore.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CommandDbContext db;
        private readonly IMapper mapper;

        public ProjectService(CommandDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IReadOnlyCollection<Project> GetAllProjects()
        {
            var projects = mapper.Map<List<Project>>(db.Projects.ToList());
            return new ReadOnlyCollection<Project>(projects);
        }
    }
}
