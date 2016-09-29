using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SandboxCore.Data;
using Xunit;

namespace SandboxCore.Projection.Tests
{
    public class ProjectionTests
    {
        public ProjectionTests()
        {
        }

        [Fact]
        public void WithoutAutoMapper()
        {
            QueryDbContext db = new Data.QueryDbContext();
            var productSummaries = db.Products.Select(p => new
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductCategoryName = p.ProductCategory.ProductCategoryName
            }).ToList();
        }

        [Fact]
        public void WithAutoMapperQueryableExtensions()
        {
            Mapper.Initialize(cfg => cfg
                .CreateMap<Data.Models.Product, ProductSummaryViewModel>()
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(p => p.ProductCategory.ProductCategoryName)));

            QueryDbContext db = new Data.QueryDbContext();

            var productSummaries = db.Products.ProjectTo<ProductSummaryViewModel>().ToList();
        }

        public class ProductSummaryViewModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductCategoryName { get; set; }
        }
    }
}
