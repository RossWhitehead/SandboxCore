using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SandboxCore.Web.Features.Product
{
    public class ProductController : Controller
    {
        private IMediator mediator;
        private ILogger<ProductController> logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            logger.LogInformation(LoggingEvents.ViewList, "View List");
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
            var result = mediator.Send(new Queries.Product.GetProductForEdit.Query() { ProductId = id });
            return View("Edit", result);
        }

        // POST: /<controller>/Create
        [HttpPost]
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
