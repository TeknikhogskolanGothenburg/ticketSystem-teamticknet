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
    [Route("api/AllInfo")]
    public class AllInfoByDateController : ControllerBase
    {
		TicketDatabase tbd = new TicketDatabase();

		// GET api/AllInfo
		[HttpGet]
		public List<AllEventsByDate> Get()
		{
			List<AllEventsByDate> allEvents = new List<AllEventsByDate>();
			allEvents.Add(new AllEventsByDate()
			{
				EventStartDateTime = DateTime.Now, //Visar nya event (ej de som passerat datumet)
			});
			return tbd.EventDateFindEventsAndVenues().Where(x => x.EventStartDateTime >= allEvents[0].EventStartDateTime).ToList();
		}

		
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			TicketSystem.DatabaseRepository.TicketDatabase.DeleteEventsAndVenues(id);
		}

		
		
	}
}