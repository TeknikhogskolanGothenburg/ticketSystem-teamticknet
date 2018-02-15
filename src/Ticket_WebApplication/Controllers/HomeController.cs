using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket_WebApplication.Models;

namespace Ticket_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index (UserReg obj)
        {
            if (ModelState.IsValid)
            {
                TicketSystemEntities db = new TicketSystemEntities();
                db.UserRegs.Add(obj);
                db.SaveChanges();
            }
            return View(obj);
        }
    }
}