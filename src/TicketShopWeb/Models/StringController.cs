using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopWeb.Models
{
    public static class StringController
    {
			public static bool IsEmpty(string StringValue)
			{
				return string.IsNullOrWhiteSpace(StringValue) || string.IsNullOrEmpty(StringValue);
			}

		
	}
}
