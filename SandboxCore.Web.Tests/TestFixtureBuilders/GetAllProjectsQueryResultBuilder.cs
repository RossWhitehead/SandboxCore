using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Queries.Project;

namespace SandboxCore.Web.Tests.TestFixtureBuilders
{
    internal class GetAllProjectsQueryResultBuilder
    {
        private List<GetAllProjectsQueryResult.Project> projects;

        internal GetAllProjectsQueryResultBuilder()
        {
            projects = new List<GetAllProjectsQueryResult.Project>()
            {
                new GetAllProjectsQueryResult.Project()
                {
                    ProjectId = 1,
                    ProjectName = "Test Project 1",
                    LastUpdated = DateTime.Now
                },
                new GetAllProjectsQueryResult.Project()
                {
                    ProjectId = 2,
                    ProjectName = "Test Project 2",
                    LastUpdated = DateTime.Now.AddDays(1)
                },
                new GetAllProjectsQueryResult.Project()
                {
                    ProjectId = 3,
                    ProjectName = "Test Project 3",
                    LastUpdated = DateTime.Now.AddDays(2)
                }
            };
        }

        internal GetAllProjectsQueryResultBuilder WithProjects(List<GetAllProjectsQueryResult.Project> projects)
        {
            this.projects = projects;
            return this;
        }

        internal GetAllProjectsQueryResult Build()
        {
            return new GetAllProjectsQueryResult()
            {
                Projects = new ReadOnlyCollection<GetAllProjectsQueryResult.Project>(this.projects)
            };
        }
    }
}
