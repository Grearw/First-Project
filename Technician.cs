using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsProBLLClassLibrary
{
    public class Technician
    {
        private int techID;
        private string techName;
        private string techEmail;
        private string techPhoneNum;

        public int TechID
        {
            get { return techID; }
            set { techID = value; }
        }

        public string TechName
        {
            get { return techName; }
            set { techName = value; }
        }

        public string TechEmail
        {
            get { return techEmail; }
            set { techEmail = value; }
        }

        public string TechPhoneNum
        {
            get { return techPhoneNum; }
            set { techPhoneNum = value; }
        }

        public Technician()
        {

        }
    }
}
