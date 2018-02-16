using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryTicketShop
{
   public class SiteUser
    {

            public int ID { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            //using int since less work converting 1 0 to bit int the SQL database.
            public int IsVaild { get; set; }
          
        
    }
}
