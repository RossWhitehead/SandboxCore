using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SandboxCore.Web
{
    public class BaseController : Controller
    {
        private IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected AutoMapViewResult AutoMapView<TDestination>(ViewResult viewResult)
        {
            return new AutoMapViewResult(this.mapper, viewResult.ViewData.Model.GetType(), typeof(TDestination), viewResult);
        }
    }
}
