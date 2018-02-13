using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using TicketSystem.DatabaseRepository.Model;
using Microsoft.Extensions.Configuration;

namespace Restapi_Webapplication.Controllers
{
	[Route("api/[controller]")]
	public class VenuesController : ControllerBase
	{
        private readonly IConfiguration configuration;
        public Homecontroller(IConfiguration config)
        {
           configuration = config;
        }

        // GET api/Venues
        [HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		//Get api/Venues
		[HttpGet("{query}")]
		public List<Venue> Get(string query)
		{
			return TicketDatabase.VenuesSpecific(query);
		}


        // POST api/Venues
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Venues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Venues/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
