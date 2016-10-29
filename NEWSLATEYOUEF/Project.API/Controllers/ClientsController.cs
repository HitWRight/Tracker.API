using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models;

namespace Project.API.Controllers
{
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return new ProjectDBContext().Client;
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var client = new ProjectDBContext().Client.FirstOrDefault(n => n.Id == id);
            if (client == null)
                return new NotFoundObjectResult(client);
            return Ok(client);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var client = new ProjectDBContext().Client.FirstOrDefault(n => n.Id == Convert.ToInt16(id));
            if (client == null)
                return new NotFoundObjectResult(client);
            return Ok(client);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]IDictionary<string,string> data)
        {
            var cli = new Client() { Name = data["name"], Description = data["description"] };
            var db = new ProjectDBContext();
            db.Client.Add(cli);
            db.SaveChangesAsync();
            return RedirectToAction("Clients");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]IDictionary<string, string> data)
        {
            var db = new ProjectDBContext();
            var cli = db.Client.FirstOrDefault(n => n.Id == id);
            if (cli == null)
                return new NotFoundObjectResult(cli);
            cli.Name = data["name"];
            cli.Description = data["description"];
            db.SaveChangesAsync();
            return Ok(cli);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new ProjectDBContext();
            var cli = db.Client.FirstOrDefault(n => n.Id == id);
            if (cli == null)
                return new NotFoundObjectResult(cli);
            db.Client.Remove(cli);
            db.SaveChangesAsync();
            return Ok(null);
        }
    }
}
