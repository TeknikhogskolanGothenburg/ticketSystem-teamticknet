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
    public class TicketDatabase : ITicketDatabase
    {
        static string ConnectionString = DatabaseConnection.ConnectionString;


        //User UserRegFind takes first name and lastname WITHOUT space sepparator or Email.
        public List<UserReg> UserRegFind(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<UserReg>("SELECT * FROM UserReg WHERE (Fname + Lname) = '%" + query + "%' OR Email ='%" + query+ "'%").ToList();
                connection.Close();
                return values;
            }
        }

        
        public List<SiteUser> SiteUserFind(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<SiteUser>("SELECT * FROM SiteUser WHERE Email = '%" + query + "%' AND IsValid = True '%").ToList();
                connection.Close();
                return values;
            }
        }
        public SiteUser SiteUserAdd(string email, string password, bool isValid)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into SiteUser([Email],[Password],[IsValid]) values(@Email,@Password, @IsValid)", new { Email = email , Password = password, IsValid = isValid});
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('SiteUser') AS Current_Identity").First();
                var values = connection.Query<SiteUser>("SELECT * FROM SiteUser WHERE ID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }
        public UserReg UserRegAdd(string fname, string lname, string password, string email)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into SiteUser([Fname],[Lname],[Password],[Email]) values(@Fname,@Lname, @Password, @Email)", new { Fname = fname, Lname = lname, Password = password, Email= email });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('UserReg') AS Current_Identity").First();
                var values = connection.Query<UserReg>("SELECT * FROM UserReg WHERE ID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }


        public TicketEvent EventAdd(string name, string description)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = name, Description = description });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                var values = connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
                connection.Close();
                return values;
            }
        }

		public List<TicketEvent> EventFindSpecifik(string query)
		{
			string connectionString = ConnectionString;
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				var values = connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE EventName like '%" + query + "%' OR EventHtmlDescription like '%" + query + "%'").ToList();
				return values;
			}
		}

        public List<AllEventsByDate> EventDateFindEventsAndVenues()
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<AllEventsByDate>("SELECT TicketEventDates.EventStartDateTime, TicketEvents.EventName, TicketEvents.EventHtmlDescription, Venues.VenueName, Venues.Country, Venues.Address From TicketEventDates JOIN Venues ON Venues.VenueID = TicketEventDates.VenueID JOIN TicketEvents ON TicketEvents.TicketEventID = TicketEventDates.TicketEventID ").ToList();
                return values;
            }
        }

        public List<Venue> VenuesFind(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + query + "%' OR Address like '%" + query + "%' OR Email like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
                connection.Close();
                return values;
            }
        }

        public Venue VenueAdd(string name, string address, string city, string country)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address = address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }

        public static List<Venue> VenuesSpecific(string query)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				connection.Open();
				var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + query + "%' OR Address like '%" + query + "%' OR Email like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
                return values;
			}
		}

        public List<Venue> VenuesAll()
        {
            var connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<Venue>("SELECT * FROM Venues").ToList();
                return values;
            }
        }
       
        
    }
}
