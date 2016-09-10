using System;

namespace SandboxCore.Queries.Project
{
    public class GetProjectQueryResult : IQueryResult
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
