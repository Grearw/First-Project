using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsProBLLClassLibrary
{
    public class Product
    {
        private string name;
        private string productCode;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public Product()
        {

        }
    }

    
}
