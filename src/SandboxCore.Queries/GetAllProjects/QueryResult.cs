using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Queries;

namespace SandboxCore.Query.GetAllProjects
{
    public class QueryResult : IQueryResult
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
