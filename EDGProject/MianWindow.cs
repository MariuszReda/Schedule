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
    public partial class MianWindow : Form
    {
        public MianWindow()
        {
            InitializeComponent();
            LoadEmp();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentWindow window = new DocumentWindow();
            window.MdiParent = this;
            window.Show();
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee form = new AddEmployee();
            form.ShowDialog();
            LoadEmp();
        }
        List<Emplo> emplos = new List<Emplo>();

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
                //string person = item.Name + " " + item.Surname; <= NAPRAW
                string person = item.EmployeeID.ToString();
                Emplo_treeView.Nodes[0].Nodes.Add(person);
                emplos.Add(item);   //add to list Emplo all object Emplo
            }
        }

        private void Emplo_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            //switch ((e.Action))
            //{
            //    case TreeViewAction.ByKeyboard:
            //        MessageBox.Show("You like the keyboard!");
            //        break;
            //    case TreeViewAction.ByMouse:

            //        MessageBox.Show("You like the mouse!");
            //        break;
            //}

            /*
            Car mycar1 = new Car("my car name", "my car brand", 1999);
            TreeViewItem node = new TreeViewItem() { Header = mycar1.car_name};
            node.Items.Add(new TreeViewItem() { Header = mycar1.car_brand });
            node.Items.Add(new TreeViewItem() { Header = mycar1.car_year });
            myTree.Items.Add(node);
            */
        }

        //private void mauseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        contextMenuStrip1.Show(Cursor.Position);
        //    }
        //}
        private void usuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Emplo emplo = new Emplo();
           
            int x = int.Parse(Emplo_treeView.SelectedNode.Text);
            DBiConnect connect = new DBiConnect();
            emplo = connect.GetEmplo(x);
            connect.Delete(emplo);
            LoadEmp();
        }

        private void fffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Emplo_treeView.SelectedNode.Text);
            DBiConnect connect = new DBiConnect();
            Emplo emplo = connect.GetEmplo(1);
            AddEmployee form = new AddEmployee(emplo);
            form.ShowDialog();
        }

        private void mauseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}

