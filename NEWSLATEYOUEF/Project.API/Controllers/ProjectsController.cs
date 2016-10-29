using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        [HttpGet]
        public IEnumerable<Models.Project> Get()
        {
            return new ProjectDBContext().Project;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Project = new ProjectDBContext().Project.FirstOrDefault(n => n.Id == id);
            if (Project == null)
                return new NotFoundObjectResult(Project);
            return Ok(Project);
        }

        [HttpPost]
        public IActionResult Post([FromBody]IDictionary<string, string> data)
        {
            var cli = new Models.Project() { Name = data["name"], Description = data["description"]};
            int a; if(int.TryParse(data["clientId"], out a)) cli.ClientId = a;


            var db = new ProjectDBContext();
            db.Project.Add(cli);
            db.SaveChangesAsync();
            return RedirectToAction("Projects");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]IDictionary<string, string> data)
        {
            var db = new ProjectDBContext();
            var cli = db.Project.FirstOrDefault(n => n.Id == id);
            if (cli == null)
                return new NotFoundObjectResult(cli);
            cli.Name = data["name"];
            cli.Description = data["description"];
            int a; if (int.TryParse(data["clientId"], out a)) cli.ClientId = a;
            db.SaveChangesAsync();
            return Ok(cli);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new ProjectDBContext();
            var cli = db.Project.FirstOrDefault(n => n.Id == id);
            if (cli == null)
                return new NotFoundObjectResult(cli);
            db.Project.Remove(cli);
            db.SaveChangesAsync();
            return Ok(null);
        }

    }
}
