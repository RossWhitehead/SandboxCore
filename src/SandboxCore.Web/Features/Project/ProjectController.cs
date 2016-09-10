using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SandboxCore.Queries;
using SandboxCore.Queries.Project;
using System.Threading.Tasks;
using SandboxCore.Commands;
using System.Collections.Generic;

namespace SandboxCore.Web.Features.Project
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
            var queryResult = await queryDispatcher.Dispatch<GetAllProjectsQuery, GetAllProjectsQueryResult>(new GetAllProjectsQuery());
            var vm = this.mapper.Map<IEnumerable<IndexViewModel>>(queryResult.Projects);
            return View("Index", vm);
        }

        // GET: /<controller>/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var queryResult = await queryDispatcher.Dispatch<GetProjectQuery, GetProjectQueryResult>(new GetProjectQuery()
            {
                ProjectId = id
            });

            return View("Details", queryResult);
        }


        // GET: /<controller>/
        public IActionResult Create()
        {
            return View("Create");
        }

        //// POST: /<controller>/
        //[HttpPost]
        //public IActionResult Create(Project project)
        //{
        //    return View("Create");
        //}
    }
}
