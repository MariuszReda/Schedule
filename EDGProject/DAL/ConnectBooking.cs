using EDGProject.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace EDGProject
{
    public class ConnectBooking
    {
        private string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();
        private string query;

        public void addBooking(Booking booking)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                string query = "INSERT INTO Booking (Date, Hour_Id, Job_Id, Customer_Id, Emplyees_Id) VALUES ('" + booking.Date.ToString("yyyy-MM-dd") + "','" + booking.HourId +
                    "','" + booking.JobId + "','" + booking.CustomerId + "','" + booking.EmplyeesId + "')";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void deleteBooking(Booking booking)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "DELETE FROM Booking WHERE Booking_Id ='" + booking.BookingId + "'";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Usuwanie zakończone");
        }

        public void editBooking(Booking booking)
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

        public List<Booking> getAllBookings()
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT * FROM Booking";
                using (var cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    var list = new List<Booking>();
                    while (reader.Read())
                    {
                        list.Add(new Booking()
                        {
                            BookingId = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            HourId = reader.GetInt32(2),
                            CustomerId = reader.GetInt32(3),
                            EmplyeesId = reader.GetInt32(4),
                            JobId = reader.GetInt32(5)
                        });
                    }
                    reader.Close();
                    con.Close();
                    return list;
                }
            }
        }

        public DataTable viewData(Employees employees, string data)
        {
            DataTable dataTable = new DataTable();

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = ConfigurationManager.AppSettings.Get("viewTable").ToString();
                query = query.Replace("$BOOKING_DATE$", data).Replace("$EMPLOYEE_ID$", employees.EmployeeId.ToString());

                using (var sda = new SqlDataAdapter(query, con))
                {
                    sda.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }   
}

