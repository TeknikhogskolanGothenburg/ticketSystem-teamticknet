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
	[Route("api/Venues")]
	public class VenuesController : ControllerBase
	{
		//      // GET api/Venues
		//      [HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		TicketDatabase database = new TicketDatabase();

		//Get api/Venues
		[HttpGet("{query}")]
		public List<Venue> Get(string query)
		{
			return TicketDatabase.VenuesSpecific(query);
		}

		[HttpPost]
		public void Post([FromBody]JObject data)
		{
			Venue venue = data["Venue"].ToObject<Venue>();
			database.VenueAdd(venue.VenueName, venue.Address, venue.City, venue.Country);


		}




		//     // POST api/Venues
		//     [HttpPost]
		//     public void Post([FromBody]string value)
		//     {
		//return database.VenueAdd(["Vname"].value, ["Address"].value, )
		//     }

		//     // PUT api/Venues/5
		//     [HttpPut("{id}")]
		//     public void Put(int id, [FromBody]string value)
		//     {
		//     }

		//     // DELETE api/Venues/5
		//     [HttpDelete("{id}")]
		//     public void Delete(int id)
		//     {
		//     }
	}
}
