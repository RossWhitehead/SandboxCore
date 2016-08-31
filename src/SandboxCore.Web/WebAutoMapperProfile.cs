using AutoMapper;
using SandboxCore.Web.Models.Project;

namespace SandboxCore.Web
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<Service.Models.Project, ProjectSummary>();
        }
    }
}