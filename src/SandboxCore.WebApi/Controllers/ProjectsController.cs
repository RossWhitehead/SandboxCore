using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SandboxCore.Data;
using SandboxCore.WebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SandboxCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]QueryDbContext db)
        {
            var projects = await db.Projects.Select(p => ModelFactory.Create(p)).ToListAsync();

            return new ObjectResult(projects);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
