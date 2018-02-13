using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using TicketSystem.DatabaseRepository.Model;

namespace Restapi_Webapplication.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VenuesPostController : Controller
    {
		TicketDatabase database = new TicketDatabase();
		//POST api/Venues
		[HttpPost]
			 public void Post([FromBody]string value)
		{
			//return database.VenueAdd(Request.Form["Vname"],  )
		 }
}
}