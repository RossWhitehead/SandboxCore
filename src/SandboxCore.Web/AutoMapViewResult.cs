using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SandboxCore.Web
{
    public class AutoMapViewResult : ActionResult
    {
        public IMapper Mapper { get; private set; }
        public Type SourceType { get; private set; }
        public Type DestinationType { get; private set; }
        public ViewResult View { get; private set; }

        public AutoMapViewResult(IMapper mapper, Type sourceType, Type destinationType, ViewResult view)
        {
            Mapper = mapper;
            SourceType = sourceType;
            DestinationType = destinationType;
            View = view;
        }

        public override void ExecuteResult(ActionContext context)
        {
            var model = Mapper.Map(View.ViewData.Model, SourceType, DestinationType);

            View.ViewData.Model = model;

            View.ExecuteResult(context);
        }
    }
}
