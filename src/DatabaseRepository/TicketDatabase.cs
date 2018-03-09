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
		public List<UserReg> UserRegFind(UserReg user)
		{
			string connectionString = ConnectionString;
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				var values = connection.Query<UserReg>("SELECT * FROM UserReg WHERE Firstname = '@firstname' AND Lastname = '@lastname'", new {firstname = user.Firstname, lastname = user.Lastname }).ToList();

					return values;
			}
		}

		public UserReg UserRegAdd(string fname, string lname, string email)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into UserReg(Firstname, Lastname, Email) values(@Firstname, @Lastname, @Email)", new { Firstname = fname, Lastname = lname, Email= email });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('UserReg') AS Current_Identity").First();
                var values = connection.Query<UserReg>("SELECT * FROM UserReg WHERE ID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }

		public static Order AddOrder(Order order)
		{
			string connectionString = ConnectionString;
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				connection.Query("insert into Order(UserId, OrderDate ) values(@UserId, @OrderDate, @TicketEventDateId)", new { UserId = order.CustomerId, OrderDate = order.OrderDate });
				var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Order') AS Current_Identity").First();
				var values = connection.Query<Order>("SELECT * FROM Order WHERE Id=@Id", new { Id = addedVenueQuery }).First();
				connection.Close();
				return values;
			}
		}

        public List<AllEventsByDate> EventDateFindEventsAndVenues()
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<AllEventsByDate>("SELECT TicketEventDates.EventStartDateTime, TicketEventDates.TicketEventDateID, TicketEvents.EventName, TicketEvents.EventHtmlDescription, Venues.VenueName, Venues.Country, Venues.City, Venues.Address From TicketEventDates JOIN Venues ON Venues.VenueID = TicketEventDates.VenueID JOIN TicketEvents ON TicketEvents.TicketEventID = TicketEventDates.TicketEventID ").ToList();
                return values;
            }
        }

		public void DeleteEventsAndVenues(int id)
		{

			
			string connectionString = ConnectionString;
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				 connection.Query("DELETE FROM TicketEventDates WHERE TicketEventDateID = @ID", new {@ID = id}).ToList();

			}
		}


		public TicketEventDate AddAllEventsByDate (AllEventsByDate allEvents)
		{
			string connectionString = ConnectionString;
			using (var connection = new SqlConnection(connectionString))
			{
			connection.Open();

			// Add Event
			connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = allEvents.EventName, Description = allEvents.EventHtmlDescription });
			var events = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
			connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = events }).First();
			// Add Venue
			connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = allEvents.VenueName, Address = allEvents.Address, City = allEvents.City, Country = allEvents.Country });
			var venue = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
			connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = venue }).First();
			// Add to TicketEventDate(s)
			connection.Query("insert into TicketEventDates([EventStartDateTime],[VenueId],[TicketEventID]) values(@DateTime,@VenueId, @TicketEventID)", new { DateTime = allEvents.EventStartDateTime, VenueId = venue, TicketEventID = events });
			var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEventDates') AS Current_Identity").First();
			var values = connection.Query<TicketEventDate>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
			connection.Close();
				return values;
			}

			
		}

     
       



       
        
    }
}
