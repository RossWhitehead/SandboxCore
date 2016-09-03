using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            var handler = (IQueryHandler<TParameter, TResult>)serviceProvider.GetService(typeof(IQueryHandler<TParameter, TResult>));
            return await handler.Execute(query);
        }
    }
}
