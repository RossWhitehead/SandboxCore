using AutoMapper;

namespace SandboxCore.Queries.Product
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            Mapper.Initialize(cfg => cfg
               .CreateMap<Data.Models.Product, Product.GetProduct.Result>()
               .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(p => p.ProductCategory.ProductCategoryId)));
        }
    }
}