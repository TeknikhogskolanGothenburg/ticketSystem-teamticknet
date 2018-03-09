﻿using System;
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
		TicketApi ticketApi = new TicketApi();
		public IActionResult StartPage()
        {
            return View();
        }

        public IActionResult Venues(string Vname, string address, string city, string country)
        {
			if (!string.IsNullOrEmpty(Vname))
			{
			
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

		public IActionResult Events(string name, string description)
		{
			if (!string.IsNullOrEmpty(name))
			{
				
				ticketApi.EventsAdd(new TicketEvent()
				{
					EventName = name,
					EventHtmlDescription = description
				});
			}
			return View();
		}

        public async Task<IActionResult> UserRegAsync(string Fname, string Lname, string email)
        {
            if (!string.IsNullOrEmpty(Fname))
            {

				await ticketApi.AddUser(new UserReg()
				{
					Firstname = Fname,
					Lastname = Lname,
					Email = email
				});
            }
            return View();

        }

		public IActionResult ShowAllEvents()
		{
			return View(ticketApi.GetEventsAndVenues());
		}

		public IActionResult Delete(int EventId)
		{

			
			ticketApi.DeleteEventInfo(EventId);

			return Content("Successfull delete");
		}





		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
