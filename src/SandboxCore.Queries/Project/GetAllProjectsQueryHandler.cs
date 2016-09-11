using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SandboxCore.Data;

namespace SandboxCore.Queries.Project
{
    public class GetAllProjectsQueryHandler : IQueryHandler<GetAllProjectsQuery, GetAllProjectsQueryResult>
    {
        private QueryDbContext db;

        public GetAllProjectsQueryHandler(QueryDbContext db)
        {
            this.db = db;
        }

        public async Task<GetAllProjectsQueryResult> Execute(GetAllProjectsQuery query)
        {
            var data = await db.Projects.ToListAsync();

            var queryResult = new GetAllProjectsQueryResult();

            var projects = data.Select(p => new GetAllProjectsQueryResult.Project()
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                LastUpdated = p.LastUpdated
            }).ToList();

            queryResult.Projects = new ReadOnlyCollection<GetAllProjectsQueryResult.Project>(projects);

            return queryResult;
        }
    }
}
