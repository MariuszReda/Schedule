using EDGProject.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGProject
{
    public partial class FormMainWindow : Form
    {
        List<MEmployees> emplos = new List<MEmployees>();

        public FormMainWindow()
        {
            InitializeComponent();
            LoadEmp();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormxAddEmployee form = new FormxAddEmployee();
            form.StartPosition = FormStartPosition.CenterParent; // set location new window
            form.ShowDialog();
            LoadEmp();
        }
       
        /// <summary>
        /// Method load list in to treeView;
        /// </summary>
        public void LoadEmp()
        {            
            DBiConnect dBi = new DBiConnect();
            Emplo_treeView.Nodes.Clear();
            foreach (MEmployees item in dBi.GetAllEmployees())
            {
                int x = item.EmployeeID;    //ref to ID in database
                string person = item.Name + " " + item.Surname;
                Emplo_treeView.Nodes.Add(x.ToString(),person);             
                emplos.Add(item);   //add to list Emplo all object Emplo
            }
        }

        private void Emplo_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // TreeNode node = e.Node; // get name after select
            
        }

        private void usuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MEmployees emplo = new MEmployees();

            int x = int.Parse(Emplo_treeView.SelectedNode.Name); // Name is key where key is ID value in database
            DBiConnect connect = new DBiConnect();
            emplo = connect.GetEmplo(x);
            connect.Delete(emplo);
            LoadEmp();
        }

        /// <summary>
        /// Event for Right ClickMause
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mauseClick(object sender, MouseEventArgs e)    
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
                sender = Emplo_treeView.SelectedNode.IsSelected;
            }
        }




        private void Emplo_treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string x = Emplo_treeView.SelectedNode.Name; // set ID record DataBase
            FormSheduleWindow window = new FormSheduleWindow(int.Parse(x));
            window.Text = Emplo_treeView.SelectedNode.Text; //set Name new form
            window.MdiParent = this;    //show new window like MDI
            window.Show();
     
        }
        public int GetIDEmployeeAfterClick()
        {
            string x = Emplo_treeView.SelectedNode.Name;
            return int.Parse(x);
        }





        /// <summary>
        /// Edit after right click on treeVew
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Emplo_treeView.SelectedNode.Name); // Name is key where key is ID value in database
            DBiConnect connect = new DBiConnect();
            MEmployees emplo = connect.GetEmplo(x);
            FormxAddEmployee form = new FormxAddEmployee(emplo);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            LoadEmp();
        }
    }
}

