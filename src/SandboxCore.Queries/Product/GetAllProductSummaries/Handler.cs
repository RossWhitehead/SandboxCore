using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SandboxCore.Data;

namespace SandboxCore.Queries.Product.GetAllProductSummaries
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly SandboxCoreDbContext db;

        public Handler(SandboxCoreDbContext db)
        {
            this.db = db;
        }

        public Result Handle(Query message)
        {
            var summaries = db.Products
               .Select(p => new Result.ProductSummary()
               {
                   ProductId = p.ProductId,
                   ProductName = p.ProductName,
                   ProductDescription = p.ProductDescription,
                   ProductCategoryName = p.ProjectCategory.ProductCategoryName
               }).ToList();

            var result = new Result();
            result.ProductSummaries = new ReadOnlyCollection<Result.ProductSummary>(summaries);

            return result;
        }
    }
}
