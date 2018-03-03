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

		public IActionResult SearchAllByDate()
		{
			return View();
		}

        public IActionResult Index()
        {
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
