﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/*
 * NAPISZ PRECDURY W BAZIE DANYCH DLA OPERACJI DODAWANIA JEDNOCZESNIE DWOCH OBIEKTOW DO ROZNYCH TABEL JEDNOCZESNIE
 * ZMIEN STRING CONNECT NA PLIK XML ODPALAJ GO ZE SCIEZKI 
 * DODAJ GENEROWANIE SIE BAZY DANYCH
 */

namespace EDGProject
{
    public class ConnectCustomer
    {
        private string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Salon_;Integrated Security=True";
        private string query;

        /// <summary>
        /// method upgrad BookingTable
        /// </summary>
        /// <param name="person"></param>
        /// <param name="c"></param>
        /// <param name="x"></param>
        public void uploadDB(Customer person,int c,int x)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();

                string query = "INSERT INTO Booking (Date, Hour, JobID, CustomerID, EmplyeesID) VALUES ('" + person.CustDate + "','" + person.CustGodzin + "','" + person.CustUsluga + "','" + c + "','" + x + "')";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void Add(Customer person, int x)
        {

            int c;
            var con = new SqlConnection(connection);
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Customer(FirstName, LastName, Phone) output INSERTED.ClientId VALUES(@CustName,@CustSurname,@CustPhone)", con)) // @ID=SCOPE_IDENTITY()
            {
                cmd.Parameters.AddWithValue("@CustName", person.CustName);
                cmd.Parameters.AddWithValue("@CustSurname", person.CustSurname);
                cmd.Parameters.AddWithValue("@CustPhone", person.CustPhone);

                con.Open();

                c = (int)cmd.ExecuteScalar();

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            MessageBox.Show("Dodanie pomyślne");
            uploadDB(person, c,x);

        }

        public void Delete(Customer person)
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "DELETE FROM Booking WHERE CustomerID ='" + person.CustId + "'";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Usuwanie zakończone");
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

        public DataTable viewData(int x, string data)
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT b.Hour, c.FirstName, c.LastName, c.Phone, j.Job, b.Date FROM Customer AS c, Job AS j, Employees AS e, Booking AS b "
                    + "WHERE b.CustomerID = c.ClientId AND b.EmplyeesID = e.EmplyeeID AND b.JobID = j.JobID And e.EmplyeeID = '" + x + "'"
                    +"AND b.Date LIKE '"+ data +"'";
                using (var sda = new SqlDataAdapter(query, con))
                {
                    sda.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public List<Customer> GetCustomers()
        {
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                query = "SELECT * FROM Customer";
                using (var cmd = new SqlCommand(query, con))
                {
                    var reader = cmd.ExecuteReader();
                    var list = new List<Customer>();
                    while (reader.Read())
                    {
                        list.Add(new Customer() { CustId = reader.GetInt32(0), CustName = reader.GetString(1), CustSurname = reader.GetString(2), CustPhone = reader.GetString(3) });
                    }
                    reader.Close();
                    con.Close();
                    return list;
                }
            }
        }

    }
    
}

//public DataTable View(int x)
//{
//    DataTable dataTable = new DataTable();
//    using (var con = new SqlConnection(connection))
//    {
//        con.Open();
//        query = "SELECT c.FirstName, c.LastName, c.Phone, j.Job, b.Date, b.Hour FROM Customer AS c, Job AS j, Employees AS e, Booking AS b "
//            + "WHERE b.CustomerID = c.ClientId AND b.EmplyeesID = e.EmplyeeID AND b.JobID = j.JobID And e.EmplyeeID = '" + x + "'";
//        using (var sda = new SqlDataAdapter(query, con))
//        {
//            sda.Fill(dataTable);
//            return dataTable;
//        }
//    }            
//}