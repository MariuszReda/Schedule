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

        /// <summary>
        /// method upgrad BookingTable
        /// </summary>
        /// <param name="person"></param>
        /// <param name="c"></param>
        /// <param name="x"></param>
        //public void uploadResult()
        //{
        //    using (var con = new SqlConnection(connection))
        //    {
        //        con.Open();
        //        string query = "INSERT INTO Booking (Date, Hour, JobID, CustomerID, EmplyeesID) VALUES ('" + booking.Date + "','" + booking.HourId +
        //            "','" + booking.JobId + "','" + booking.CustomerId + "','" + booking.EmplyeesId + "')";
        //        var cmd = new SqlCommand(query, con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}

        public DataTable viewData(string id, string data)
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = ConfigurationManager.AppSettings.Get("view").ToString() + "WHERE [Booking].Emplyees_Id ='" + id + "'AND [Booking].Date LIKE '" + data + "%'OR [Booking].Emplyees_Id is Null ";

                using (var sda = new SqlDataAdapter(query, con))
                {
                    sda.Fill(dataTable);
                    return dataTable;
                }
            }
        }



        public DataTable viewData(Employees employees, string data)
        {
            DataTable dataTable = new DataTable();

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = ConfigurationManager.AppSettings.Get("viewBasic").ToString();
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

//public DataTable viewData(Employees employees, string data)
//{
//    DataTable dataTable = new DataTable();
//    using (var con = new SqlConnection(connection))
//    {
//        con.Open();
//        query = ConfigurationManager.AppSettings.Get("view").ToString() + "WHERE [Booking].Emplyees_Id ='" + employees.EmployeeId +"'AND [Booking].Date LIKE '"+ data +"%'OR [Booking].Emplyees_Id is Null ";

//        using (var sda = new SqlDataAdapter(query, con))
//        {
//            sda.Fill(dataTable);
//            return dataTable;
//        }
//    }
//}