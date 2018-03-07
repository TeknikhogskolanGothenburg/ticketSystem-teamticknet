using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTicketShop
{
    public class Order
    {
		public int Id { get; set; }
		public int CustomerId { get; set; }

		public virtual ICollection<AllEventsByDate> Events { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
