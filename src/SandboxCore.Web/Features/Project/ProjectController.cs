using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SandboxCore.Service.Models;
using SandboxCore.Queries;
using System.Threading.Tasks;
using SandboxCore.Commands;

namespace SandboxCore.Web.Controllers
{
    public class ProjectController : Controller
    {
        private IMapper mapper;
        private IQueryDispatcher queryDispatcher;
        private ICommandDispatcher commandDispatcher;

        public ProjectController(IMapper mapper, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.mapper = mapper;
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var result = await queryDispatcher.Dispatch<Query.GetAllProjects.Query, Query.GetAllProjects.QueryResult>(new Query.GetAllProjects.Query());
            return View("Index", null);
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
