using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EDGProject
{

   public class Emplo
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Emplo() { }
        public Emplo(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        } 
        public Emplo(int id, string name, string surname)
        {
            this.EmployeeID = id;
            this.Name = name;
            this.Surname = surname;
        }
    }
}
