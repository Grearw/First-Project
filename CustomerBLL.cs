using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsProDALClassLibrary;
using System.Data;

namespace SportsProBLLClassLibrary
{
    public class CustomerBLL
    {
        public List<Customer> RetrieveCustomerIDandName()
        {
            List<Customer> lstCustIDandName = new List<Customer>();
            DataTable dtCustomerDetails = new DataTable();
            CustomerDAL prodDal = new CustomerDAL();
            dtCustomerDetails = prodDal.GetCustomerIDandName();
            foreach (DataRow dr in dtCustomerDetails.Rows)
            {
                Customer aCustomer = new Customer();
                aCustomer.CustomerID = (int)dr["CustomerID"];
                aCustomer.Name = dr["Name"].ToString();
                lstCustIDandName.Add(aCustomer);
            }
            return lstCustIDandName;
        }

        public CustomerBLL()
        {

        }
    }
}
