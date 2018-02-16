using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TicketSystem.DatabaseRepository;
using ClassLibraryTicketShop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restapi_Webapplication.Controllers
{
    [Produces("application/json")]
    [Route("api/SiteUser")]
    public class SiteUserController : Controller
    {
        TicketDatabase database = new TicketDatabase();
        // GET: api/SiteUser
        [HttpGet]
        public List<SiteUser> GetSiteUser(string query)
        {
            return database.SiteUserFind(query);
        }
       
        // POST: api/SiteUser
        [HttpPost]
        public void Post([FromBody]SiteUser user)
        {
               database.SiteUserAdd(user.Email, user.Password, user.IsVaild);

        }



        //// GET: api/SiteUser/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/SiteUser
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/SiteUser/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}


