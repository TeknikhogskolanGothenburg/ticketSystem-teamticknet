using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibraryTicketShop
{
    public class AllEventsByDate
    {
		[Required]
		public DateTime EventStartDateTime { get; set; }
		[Required]
		public string EventName { get; set; }
		[Required]
		public string EventHtmlDescription { get; set; }
		[Required]
		public string VenueName { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string Country { get; set; }
	}
}
