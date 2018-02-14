using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using ClassLibraryTicketShop;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/

        public List<Ticket> TicketGet()
        {
            var client = new RestClient("http://localhost:18001/");
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://localhost:18001/");
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }

		public List<Venue> GetVenue (string query)
		{
			var client = new RestClient("http://localhost:61828/api/");
			var request = new RestRequest("Venues/{query}", Method.GET);
			request.AddUrlSegment("query", query);
			var response = client.Execute<List<Venue>>(request);

			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", query));
			}

			return response.Data;
		}


	}
}
