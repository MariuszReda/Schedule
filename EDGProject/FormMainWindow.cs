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
    public delegate string EventHandler();

    public partial class FormMainWindow : Form
    {
        
        List<Employees> emplos = new List<Employees>();

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
            ConnectEmloyee dBi = new ConnectEmloyee();
            Emplo_treeView.Nodes.Clear();
            foreach (Employees item in dBi.GetAllEmployees())
            {
                int x = item.EmployeeId;    //ref to ID in database
                string person = item.Name + " " + item.Surname;
                Emplo_treeView.Nodes.Add(x.ToString(), person);
                emplos.Add(item);   //add to list Emplo all object Emplo
            }
        }

        private void Emplo_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //EventHandler handler = new EventHandler(IDEmployeeAfterClick);
            //FormSheduleWindow window = new FormSheduleWindow();
            //window.Handler += handler;

            //// zapisac ID który formularz do kogo nalezy

        }

        private void usuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employees emplo = new Employees();

            int x = int.Parse(Emplo_treeView.SelectedNode.Name); // Name is key where key is ID value in database
            ConnectEmloyee connect = new ConnectEmloyee();
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
            EventHandler handler = new EventHandler(IDEmployeeAfterClick);
            ConnectBooking connect = new ConnectBooking();
            
            FormSheduleWindow window1 = new FormSheduleWindow(connect.viewData(IDEmployeeAfterClick(), DateTime.Now.ToString()));
            window1.Handler += handler;
            window1.MdiParent = this;
            window1.Show();
            GC.Collect();
        }

        private string IDEmployeeAfterClick()
        {
            string x = Emplo_treeView.SelectedNode.Name;
            return x;
        }

        /// <summary>
        /// Edit after right click on treeVew
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Emplo_treeView.SelectedNode.Name); // Name is key where key is ID value in database
            ConnectEmloyee connect = new ConnectEmloyee();
            Employees emplo = connect.GetEmplo(x);
            FormxAddEmployee form = new FormxAddEmployee(emplo);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            LoadEmp();
        }
    }
}