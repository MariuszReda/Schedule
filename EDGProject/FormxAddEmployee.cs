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
            Employees emplo = new Employees();
        }
        public FormxAddEmployee(Employees emplo)
        {
            InitializeComponent();
            textBox3.Text = emplo.EmployeeId.ToString();
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
                Employees employee = new Employees(name, surname);
                ConnectEmloyee dBi = new ConnectEmloyee();
                Form form = new Form();
                dBi.Add(employee);
                this.Close();
            }
            else if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                ConnectEmloyee connect = new ConnectEmloyee();
                connect.Edit(new Employees(int.Parse(textBox3.Text), textBox1.Text, textBox2.Text));
                this.Close();
            }
            else
                MessageBox.Show("Uzupełnij dane","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

    }
}
