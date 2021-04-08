using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGProject.Configuration
{
   public class ConfigurationManagerWrapper
    {

        public static string GetConnectionString( string name)
        {
            return ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString;  
        }
    }
}
