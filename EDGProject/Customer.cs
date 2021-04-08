using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject
{
    public class Customer
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustSurname { get; set; }       
        public string CustPhone { get; set; }
        public int CustUsluga { get; set; }
        public string CustGodzin { get; set; }
        public DateTime CustDate { get; set; }
    }
}
