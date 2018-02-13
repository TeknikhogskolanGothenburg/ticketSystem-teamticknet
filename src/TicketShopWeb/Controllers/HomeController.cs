using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketShopWeb.Models;

namespace TicketShopWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Venues(string name, string address, string city, string country)
        {
         if (!(Request.Form["Vname"] == ""))
			{
				name = Request.Form["Vname"];
				address = Request.Form["Address"];
				city = Request.Form["City"];
				country = Request.Form["Country"];

				return RedirectToRoute("/api", "/Venues", "/POST");

			}
			return View("/Home", "/Venues");
			

			// Controllern som ska redirekta oss till POST när admin klickar på submit knappen 
				//return RedirectToRoute("/api", "/Venues", "/POST");
			
			
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
