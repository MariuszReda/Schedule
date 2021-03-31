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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
            Emplo emplo = new Emplo();
        }
        public AddEmployee(Emplo emplo)
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
                Emplo employee = new Emplo(name, surname);
                DBiConnect dBi = new DBiConnect();
                Form form = new Form();
                dBi.Add(employee);
                this.Close();
            }
            else if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                DBiConnect connect = new DBiConnect();
                connect.Edit(new Emplo(int.Parse(textBox3.Text), textBox1.Text, textBox2.Text));
            }
            else
                MessageBox.Show("Uzupełnij dane","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
