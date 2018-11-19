using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SportsProDALClassLibrary
{
    public class RegistrationDAL
    {
        private bool CheckRegistration(int customerID, string productCode)
        {            
            SqlCommand cmdCheckRegistration = new SqlCommand();

            cmdCheckRegistration.Parameters.AddWithValue("@CustomerID", customerID);
            cmdCheckRegistration.Parameters.AddWithValue("@ProductCode", productCode);

            cmdCheckRegistration.CommandText = "SELECT COUNT(*) FROM DBO.REGISTRATIONS" +
                " WHERE PRODUCTCODE = @ProductCode AND CUSTOMERID = @CustomerID";

            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdCheckRegistration.Connection = aConn;

            int count = (int)cmdCheckRegistration.ExecuteScalar();

            aConn.Close();

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AddRegistration(int customerID, string productCode, DateTime regDate)
        {
            SqlCommand cmdAddRegistration = new SqlCommand();

            cmdAddRegistration.Parameters.AddWithValue("@CustomerID", customerID);
            cmdAddRegistration.Parameters.AddWithValue("@ProductCode", productCode);
            cmdAddRegistration.Parameters.AddWithValue("@registrationDate", regDate);

            cmdAddRegistration.CommandText = "spAddRegistration";
            cmdAddRegistration.CommandType = CommandType.StoredProcedure;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdAddRegistration.Connection = aConn;

            DataTable dtProductNameandCode = new DataTable();
            dtProductNameandCode.Load(cmdAddRegistration.ExecuteReader());
            aConn.Close();
            return true;
        }

        public bool RegisterProduct(int customerID, string productCode, DateTime regDate)
        {
            if (CheckRegistration(customerID, productCode) is true)
            {
                return false;
            }
            else
            {
                SqlCommand cmdRegisterProduct = new SqlCommand();

                AddRegistration(customerID, productCode, regDate);
  
                SqlConnection aConn = new SqlConnection();
                aConn = TechSupportDB.GetTechSupportConnection();
                aConn.Open();
                cmdRegisterProduct.Connection = aConn;
                aConn.Close();
                return true;
            }
        }

        public RegistrationDAL()
        {

        }
    }
}
