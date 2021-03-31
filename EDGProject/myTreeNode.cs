using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGProject
{
   public class myTreeNode : TreeNode
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public myTreeNode(int id, string name, string surname)
        {
            EmployeeID = id;
            Name = name;
            Surname = surname;
        }
        public myTreeNode(string surname)
        {
            Surname = surname;
        }

    }
}
