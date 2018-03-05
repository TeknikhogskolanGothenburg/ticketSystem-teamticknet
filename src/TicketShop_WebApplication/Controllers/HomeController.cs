using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketShop_WebApplication.Models;
using TicketSystem.RestApiClient;
using ClassLibraryTicketShop;


namespace TicketShop_WebApplication.Controllers
{
    public class HomeController : Controller
    {
		TicketApi ticketApi = new TicketApi();
		public static List<AllEventsByDate> cart = new List<AllEventsByDate>();


		public IActionResult Index()
        {
            return RedirectToAction("AllEvents", "Home");
        }

		public IActionResult AllEvents()
		{
			return View(ticketApi.GetEventsAndVenues());
		}

		public IActionResult Buy(AllEventsByDate events)
		{
			if (events.EventName != null || events.EventName != "")
			{
				cart.Add(events);
			}

			return View();

		}

		public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
