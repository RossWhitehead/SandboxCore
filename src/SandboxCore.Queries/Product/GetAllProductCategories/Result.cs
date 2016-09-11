using System.Collections.Generic;

namespace SandboxCore.Queries.Product.GetAllProductCategories
{
    public class Result
    {
        public IReadOnlyCollection<ProductCategory> ProductCategories;

        public class ProductCategory
        {
            public int ProductCategoryId { get; set; }
            public string ProductCategoryName { get; set; }
        }
    }
}