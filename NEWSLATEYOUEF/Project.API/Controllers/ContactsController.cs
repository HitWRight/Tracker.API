using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.API.Models;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    //How to use other controller base route
    [Route("Clients/{clientId}/[controller]/")]
    public class ContactsController : Controller
    {
        [HttpGet]
        public IEnumerable<Contact> GetAll(int clientId)
        {
            var db = new ProjectDBContext();
            return db.Set<Contact>().FromSql("dbo.GetClientContacts @Id={0}", clientId);
        }
        [HttpGet, Route("{ContactId}")]
        public IActionResult Get(int ContactId)
        {
            using (var db = new ProjectDBContext())
            {
                var con = db.Contact.FirstOrDefaultAsync(n => n.Id == ContactId);
                if (con != null)
                    return Ok(con);

            }

            return new NotFoundResult();

        }

        [HttpPost]
        public IActionResult Add(int clientId, [FromBody]IDictionary<string,string> data)
        {
            using (var db = new ProjectDBContext())
            {
                db.Contact.Add(new Contact()
                {
                    ClientId = clientId,
                    Name = data["name"],
                    Surname = data["surname"],
                    Email = data["email"],
                    Telephone = data["telephone"]
                });
                db.SaveChangesAsync();
            }
            //change to redirect...
            return Ok();
        }

        [HttpPut, Route("{ContactId}")]
        public IActionResult Update(int ContactId, [FromBody]IDictionary<string, string> data)
        {
            using (var db = new ProjectDBContext())
            {
                Contact con = db.Contact.FirstOrDefaultAsync(n => n.Id == ContactId).Result;
                if(con != null)
                {
                    con.Name = data["name"];
                    con.Surname = data["surname"];
                    con.Email = data["email"];
                    con.Telephone = data["telephone"];
                }
                db.SaveChangesAsync();
            }

            return Ok();
        }


        [HttpDelete, Route("{ContactId}")]
        public IActionResult Delete(int ContactId)
        {
            using (var db = new ProjectDBContext())
            {
                var con= db.Contact.FirstOrDefaultAsync(n => n.Id == ContactId).Result;
                if (con == null)
                    return new NotFoundObjectResult(con);
                db.Contact.Remove(con);
                db.SaveChangesAsync();
            }
            return Ok();
        }
        

    }
}
