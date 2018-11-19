using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsProDALClassLibrary;

namespace SportsProBLLClassLibrary
{
    public class RegistrationBLL
    {
        public RegistrationBLL()
        {

        }

        public bool AddNewRegistration(Registration aRegistration)
        {
            RegistrationDAL regDAL = new RegistrationDAL();
            
            if (regDAL.RegisterProduct(aRegistration.CustomerID, aRegistration.ProductCode, 
                aRegistration.RegistrationDate) is false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
     
    }
}
