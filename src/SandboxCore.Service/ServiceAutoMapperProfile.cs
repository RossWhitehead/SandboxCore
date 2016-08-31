using AutoMapper;
using SandboxCore.Service.Models;

namespace SandboxCore.Service
{
    public class ServiceAutoMapperProfile : Profile
    {
        public ServiceAutoMapperProfile()
        {
            CreateMap<Data.Models.Project, Project>();
            CreateMap<Data.Models.Product, ProductSummary>();
        }
    }
}


