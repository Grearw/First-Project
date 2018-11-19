using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SportsProDALClassLibrary
{
    public class ProductDAL
    {
        public DataTable GetProductNameandCode()
        {
            SqlCommand cmdProductNameandCode = new SqlCommand();
            cmdProductNameandCode.CommandText = "SELECT PRODUCTCODE, NAME FROM DBO.PRODUCTS";
            cmdProductNameandCode.CommandType = CommandType.Text;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdProductNameandCode.Connection = aConn;

            DataTable dtProductNameandCode = new DataTable();
            dtProductNameandCode.Load(cmdProductNameandCode.ExecuteReader());
            aConn.Close();
            return dtProductNameandCode;
        }

        public ProductDAL()
        {

        }
    }
}
