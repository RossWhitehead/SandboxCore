using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SandboxCore.Query;
using SandboxCore.Service.Models;
using SandboxCore.Service.Services.Interfaces;
using SandboxCore.Web.Models.Product;

namespace SandboxCore.Web.Controllers
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
            var vm = this.mediator.Send(new Query.GetAllProductSummaries.Query());
            return View("Index", vm);
        }

        // GET: /<controller>/Create
        public IActionResult Create()
        {
            return this.View("Create");
        }

        // POST: /<controller>/Create
        public IActionResult Create(Commands.Product.Create.Command command)
        {
            return this.View("Create");
        }

        // GET: /<controller>/Edit/1
        public IActionResult Edit(int id)
        {
            var product = mediator.Send(new Query.GetProduct.Query() { ProductId = id });
            var vm = mapper.Map<ProductView>(product);
            return View("Edit", vm);
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
