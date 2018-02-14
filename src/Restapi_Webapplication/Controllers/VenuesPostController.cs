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
	[Route("api/[controller]")]
	public class VenuesPostController : Controller
	{
		TicketDatabase database = new TicketDatabase();
		//POST api/Venues
		[HttpPost]
		public void Post([FromBody]JObject data)
		{
				Venue venue = data["Venue"].ToObject<Venue>();
			 database.VenueAdd(venue.VenueName, venue.Address, venue.City, venue.Country);


		}
	}
}