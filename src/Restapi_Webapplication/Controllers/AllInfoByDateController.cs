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
    [Route("api/AllInfoByDate")]
    public class AllInfoByDateController : ControllerBase
    {
		TicketDatabase tbd = new TicketDatabase();

		[HttpGet]
		public List<AllEventsByDate> Get(string date1, string date2)
		{
			return tbd.EventDateFindEventsAndVenues(date1, date2);
		}
	}
}