﻿namespace SandboxCore.Queries.Product.GetProduct
{
    public class Result
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }
}