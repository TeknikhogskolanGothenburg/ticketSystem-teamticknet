using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository;
using ClassLibraryTicketShop;

namespace TicketSystem.DatabaseRepository
{
    public class TicketDatabase : ITicketDatabase
    {
        static string ConnectionString = DatabaseConnection.ConnectionString;

        public List<UserReg> UserRegFind(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<UserReg>("SELECT * FROM UserReg WHERE Fname like '%" + query + "%' OR Lname like '%" + query + "%' OR City like '%" + query + "%'").ToList();
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

		//public List<TicketEventDate> EventDateFindSpecifik(string query)
		//{
		//	string connectionString = ConnectionString;
		//	using (var connection = new SqlConnection(connectionString))
		//	{
		//		connection.Open();
		//		var values = connection.Query<TicketEventDate>("SELECT * FROM TicketEventDates WHERE EventName like '%" + query + "%' OR EventHtmlDescription like '%" + query + "%'").ToList();
		//		return values;
		//	}
		//}

			//Kolla funktioner i SQL hur man genom att söka på datum får fram alla events och venues för det datumet med hjälp av deras id i TicketEventDate

		public Venue VenueAdd(string name, string address, string city, string country)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address= address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }

        public List<Venue> VenuesFind(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + query + "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
                connection.Close();
                return values;
            }
        }
        
        public static List<Venue> VenuesSpecific(string query)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				connection.Open();
				var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + query + "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
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
