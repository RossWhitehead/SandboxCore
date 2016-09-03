using System.Threading.Tasks;

namespace SandboxCore.Queries
{
    public interface IQueryHandler<TQuery, TResult>
       where TQuery : IQuery
       where TResult : IQueryResult
    {
        Task<TResult> Execute(TQuery query);
    }
}
