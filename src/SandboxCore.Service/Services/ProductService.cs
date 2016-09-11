using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using SandboxCore.Data;
using SandboxCore.Service.Models;
using SandboxCore.Service.Services.Interfaces;

namespace SandboxCore.Service.Services
{
    public class ProductService : IProductService
    {
        private CommandDbContext db;
        private IMapper mapper;

        public ProductService(CommandDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IReadOnlyCollection<ProductSummary> GetAllProductSummaries()
        {
            var summary = db.Products
                .Select(p => new ProductSummary()
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        ProductDescription = p.ProductDescription,
                        ProductCategoryName = p.ProjectCategory.ProductCategoryName
                    }).ToList();

            //var summary = (
            //    from p in db.Products
            //    select new { ProductId = p.ProductId, ProductCategoryName = p.ProjectCategory.ProductCategoryName }).ToList();

            return null;
        }
    }
}
