using EDGProject.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGProject
{
    static class Program
    {
        /// <summary>
        /// Main input aplication
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new DbSetUp().SetUp();

            Application.Run(new FormMainWindow());
        }
    }
}
