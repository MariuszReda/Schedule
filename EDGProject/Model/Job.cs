using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject.Model
{
    public class Job 
    {
        public Job() { }
        public Job(int jobId, string jobName)
        {
            JobId = jobId;
            this.jobName = jobName;
        }

        public int JobId { get; set; }
        public string jobName { get; set; }
    }

}
