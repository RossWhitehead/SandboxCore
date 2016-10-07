using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SandboxCore.Queries;
using SandboxCore.Queries.Project;
using SandboxCore.Web.Tests.SutBuilders;
using SandboxCore.Web.Tests.TestFixtureBuilders;
using Xunit;

namespace SandboxCore.Web.Tests.ControllerTests
{
    public class ProjectControllerTests
    {
        [Fact]
        public async Task Index_ReturnsIndexView()
        {
            // Arrange
            var queryResult = new GetAllProjectsQueryResultBuilder().Build();

            var mockQueryDispatcher = new Mock<IQueryDispatcher>();
            mockQueryDispatcher
                .Setup(qd => qd.Dispatch<GetAllProjectsQuery, GetAllProjectsQueryResult>(It.IsAny<GetAllProjectsQuery>()))
                .ReturnsAsync(queryResult);

            var sut = new ProjectControllerBuilder().WithQueryDispatcher(mockQueryDispatcher.Object).Build();

            // Act
            var result = await sut.Index() as AutoMapViewResult;

            // Assert
            mockQueryDispatcher
                .Verify(qd => qd.Dispatch<GetAllProjectsQuery, GetAllProjectsQueryResult>(It.IsAny<GetAllProjectsQuery>()),
                        Times.Once);
            Assert.Equal<string>("Index", result.View.ViewName);
        }
    }
}
