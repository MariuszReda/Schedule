using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        
        public DateTime Date { get; private set; }

        public DateTime SetDate
        {
            set
            {
               Date.ToString("yyyy-MM-dd");
            }
        }

        public int HourId { get; set; }
        public int CustomerId { get; set; }
        public int EmplyeesId { get; set; }
    }
}

