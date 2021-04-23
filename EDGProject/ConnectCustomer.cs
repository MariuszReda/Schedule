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

        public void add_Customer(Customer person)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "INSERT INTO Customer (FirstName, LastName, Phone) VALUES ('" + person.Name + "','" + person.Surname + "','" + person.Phone + "')";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
