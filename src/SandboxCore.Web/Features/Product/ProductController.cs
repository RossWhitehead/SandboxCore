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
            var vm = mediator.Send(new Query.GetAllProductSummaries.Query());
            return View("Index", vm);
        }

        // GET: /<controller>/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: /<controller>/Create
        public IActionResult Create(ProductEdit model)
        {
            return View("Create");
        }

        // GET: /<controller>/Edit/1
        public IActionResult Edit(int id)
        {
            var product = mediator.Send(new Query.GetProduct.Query() { ProductId = id });
            var vm = mapper.Map<ProductView>(product);
            return View("Edit", vm);
        }

        // POST: /<controller>/Create
        public IActionResult Edit(ProductEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("Index");
        }




    }
}
