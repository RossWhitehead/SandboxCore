using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Data.Models;

namespace SandboxCore.Web.Tests.TestFixtureBuilders
{
    internal class ProjectBuilder
    {
        private Project project;

        internal ProjectBuilder()
        {
            project = new Project();
            project.ProjectId = 1;
            project.ProjectName = "Project 1";
        }

        internal ProjectBuilder WithProjectId(int projectId)
        {
            project.ProjectId = projectId;
            return this;
        }

        internal ProjectBuilder WithProjectName(string projectName)
        {
            project.ProjectName = projectName;
            return this;
        }

        internal Project Build()
        {
            return project;
        }
    }
}
