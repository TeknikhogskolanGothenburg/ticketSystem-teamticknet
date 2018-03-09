using RestSharp;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using ClassLibraryTicketShop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/

        public List<Ticket> TicketGet()
        {
            var client = new RestClient("http://localhost:61828/");
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://localhost:61828/");
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
				throw new KeyNotFoundException(string.Format("No venue found", query));
			}
			return response.Data;
		}

		public List<TicketEvent> GetEvent (string query)
		{
			var client = new RestClient("http://localhost:61828/api/");
			var request = new RestRequest("Event/{query}", Method.GET);
			request.AddUrlSegment("query", query);
			var response = client.Execute<List<TicketEvent>>(request);

			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				throw new KeyNotFoundException(string.Format("No events found", query));
			}
			return response.Data;
		}

		public void VenuesAdd(Venue newVenue)
		{
			var client = new RestClient("http://localhost:61828");
			var request = new RestRequest("api/Venues", Method.POST);
			request.AddJsonBody(newVenue);
			client.Execute(request); 
		}

		public void EventsAdd(TicketEvent newEvent)
		{
			//var output = JsonConvert.SerializeObject(newVenue);
			var client = new RestClient("http://localhost:61828");
			var request = new RestRequest("api/Event", Method.POST);
			request.AddJsonBody(newEvent);
			//request.AddParameter("venue", output, ParameterType.RequestBody);
			client.Execute(request);
		}

		public void DateEventAdd(TicketEventDate newEventDate)
		{
			//var output = JsonConvert.SerializeObject(newVenue);
			var client = new RestClient("http://localhost:61828");
			var request = new RestRequest("api/Event", Method.POST);
			request.AddJsonBody(newEventDate);
			//request.AddParameter("venue", output, ParameterType.RequestBody);
			client.Execute(request);
		}

        public List<AllEventsByDate> GetEventsAndVenues()
        {
            var client = new RestClient("http://localhost:61828");
            var request = new RestRequest("api/AllInfo", Method.GET);
            var response = client.Execute<List<AllEventsByDate>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("No events found"));
            }
            return response.Data;
        }

        public async Task<UserReg> AddUser (UserReg newUser)
        {
            var client = new RestClient("http://localhost:61828");
            var request = new RestRequest("api/UserReg", Method.POST);
            request.AddJsonBody(newUser);
			//client.Execute(request);

			request.AddHeader("Accept", "application/json");

			var jsonObject = JsonConvert.SerializeObject(newUser);
			request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);

			var taskCompletion = new TaskCompletionSource<IRestResponse>();

			var handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));

			var response = (RestResponse)(await taskCompletion.Task);

			return JsonConvert.DeserializeObject<UserReg>(response.Content);
		}


		public async Task<UserReg> ExistingUser(UserReg user)
		{
			var client = new RestClient("http://localhost:61828");
			var request = new RestRequest("api/UserReg", Method.GET);
			request.AddHeader("Accept", "application/json");
			

			var jsonObject = JsonConvert.SerializeObject(user);
			request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);

			var taskCompletion = new TaskCompletionSource<IRestResponse>();

			client.ExecuteAsync(request, r => taskCompletion.SetResult(r));

			var response = (RestResponse)(await taskCompletion.Task);

			return JsonConvert.DeserializeObject<UserReg>(response.Content);
		}


		public async Task<Order> CreateOrder(Order order)
		{
			var client = new RestClient("http://localhost:61828");
			var request = new RestRequest("CreateOrder", Method.POST);
			request.AddHeader("Accept", "application/json");

			var jsonObject = JsonConvert.SerializeObject(order);
			request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);

			var taskCompletion = new TaskCompletionSource<IRestResponse>();

			var handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));

			var response = (RestResponse)(await taskCompletion.Task);

			return JsonConvert.DeserializeObject<Order>(response.Content);

		}

		public void DeleteEventInfo(int id)
		{
			//var output = JsonConvert.SerializeObject(newVenue);
			var client = new RestClient("http://localhost:61828");
			var request = new RestRequest("api/AllInfo/", Method.DELETE);
			request.AddJsonBody(id);
			//request.AddParameter("venue", output, ParameterType.RequestBody);
			client.Execute(request);
		}
	}
}
