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
        }
        public AddEmployee(Emplo emplo)
        {
            InitializeComponent();
            textBox1.Text = emplo.Name;
            textBox2.Text = emplo.Surname;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                Emplo employee = new Emplo(name, surname);
                DBiConnect dBi = new DBiConnect();
                Form form = new Form();
                dBi.Add(employee);
                this.Close();
            }
            else
                MessageBox.Show("Uzupełnij dane","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
