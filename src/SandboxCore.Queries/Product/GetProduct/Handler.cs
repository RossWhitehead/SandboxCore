using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var result = db.Products.Where(p => p.ProductId == query.ProductId)
                .Select(p => new Result()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    ProductCategoryId = p.ProjectCategory.ProductCategoryId
                }).First();

            return result;
        }
    }
}
