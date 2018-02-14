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

        public IActionResult Venues(string name, string address, string city, string country)
        {
			return View();


            // Controllern som ska redirekta oss till POST när admin klickar på submit knappen 
            //return RedirectToRoute("/api", "/Venues", "/POST");



        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
