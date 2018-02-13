using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TicketSystem.DatabaseRepository
{
    public static class DatabaseConnection
    {
        public static string ConnectionString { get; set; }

        public static SqlConnection ConnectionFactory()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
