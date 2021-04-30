using EDGProject.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject
{
    public class ConnectVisitTime
    {
        private string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();

        public List<VisitTime> getAllTime()
        {
            List<VisitTime> time = new List<VisitTime>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = " SELECT * FROM Hour";
                SqlCommand cmd = new SqlCommand(query, con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                    time.Add(new VisitTime() {  HourId = reader.GetInt32(0),  Time =  TimeSpan.Parse(reader.GetString(1)) });

            }
            return time;
        }
    }
}
