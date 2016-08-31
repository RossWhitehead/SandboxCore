using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SandboxCore.Service.Models;
using System.Collections.ObjectModel;
using SandboxCore.Web.Models.Project;
using SandboxCore.Service.Services.Interfaces;

namespace SandboxCore.Web.Controllers
{
    public class ProjectController : Controller
    {
        private IMapper mapper;
        private IProjectService projectService;

        public ProjectController(IMapper mapper, IProjectService projectService)
        {
            this.mapper = mapper;
            this.projectService = projectService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var vm = mapper.Map<ReadOnlyCollection<ProjectSummary>>(projectService.GetAllProjects());
            return View("Index", vm);
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: /<controller>/
        [HttpPost]
        public IActionResult Create(Project project)
        {
            return View("Create");
        }
    }
}
