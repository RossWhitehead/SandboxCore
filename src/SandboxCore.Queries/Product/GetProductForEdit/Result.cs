using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SandboxCore.Queries.Product.GetProductForEdit
{
    public class Result
    {
        [HiddenInput]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [MinLength(2)]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [DisplayName("Product Description")]
        [MinLength(2)]
        [MaxLength(1000)]
        public string ProductDescription { get; set; }

        public int ProductCategoryId { get; set; }

        public IReadOnlyCollection<SelectListItem> ProductCategories { get; set; }

        public class ProductCategory
        {
            public int ProductCategoryId { get; set; }
            public string ProductCategoryName { get; set; }
        }
    }
}