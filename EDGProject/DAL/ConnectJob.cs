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
    public class ConnectJob
    {
        private string connection = ConfigurationManager.ConnectionStrings["salonConnectionString"].ToString();

        public List<Job> getAllJobs()
        {
            List<Job> jobs = new List<Job>();
            using(SqlConnection con =  new SqlConnection(connection))
            {
                con.Open();
                string query = " SELECT * FROM Job";
                SqlCommand cmd = new SqlCommand(query, con);
                var reader = cmd.ExecuteReader();

                    while (reader.Read())
                        jobs.Add(new Job() { JobId = reader.GetInt32(0), jobName = reader.GetString(1) });
            }
            return jobs;
        }
    }
}
