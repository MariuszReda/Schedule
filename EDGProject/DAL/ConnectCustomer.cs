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
    }
}