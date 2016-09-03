using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandboxCore.Web.Tests.SutBuilders;
using Xunit;

namespace SandboxCore.Web.Tests.ControllerTests
{
    public class ProjectControllerTestsFixture
    {
        public ProjectControllerTestsFixture()
        {

        }

        public int MyProperty { get; set; }
    }

    public class ProjectControllerTests
    {
        [Fact]
        public void IndexReturnsIndexView()
        {
            //// Arrange
            //var sut = new ProjectControllerBuilder().Build();

            //// Act
            //var result = sut.Index() as ViewResult;

            //// Assert
            //Assert.Equal<string>("Index", result.ViewName);
        }
    }
}
