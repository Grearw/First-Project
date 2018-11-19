using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SportsProDALClassLibrary
{
    public class CustomerDAL
    {
       
        public DataTable GetCustomerIDandName()
        {
            SqlCommand cmdCustomerIDandName = new SqlCommand();
            cmdCustomerIDandName.CommandText = "SELECT CUSTOMERID, NAME FROM DBO.CUSTOMERS";
            cmdCustomerIDandName.CommandType = CommandType.Text;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdCustomerIDandName.Connection = aConn;

            DataTable dtCustomerIDandName = new DataTable();
            dtCustomerIDandName.Load(cmdCustomerIDandName.ExecuteReader());
            aConn.Close();
            return dtCustomerIDandName;
        }

        public CustomerDAL()
        {

        }
    }
}
