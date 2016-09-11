using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SandboxCore.Data;

namespace SandboxCore.Queries.Product.GetProductForEdit
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

            result.ProductCategories = new ReadOnlyCollection<Result.ProductCategory>(
                db.ProductCategories
                    .Select(pc => new Result.ProductCategory()
                    {
                        ProductCategoryId = pc.ProductCategoryId,
                        ProductCategoryName = pc.ProductCategoryName
                    }).ToList());

            return result;
        }
    }
}
