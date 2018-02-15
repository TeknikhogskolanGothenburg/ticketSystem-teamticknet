﻿using System;
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
    [Route("api/Event")]
    public class EventController : Controller
    {
		TicketDatabase tbd = new TicketDatabase();

		[HttpGet("{query}")]
		public List<TicketEvent> Get(string query)
		{
			return tbd.EventFindSpecifik(query);
		}
	}
}