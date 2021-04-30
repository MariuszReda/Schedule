using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject.Model
{
    public class Booking
    {
        public Booking() { }

        public Booking(DateTime date, int hourId, int customerId, int emplyeesId)
        {
            Date = date;
            HourId = hourId;
            CustomerId = customerId;
            EmplyeesId = emplyeesId;
        }

        public int BookingId { get; set; }        
        public DateTime Date { get; set; }
        public int HourId { get; set; }
        public int CustomerId { get; set; }
        public int EmplyeesId { get; set; }
        public int JobId { get; set; }
    }
}

