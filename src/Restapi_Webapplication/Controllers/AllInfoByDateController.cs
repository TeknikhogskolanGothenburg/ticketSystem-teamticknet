﻿using System;
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

		
		[HttpDelete]
		public void Delete([FromBody]int id)
		{
			tbd.DeleteEventsAndVenues(id);
		}

		[HttpPost]
		public void Post([FromBody]AllEventsByDate allEvents)
		{
			tbd.AddAllEventsByDate(allEvents);
		}
		

		
		
	}
}