using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject.Model
{
    public class Customer
    {
        public Customer(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }       
        public string Phone { get; set; }
    }
}
