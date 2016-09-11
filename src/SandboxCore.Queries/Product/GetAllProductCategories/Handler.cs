using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SandboxCore.Data;

namespace SandboxCore.Queries.Product.GetAllProductCategories
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly QueryDbContext db;

        public Handler(QueryDbContext db)
        {
            this.db = db;
        }

        public Result Handle(Query message)
        {
            var categories = db.ProductCategories
               .Select(p => new Result.ProductCategory()
               {
                   ProductCategoryId = p.ProductCategoryId,
                   ProductCategoryName = p.ProductCategoryName
               }).ToList();

            var result = new Result();
            result.ProductCategories = new ReadOnlyCollection<Result.ProductCategory>(categories);

            return result;
        }
    }
}
