using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EDGProject.Model
{

   public class Employees
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Employees() { }
        public Employees(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        } 
        public Employees(int id, string name, string surname)
        {
            this.EmployeeId = id;
            this.Name = name;
            this.Surname = surname;
        }
    }
}
