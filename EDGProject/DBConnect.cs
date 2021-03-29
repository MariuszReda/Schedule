using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace EDGProject
{
    public interface IDBiConnect
    {
        void Add(Emplo person);
        void Delete(Emplo person);
        void Edit(Emplo person);

    }


/// <summary>
/// This class connect DB for Employeers
/// </summary>
    public class DBiConnect :IDBiConnect
    {
        private string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Salon_;Integrated Security=True";
        private string query;

        /// <summary>
        /// method Add new object Emplo to DB
        /// </summary>
        /// <param name="person"></param>
        public void Add(Emplo person)
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
        /// method Delete object from DB 
        /// </summary>
        /// <param name="person"></param>
        public void Delete(Emplo person)
        {
            using(var con = new SqlConnection(connection))
            {
                con.Open();
                query = "DELETE FROM Employees WHERE EmplyeeID ='" + person.EmployeeID + "'";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Usuwanie zakończone");
        }

        public void Edit(Emplo person)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Make and return list of emloyee 
        /// </summary>
        /// <returns></returns>
        public List<Emplo> GetAllEmployees()
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT * FROM Employees";
                using (var cmd = new SqlCommand(query, con))
                {
                    var reader = cmd.ExecuteReader();
                    var list = new List<Emplo>();
                    while (reader.Read())
                    {
                        list.Add(new Emplo() {EmployeeID= reader.GetInt32(0), Name = reader.GetString(1), Surname= reader.GetString(2)});
                    }
                    reader.Close();
                    con.Close();
                    return list;
                }
            }
        }

        public Emplo GetEmplo(Emplo person)
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

        public Emplo GetEmplo(int ID_Emp)
        {
            using (var con = new SqlConnection(connection))
            {
                
                con.Open();
                query = "SELECT * FROM Employees WHERE EmplyeeID = '" + ID_Emp + "'";
                using (var cmd = new SqlCommand(query, con))
                {
                    var reader = cmd.ExecuteReader();
                    var person = new Emplo();
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
