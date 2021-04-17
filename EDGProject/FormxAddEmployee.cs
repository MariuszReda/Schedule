using EDGProject.Model;
using System;
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
    public partial class FormxAddEmployee : Form
    {
        public FormxAddEmployee()
        {
            InitializeComponent();
            MEmployees emplo = new MEmployees();
        }
        public FormxAddEmployee(MEmployees emplo)
        {
            InitializeComponent();
            textBox3.Text = emplo.EmployeeID.ToString();
            textBox1.Text = emplo.Name;
            textBox2.Text = emplo.Surname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = textBox3.Text;
            var name = textBox1.Text;
            var surname = textBox2.Text;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(id))
            {
                MEmployees employee = new MEmployees(name, surname);
                DBiConnect dBi = new DBiConnect();
                Form form = new Form();
                dBi.Add(employee);
                this.Close();
            }
            else if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                DBiConnect connect = new DBiConnect();
                connect.Edit(new MEmployees(int.Parse(textBox3.Text), textBox1.Text, textBox2.Text));
                this.Close();
            }
            else
                MessageBox.Show("Uzupełnij dane","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

    }
}
