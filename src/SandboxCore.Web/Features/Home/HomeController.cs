using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SandboxCore.Web.Resources;

namespace SandboxCore.Web.Features.Home
{
    public class HomeController : Controller
    {
        private IStringLocalizer<HomeController> localizer;
        private IStringLocalizer<CommonResource> commonLocalizer;

        public HomeController(IStringLocalizer<HomeController> localizer, IStringLocalizer<CommonResource> commonLocalizer)
        {
            this.localizer = localizer;
            this.commonLocalizer = commonLocalizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = localizer["Your application description page."];
            ViewData["WelcomeMessage"] = commonLocalizer["Welcome to the {0} page.", commonLocalizer["About"]];

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = localizer["Your contact page."];
            ViewData["WelcomeMessage"] = commonLocalizer["Welcome to the {0} page.", commonLocalizer["Contact"]];

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
