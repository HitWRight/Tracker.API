using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Tracker.API.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    public class UsageBufferController : Controller
    {
        [HttpGet("{computerId}")]
        public IEnumerable<UsageBuffer> Get(int computerId)
        {
            return new TimetrackDBContext()
                .UsageBuffer
                .Where(n => n.ComputerId == computerId)
                .ToList();
        }

        [HttpPost]
        public void Post([FromBody]Dictionary<string,string> data)
        {
            var db = new TimetrackDBContext();
            db.UsageBuffer.Add(new UsageBuffer() { UsedProgram = data["usedProgram"], ComputerId = Convert.ToInt32(data["computerId"]), Timestamp = DateTime.Now });
            db.SaveChanges();
        } 
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
