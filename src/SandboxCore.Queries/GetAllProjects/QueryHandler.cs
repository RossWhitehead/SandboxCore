using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SandboxCore.Data;
using SandboxCore.Queries;

namespace SandboxCore.Query.GetAllProjects
{
    public class QueryHandler : IQueryHandler<Query, QueryResult>
    {
        private SandboxCoreDbContext db;

        public QueryHandler(SandboxCoreDbContext db)
        {
            this.db = db;
        }

        public async Task<QueryResult> Execute(Query query)
        {
            var data = await db.Projects.ToListAsync();

            var queryResult = new QueryResult();

            var projects = data.Select(p => new QueryResult.Project()
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                LastUpdated = p.LastUpdated
            }).ToList();

            queryResult.Projects = new ReadOnlyCollection<QueryResult.Project>(projects);

            return queryResult;
        }
    }
}
