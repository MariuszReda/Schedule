using EDGProject.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * NAPISZ PRECDURE DLA OPERACJI DODAWANIA JEDNOCZESNIE DWOCH OBIEKTOW DO ROZNYCH TABEL
 */

namespace EDGProject
{
    public class ConnectBooking
    {
        private string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();
        private string query;

        /// <summary>
        /// method upgrad BookingTable
        /// </summary>
        /// <param name="person"></param>
        /// <param name="c"></param>
        /// <param name="x"></param>
        public void uploadResult(Customer person, int x)
        {
            using (var con = new SqlConnection(connection))
            {



                //con.Open();

                //string query = "INSERT INTO Booking (Date, Hour, JobID, CustomerID, EmplyeesID) VALUES ('" +  + "','" + person.CustGodzin +
                //    "','" + person + "','" + c + "','" + x + "')";
                //var cmd = new SqlCommand(query, con);
                //cmd.ExecuteNonQuery();
                //con.Close();
            }
        }


        public void Add(Customer customer, int x)
        {
            //, int x
             //@ID = SCOPE_IDENTITY()
            var con = new SqlConnection(connection);
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Customer(FirstName, LastName, Phone) output INSERTED.ClientId" +
                " VALUES(@Name,@Surname,@Phone)", con))
            {
                
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Surname", customer.Surname);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);

                con.Open();

                customer.CustomerId = (int)cmd.ExecuteScalar();

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            uploadResult(customer, x);
            MessageBox.Show("Dodanie pomyślne");
            
        }


        public DataTable viewData(Employees employees, string data)
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = ConfigurationManager.AppSettings.Get("view").ToString() + "WHERE [Booking].Emplyees_Id ='" + employees.EmployeeId +"'AND [Booking].Date LIKE '"+ data +"%'OR [Booking].Emplyees_Id is Null ";

                using (var sda = new SqlDataAdapter(query, con))
                {
                    sda.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }   
}




//public void Delete(MCustomer person)
//{
//    using (var con = new SqlConnection(connection))
//    {
//        con.Open();
//        query = "DELETE FROM Booking WHERE CustomerID ='" + person.CustId + "'";
//        var cmd = new SqlCommand(query, con);
//        cmd.ExecuteNonQuery();
//        con.Close();
//    }
//    MessageBox.Show("Usuwanie zakończone");
//}


//public void Edit(MCustomer person)
//{
//    using (var con = new SqlConnection(connection))
//    {
//        con.Open();
//        query = "UPDATE Employees SET FirstName = '"
//            + person.CustName + "', LastName = '" + person.CustSurname + "', LastName = '" + person.CustPhone + 
//            "'  WHERE EmplyeeID ='" + person.CustId + "'";
//        var cmd = new SqlCommand(query, con);
//        cmd.ExecuteNonQuery();
//        con.Close();
//    }
//    MessageBox.Show("Edycja zakończona");
//}