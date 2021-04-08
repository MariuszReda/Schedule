using System;
using System.Collections.Generic;
using System.Configuration;
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
 
           
            //_deleteDB();
            if (!_dbExists())
            {
             
                //trzeba stworzyć
                _createDb();
                _createCustomerTable();
                _createEmployeeTable();

              

                //inserty defaultowe

            }
        
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
            string query = @"CREATE TABLE [dbo].[Employees](
	                        [EmplyeeID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	                        [FirstName] [varchar](50) NOT NULL,
	                        [LastName] [varchar](50) NOT NULL)
                        ";

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
            string query = @"CREATE TABLE [dbo].[Booking](
                	[BookingID] [int] IDENTITY(1,1) NOT NULL,
                	[Date] [date] NOT NULL,
                	[Hour] [varchar](50) NOT NULL,
                	[CustomerID] [int] NOT NULL,
                	[EmplyeesID] [int] NOT NULL,
                	[JobID] [int] NOT NULL,
                CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
                (
                	[BookingID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                GO
                
                ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([CustomerID])
                REFERENCES [dbo].[Customer] ([ClientId])
                GO
                
                ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
                GO
                
                ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Employees] FOREIGN KEY([EmplyeesID])
                REFERENCES [dbo].[Employees] ([EmplyeeID])
                GO
                
                ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Employees]
                GO
                
                ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Job] FOREIGN KEY([JobID])
                REFERENCES [dbo].[Job] ([JobID])
                GO
                
                ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Job]
                GO";

            using (var con = new SqlConnection(connection))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private void _deleteDB()
        {
            string connection = "Data Source=.;Integrated Security=True";
            string query = "DROP TABLE Salon_";

            using (var con = new SqlConnection(connection))
            {
                con.Open();

                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private void _createDb()
        {
            string connection = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ToString();
            string  query ="CREATE DATABASE Salon_";

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
            string connection = "Data Source=.;Integrated Security=True";
            string query = "SELECT name FROM master.dbo.sysdatabases WHERE name = N'Salon_'";
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

    }

}
   
 