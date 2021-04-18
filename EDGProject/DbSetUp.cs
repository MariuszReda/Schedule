using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject.Persistance
{
    public class DbSetUp
    {

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

        private void _createDb()
        {

            string connection = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();

            string query = "CREATE DATABASE Salon";

            using (var con = new SqlConnection(connection))
            {
                con.Open();

                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        private bool _dbExists()
        {
            string connection = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();

            string query = "SELECT name FROM master.dbo.sysdatabases WHERE name = N'Salon'";
            object dbResult;

            using (var con = new SqlConnection(connection))
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
            string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();

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

            string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();

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

            string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();

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

            string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();

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

            string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();

            string query = ConfigurationManager.AppSettings.Get("queryBooking").ToString();

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
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

    }
}
