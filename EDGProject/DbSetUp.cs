using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGProject.Persistance
{
    public class DbSetUp
    {
        //static Tuple<string, string> tuple = _tryConnection();
        //protected static string connectionDefault= tuple.Item1;
        //protected string connection = tuple.Item2;

        private string connectionDefault = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
        private string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();
        public void SetUp()
        {

            if (!_dbExists())
            {
                _createDb();
                _createCustomerTable();
                _createEmployeeTable();
                _createJobTable();
                _createHourTable();
                _createBookingTable();
            }
        }

        private static Tuple<string, string> _tryConnection()
        {
            string connection_if_db_no_Exists = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            string connection_if_db_no_Exists1 = ConfigurationManager.ConnectionStrings["defaultConnectionString1"].ToString();
            string connection_if_db_Exists = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();
            string connection_if_db_Exists1 = ConfigurationManager.ConnectionStrings["salonConnectionString1"].ToString();

            SqlConnection c = new SqlConnection(connection_if_db_no_Exists1);
            using (c)
            {
                try 
                { 
                    c.Open();
                    return new Tuple<string, string>(connection_if_db_no_Exists1, connection_if_db_Exists1);
                }
                catch (SqlException)
                { 
                    c = new SqlConnection(connection_if_db_no_Exists);
                    c.Open(); 
                    if (c == null)
                    {
                        throw new ApplicationException("Unable to connect to: " + c.ConnectionString);
                    }
                    return new Tuple<string, string>(connection_if_db_no_Exists, connection_if_db_Exists);
                }
            }                       
        }


        private void _createDb()
        {
            string query = "CREATE DATABASE Salon";

            using (var con = new SqlConnection(connectionDefault))
            {
                con.Open();

                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private bool _dbExists()
        {
            string query = "SELECT name FROM master.dbo.sysdatabases WHERE name = N'Salon'";
            object dbResult;

            using (var con = new SqlConnection(connectionDefault))
            {
                con.Open();

                var cmd = new SqlCommand(query, con);
                dbResult = cmd.ExecuteScalar();
                con.Close();
            }

            if (dbResult == null)
            {
                return false;
            }
            return true;
        }

        private void _createCustomerTable()
        {
            string query = ConfigurationManager.AppSettings.Get("queryCustomer").Replace('\n', ' ');

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void _createEmployeeTable()
        {
            string query = ConfigurationManager.AppSettings.Get("queryEmployees").ToString();

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        private void _createJobTable()
        {
            string query = ConfigurationManager.AppSettings.Get("queryJob").ToString();

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void _createHourTable()
        {
            string query = ConfigurationManager.AppSettings.Get("queryHour").ToString();

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void _createBookingTable()
        {
            string query = ConfigurationManager.AppSettings.Get("queryBooking").ToString();

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}


//private void _deleteDB()
//{
//    string connection = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
//    string query = "DROP DATABASE Salon";

//    using (var con = new SqlConnection(connection))
//    {
//        con.Open();

//        var cmd = new SqlCommand(query, con);
//        cmd.ExecuteNonQuery();
//        con.Close();
//    }
//}