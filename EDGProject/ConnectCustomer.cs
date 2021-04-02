using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGProject
{
    public class ConnectCustomer
    {
        private string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Salon_;Integrated Security=True";
        private string query;

        public void Add(Customer person, int x)
        {
           
            int num;
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "INSERT INTO Customer ( FirstName, LastName, Phone) VALUES ('" + person.CustName + "','" + person.CustSurname + "','" + person.CustPhone + "'); DECLARE @id int; SET @id=SCOPE_IDENTITY()";
                //cmd.CommandText = "INSERT INTO Foo (Bar) ('val'); DECLARE @ID INT; SET @ID=SCOPE_IDENTITY()";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@id";
                p.Size = 4;
                p.Direction = ParameterDirection.Output;
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                num = (int)p.Value;
                con.Close();
            }

            using (var con = new SqlConnection(connection))
            {
               
                con.Open();
               
                string query = "INSERT INTO Booking (Date, Hour, JobID, CustomerID, EmplyeesID) VALUES ('" + person.CustDate + "','" + person.CustGodzin + "','" + person.CustUsluga + "','" + num + "','" + x + "')";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Dodanie pomyślne");
        }

        public void Edit(Customer person)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "UPDATE Employees SET FirstName = '"
                    + person.CustName + "', LastName = '" + person.CustSurname + "', LastName = '" + person.CustPhone + 
                    "'  WHERE EmplyeeID ='" + person.CustId + "'";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Edycja zakończona");
        }

        public void Delete(Customer person)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "DELETE FROM Employees WHERE EmplyeeID ='" + person.CustId + "'";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Usuwanie zakończone");
        }

        public DataTable View(int x)
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT c.FirstName, c.LastName, c.Phone, j.Job, b.Date, b.Hour FROM Customer AS c, Job AS j, Employees AS e, Booking AS b "
                    + "WHERE b.CustomerID = c.ClientId AND b.EmplyeesID = e.EmplyeeID AND b.JobID = j.JobID And e.EmplyeeID = '" + x + "'";
                using (var sda = new SqlDataAdapter(query, con))
                {
                    sda.Fill(dataTable);
                    return dataTable;
                }
                
            }            
        }
    }
}
