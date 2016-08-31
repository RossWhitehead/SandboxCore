using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SandboxCore.Service.Services;
using SandboxCore.Web.Controllers;

namespace SandboxCore.Web.Tests.SutBuilders
{
    internal class ProjectControllerBuilder
    {
        private IMapper mapper;
        private ProjectService projectService;

        internal ProjectControllerBuilder()
        {
            this.mapper = new Mock<IMapper>().Object;
            this.projectService = new Mock<ProjectService>().Object;
        }

        internal ProjectControllerBuilder WithMapper(IMapper mapper)
        {
            this.mapper = mapper;
            return this;
        }

        internal ProjectController Build()
        {
            return new ProjectController(this.mapper, this.projectService);
        }
    }
}
