using System;
using System.Collections.Generic;

namespace SandboxCore.Queries.Project
{
    public class GetAllProjectsQueryResult : IQueryResult
    {
        public IReadOnlyCollection<Project> Projects { get; set; }

        public class Project
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public DateTime LastUpdated { get; set; }
        }
    }
}
