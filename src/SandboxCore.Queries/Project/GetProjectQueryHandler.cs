using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SandboxCore.Data;

namespace SandboxCore.Queries.Project
{
    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, GetProjectQueryResult>
    {
        private QueryDbContext db;

        public GetProjectQueryHandler(QueryDbContext db)
        {
            this.db = db;
        }

        public async Task<GetProjectQueryResult> Execute(GetProjectQuery query)
        {
            var data = await db.Projects.Where(p => p.ProjectId == query.ProjectId).FirstOrDefaultAsync();

            var queryResult = new GetProjectQueryResult()
            {
                ProjectId = data.ProjectId,
                ProjectName = data.ProjectName,
                LastUpdated = data.LastUpdated
            };

            return queryResult;
        }
    }
}
