using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository;
using ClassLibraryTicketShop;
using System;

namespace TicketSystem.DatabaseRepository
{
    public interface ITicketDatabase
    {
      
        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="description">A desription of the event, html markup of the event is allowed</param>
        /// <returns>An object representing the newly created UserReg</returns>
        UserReg UserRegAdd(string fName, string lName, string email);

        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param email ="email">Name of site user</param>
        /// <param password="description">Password to set</param>
        /// <param isValid="description">sets with integer if user valid or not (0 or 1) </param>
        /// <returns>  An object representing the newly created SiteUser</returns>
        //SiteUser SiteUserAdd(string email, string password, bool isValid);

        List<AllEventsByDate> EventDateFindEventsAndVenues();
		TicketEventDate AddAllEventsByDate(AllEventsByDate allEvents);
		void DeleteEventsAndVenues(int id);
	}
}
