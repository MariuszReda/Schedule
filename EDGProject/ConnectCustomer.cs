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

        public void Add(Customer person)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "INSERT INTO Employees (FirstName, LastName, Phone) VALUES ('" + person.CustName + "','" + person.CustSurname +
                    "','"+person.CustPhone + "')";
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

        public DataTable View()
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT FirstName,LastName,Phone FROM Customer";
                using (var sda = new SqlDataAdapter(query, con))
                {
                    sda.Fill(dataTable);
                    return dataTable;
                }
                con.Close();
            }            
        }
    }
}
