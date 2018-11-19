using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SportsProDALClassLibrary
{
    public static class TechSupportDB
    {
        public static SqlConnection GetTechSupportConnection()
        {
            SqlConnection aConn = new SqlConnection();
            string connectionString = "Data Source = CISSQL.MATRIX.TXSTATE.EDU\\CIS3325FALL18; Initial Catalog = TechSupport; Integrated Security = true";
            aConn.ConnectionString = connectionString;
            return aConn;
        }
    }
}
