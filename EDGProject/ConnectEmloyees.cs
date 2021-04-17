using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using EDGProject.Model;

namespace EDGProject
{
    public interface IDBiConnect
    {
        void Add(MEmployees person);
        void Delete(MEmployees person);
        void Edit(MEmployees person);
    }


/// <summary>
/// This class connect DB for Employeers
/// </summary>
    public class DBiConnect :IDBiConnect
    {

        private string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();
        private string query;

        /// <summary>
        /// method Add Employees in DB
        /// </summary>
        /// <param name="person"></param>
        public void Add(MEmployees person)
        {
            using(var con = new SqlConnection(connection))
            {
                con.Open();
                query = "INSERT INTO Employees (FirstName, LastName) VALUES ('" + person.Name + "','" + person.Surname + "')";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }                   
            MessageBox.Show("Dodanie pomyślne");
        }

        /// <summary>
        /// method Delete Employees in DB
        /// </summary>
        /// <param name="person"></param>
        public void Delete(MEmployees person)
        {
            using(var con = new SqlConnection(connection))
            {
                con.Open();
                query = "DELETE FROM Employees WHERE Employee_Id ='" + person.EmployeeID + "'";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Usuwanie zakończone");
        }
        
        /// <summary>
        /// method Edit Employees in DB
        /// </summary>
        /// <param name="person"></param>
        public void Edit(MEmployees person)
        {
            using(var con = new SqlConnection(connection))
            {
                con.Open();
                query = "UPDATE Employees SET FirstName = '" 
                    + person.Name + "', LastName = '" + person.Surname + "'  WHERE Employee_Id ='" + person.EmployeeID + "'";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Edycja zakończona");
        }

        /// <summary>
        /// Make and return list of emloyee 
        /// </summary>
        /// <returns></returns>
        public List<MEmployees> GetAllEmployees()
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT * FROM Employees";
                using (var cmd = new SqlCommand(query, con))
                {
                    var reader = cmd.ExecuteReader();
                    var list = new List<MEmployees>();
                    while (reader.Read())
                    {
                        list.Add(new MEmployees() {EmployeeID= reader.GetInt32(0), Name = reader.GetString(1), Surname= reader.GetString(2)});
                    }
                    reader.Close();
                    con.Close();
                    return list;
                }
            }
        }

        /// <summary>
        /// Return object Employee
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public MEmployees GetEmplo(MEmployees person)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT * FROM Employees";
                using (var cmd = new SqlCommand(query, con))
                {
                   // var person = new Emplo();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        person.EmployeeID = reader.GetInt32(0);
                        person.Name = reader.GetString(1);
                        person.Surname = reader.GetString(2);
                    }
                    reader.Close();
                    con.Close();
                    return person;
                }
            }
        }

        public MEmployees GetEmplo(int ID_Emp)
        {
            using (var con = new SqlConnection(connection))
            {               
                con.Open();
                query = "SELECT * FROM Employees WHERE Employee_Id = '" + ID_Emp + "'";
                using (var cmd = new SqlCommand(query, con))
                {
                    var reader = cmd.ExecuteReader();
                    var person = new MEmployees();
                    person.EmployeeID = ID_Emp;
                    while (reader.Read())
                    {
                        person.EmployeeID = reader.GetInt32(0);
                        person.Name = reader.GetString(1);
                        person.Surname = reader.GetString(2);
                    }
                    reader.Close();
                    con.Close();
                    return person;
                }
            }
          
        }

    }
}
