using System.Collections.Generic;

namespace SandboxCore.Queries.Product.GetAllProductSummaries
{
    public class Result
    {
        public IReadOnlyCollection<ProductSummary> ProductSummaries;

        public class ProductSummary
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }

            public string ProductCategoryName { get; set; }
        }
    }
}