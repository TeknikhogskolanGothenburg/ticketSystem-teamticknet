using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibraryTicketShop;
using TicketSystem.DatabaseRepository;

namespace Restapi_Webapplication.Controllers
{
    [Produces("application/json")]
    [Route("api/AllInfoByDate")]
    public class AllInfoByDateController : Controller
    {
		TicketDatabase tbd = new TicketDatabase();

		[HttpGet]
		public List<object> Get(string date1, string date2)
		{
			return tbd.EventDateFindEventsAndVenues(date1, date2);
		}
	}
}