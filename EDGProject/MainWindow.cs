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
    public partial class MainWindow : Form
    {
        List<Emplo> emplos = new List<Emplo>();

        public MainWindow()
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
            AddEmployee form = new AddEmployee();
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
            Emplo_treeView.Nodes.Add("Pracownicy");
            foreach (Emplo item in dBi.GetAllEmployees())
            {
                //string person = item.Name + " " + item.Surname; //<= NAPRAW
                string person = item.EmployeeID.ToString();
                Emplo_treeView.Nodes[0].Nodes.Add(person);
                emplos.Add(item);   //add to list Emplo all object Emplo
            }
        }

        private void Emplo_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void usuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Emplo emplo = new Emplo();
           
            int x = int.Parse(Emplo_treeView.SelectedNode.Text);
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
            }
        }

        private void Emplo_treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DocumentWindow window = new DocumentWindow();
            window.MdiParent = this;    //show new window like MDI
            window.Show();
        }

        /// <summary>
        /// Edit after right click on treeVew
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Emplo_treeView.SelectedNode.Text);
            DBiConnect connect = new DBiConnect();
            Emplo emplo = connect.GetEmplo(x);
            AddEmployee form = new AddEmployee(emplo);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

    }
}

