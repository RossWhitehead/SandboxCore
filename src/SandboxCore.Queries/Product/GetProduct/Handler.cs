using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using MediatR;
using SandboxCore.Data;

namespace SandboxCore.Queries.Product.GetProduct
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly QueryDbContext db;

        public Handler(QueryDbContext db)
        {
            this.db = db;
        }
        public Result Handle(Query query)
        {
            return db.Products.ProjectTo<Result>().First();
        }
    }
}
