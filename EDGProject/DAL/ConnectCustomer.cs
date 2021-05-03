using EDGProject.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGProject
{
    public class ConnectCustomer
    {
        private string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();
        private string query;

        public int add_Customer(Customer person)
        {
            var con = new SqlConnection(connection);
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Customer(FirstName, LastName, Phone) output INSERTED.Client_Id" +
                " VALUES(@FirstName,@LastName,@Phone)", con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", person.Name);
                    cmd.Parameters.AddWithValue("@LastName", person.Surname);
                    cmd.Parameters.AddWithValue("@Phone", person.Phone);

                    con.Open();

                    person.CustomerId = (int)cmd.ExecuteScalar();

                    if (con.State == System.Data.ConnectionState.Open)
                        con.Close();
                }
            
            MessageBox.Show("Dodanie pomyślne");
            return person.CustomerId;
        }

        public void editBooking(Customer customer)
        {
            //using (var con = new SqlConnection(connection))
            //{
            //    con.Open();
            //    query = "UPDATE Employees SET FirstName = '"
            //        + .CustName + "', LastName = '" + person.CustSurname + "', LastName = '" + person.CustPhone +
            //        "'  WHERE EmplyeeID ='" + person.CustId + "'";
            //    var cmd = new SqlCommand(query, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            //MessageBox.Show("Edycja zakończona");
        }

        public List<Customer> getAllCustomer()
        {
            using(var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT * FROM Customer";
                using(var cmd = new SqlCommand(query,con))
                {
                    var reader = cmd.ExecuteReader();
                    var list = new List<Customer>();
                    while(reader.Read())
                    {
                        list.Add(new Customer
                        {
                            CustomerId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Phone = reader.GetString(3)
                        });
                    }
                    return list;
                }
            }

        }
    }
}