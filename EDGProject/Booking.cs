using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject
{
    public class Booking
    {

        public int Id_Usluga { get; set; }
        //public string CustGodzin { get; set; }

        DateTime CustDate;
        public DateTime GetCustDate
        {
            get { return CustDate; }
        }
        public string SetCusttDate
        {
            set 
            {
                CustDate.ToString("yyyy-MM-dd");
            }
        }



    }
}
