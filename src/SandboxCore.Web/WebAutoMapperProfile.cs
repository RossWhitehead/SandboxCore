using AutoMapper;

namespace SandboxCore.Web
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            // Projects
            CreateMap<Queries.GetAllProjects.QueryResult.Project, Features.Project.IndexViewModel>();
        }
    }
}