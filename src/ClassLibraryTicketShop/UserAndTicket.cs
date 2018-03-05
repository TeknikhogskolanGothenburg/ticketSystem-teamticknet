using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryTicketShop
{
    public class UserAndTicket
    {
        public UserReg user { get; set; }
        public List<AllEventsByDate> events { get; set; }
    }
}
