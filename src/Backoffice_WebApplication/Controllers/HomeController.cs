using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backoffice_WebApplication.Models;
using TicketSystem.RestApiClient;
using ClassLibraryTicketShop;




namespace TicketShopWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

			TicketApi ticketApi = new TicketApi();
			List<TicketEvent> getEvent = ticketApi.GetEvent("He");
			return View(getEvent);
			//List<Venue> sum = ticketApi.GetVenue("Te");
			//         return View();
		}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Venues(string Vname, string address, string city, string country)
        {
			if (!string.IsNullOrEmpty(Vname))
			{
				TicketApi ticketApi = new TicketApi();
				ticketApi.VenuesAdd(new Venue()
				{
					VenueName = Vname,
					Address = address,
					City = city,
					Country = country
				});
			}
			return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
