using System.Collections.Generic;

namespace SandboxCore.Query.GetProductForEdit
{
    public class Result
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int ProductCategoryId { get; set; }

        public IReadOnlyCollection<ProductCategory> ProductCategories { get; set; }

        public class ProductCategory
        {
            public int ProductCategoryId { get; set; }
            public string ProductCategoryName { get; set; }
        }
    }
}