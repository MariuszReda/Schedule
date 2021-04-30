using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject.Model
{
    public class Customer
    {
        public Customer() { }
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
        //private string _name;
        //private string _surname;
        //private string _phone;

        //public string Name
        //{
        //    get => _name;
        //    set => _name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
        //}
        //public string Surname 
        //{

        //    get => _surname;
        //    set => _name = value ?? throw new ArgumentNullException(nameof(value), "Surname cannot be null");
        //}
        //public string Phone
        //{
        //    get => _phone;
        //    set => _phone = value ?? throw new ArgumentNullException(nameof(value), "Phone cannot be null");
        //}
    }
}


//public string Name { get; set; }
//public string Surname { get; set; }       
//public string Phone { get; set; }