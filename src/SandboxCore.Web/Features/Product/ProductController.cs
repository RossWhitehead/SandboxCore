using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SandboxCore.Web.Features.Product
{
    public class ProductController : Controller
    {
        private IMapper mapper;
        private IMediator mediator;

        public ProductController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = this.mediator.Send(new Queries.Product.GetAllProductSummaries.Query());
            return View("Index", result);
        }

        // GET: /<controller>/Create
        public IActionResult Create()
        {
            return this.View("Create", new Commands.Product.Create.Command());
        }

        // POST: /<controller>/Create
        public IActionResult Create(Commands.Product.Create.Command command)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Create", command);
            }


            return this.View("Create");
        }

        // GET: /<controller>/Edit/1
        public IActionResult Edit(int id)
        {
            //var product = mediator.Send(new Query.GetProduct.Query() { ProductId = id });
            //var vm = new IndexViewModel()
            //{
            //    Prod mapper.Map<IndexViewModel>(product)
            //}
            //return View("Edit", vm);

            throw new NotImplementedException();
        }

        // POST: /<controller>/Create
        public IActionResult Edit(Commands.Product.Create.Command model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("Index");
        }




    }
}
