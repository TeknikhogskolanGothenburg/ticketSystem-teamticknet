﻿using System.Collections.Generic;
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
                var values = connection.Query<AllEventsByDate>("SELECT TicketEventDates.EventStartDateTime, TicketEventDates.TicketEventDateID, TicketEvents.EventName, TicketEvents.EventHtmlDescription, Venues.VenueName, Venues.Country, Venues.City, Venues.Address From TicketEventDates JOIN Venues ON Venues.VenueID = TicketEventDates.VenueID JOIN TicketEvents ON TicketEvents.TicketEventID = TicketEventDates.TicketEventID ").ToList();
                return values;
            }
        }

		public static void DeleteEventsAndVenues(int id)
		{
			string connectionString = ConnectionString;
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				 connection.Query("DELETE FROM TicketEventDates WHERE TicketEventDateID = '@ID'", new {@ID = id});

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
