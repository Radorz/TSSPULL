using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TSSPULL.Data
{

    public static class SqlConnectionHelper
    {
        private static string connectionString = "Server=DESKTOP-L5MK9TJ\\SQLEXPRESS;Database=TSSDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
