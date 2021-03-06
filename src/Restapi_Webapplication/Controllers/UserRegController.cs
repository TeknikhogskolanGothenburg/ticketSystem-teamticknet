﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TicketSystem.DatabaseRepository;
using ClassLibraryTicketShop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restapi_Webapplication.Controllers
{
    [Produces("application/json")]
    [Route("api/UserReg")]
    public class UserRegController : Controller
    {

        
        TicketDatabase database = new TicketDatabase();
		// GET: api/UserReg/Get
		
		[HttpGet]
		public List<UserReg> Get([FromBody]UserReg user)
		{
			return database.UserRegFind(user);
		}

		//POST: api/UserReg
		[HttpPost]
		public void Post([FromBody]UserReg user)
		{
			database.UserRegAdd(user.Firstname, user.Lastname, user.Email);
		}

	}
}
