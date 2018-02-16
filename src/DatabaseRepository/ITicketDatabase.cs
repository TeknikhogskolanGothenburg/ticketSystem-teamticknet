using TicketSystem.DatabaseRepository;
using System.Collections.Generic;
using ClassLibraryTicketShop;

namespace TicketSystem.DatabaseRepository
{
    public interface ITicketDatabase
    {
        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="description">A desription of the event, html markup of the event is allowed</param>
        /// <returns>An object representing the newly created TicketEvent</returns>
        TicketEvent EventAdd(string name, string description);

        /// <summary>
        /// Add a new venue to the database
        /// </summary>
        /// <param name="name">Name of the venue</param>
        /// <param name="address">Physical address of the venue</param>
        /// <param name="city">City part of the adress</param>
        /// <param name="country">Country part of the adress</param>
        /// <returns>An object representing the newly created Venue</returns>
        Venue VenueAdd(string name, string address, string city, string country);


        /// <summary>
        /// Find all venus matching the query
        /// </summary>
        /// <param name="query">A text which is user i looking for in the venues</param>
        /// <returns>A list of venus matching the query</returns>
        List<Venue> VenuesFind(string query);

        /// <summary>
        /// Find all Registered users matching the query
        /// </summary>
        /// <param name="query">A text which is user i looking for in the UserReg</param>
        /// <returns>A list of RegUsers matching the query</returns>
        List<UserReg> UserRegFind(string query);
        /// <summary>
        /// Find all Site users matching the query
        /// </summary>
        /// <param name="query">A text which is user i looking for in the SiteUser</param>
        /// <returns>A list of SiteUsers matching the query</returns>
        List<SiteUser> SiteUserFind(string query);

        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="description">A desription of the event, html markup of the event is allowed</param>
        /// <returns>An object representing the newly created UserReg</returns>
        UserReg UserRegAdd(string fName, string lName, string password, string city);

        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param email ="email">Name of site user</param>
        /// <param password="description">Password to set</param>
        /// <param isValid="description">sets with integer if user valid or not (0 or 1) </param>
        /// <returns>  An object representing the newly created SiteUser</returns>
        SiteUser SiteUserAdd(string email, string password, int isValid);

    }
}
