using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SandboxCore.Commands;
using SandboxCore.Queries;
using SandboxCore.Service.Services;
using SandboxCore.Web.Features.Project;

namespace SandboxCore.Web.Tests.SutBuilders
{
    internal class ProjectControllerBuilder
    {
        private IMapper mapper;
        private IQueryDispatcher queryDispatcher;
        private ICommandDispatcher commandDispatcher;

        internal ProjectControllerBuilder()
        {
            this.mapper = new Mock<IMapper>().Object;
            this.queryDispatcher = new Mock<IQueryDispatcher>().Object;
            this.commandDispatcher = new Mock<ICommandDispatcher>().Object;
        }

        internal ProjectControllerBuilder WithMapper(IMapper mapper)
        {
            this.mapper = mapper;
            return this;
        }

        internal ProjectControllerBuilder WithQueryDispatcher(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            return this;
        }

        internal ProjectControllerBuilder WithCommandDispatcher(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
            return this;
        }

        internal ProjectController Build()
        {
            return new ProjectController(this.mapper, this.queryDispatcher, this.commandDispatcher);
        }
    }
}
