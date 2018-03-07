using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryTicketShop
{
    public class UserAndTicket
    {
		public int Id { get; set; }
		public UserReg user { get; set; }
		public List<AllEventsByDate> events { get; set; }
    }
}
