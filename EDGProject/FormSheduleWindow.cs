using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDGProject.Model;

namespace EDGProject
{

    public partial class FormSheduleWindow : Form
    {
        Employees employees = new Employees();

        public FormSheduleWindow()
        {

            InitializeComponent();
        }

        //Dodac delegat zdarzenia przekazania nr ID Pracownika dodac linq firstofdefault
        
        public FormSheduleWindow(Employees employees)
        {
            
            InitializeComponent();
            this.employees.Name = employees.Name;
            this.employees.Surname = employees.Surname;
            this.employees.EmployeeId = employees.EmployeeId;
            textBox6.Text = DateTime.Now.ToString("dd.MM.yyyy");
            string dt = DateTime.Now.ToString("yyyy-dd-MM");
            ViewSTART(employees,dt);
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            string x = employees.Name + " " + employees.Surname;
            uzytkowniktoolStripStatusLabel1.Text = x;
        }

        public void clearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void Add_button1_Click(object sender, EventArgs e)
        {           
            FormxAddClient form = new FormxAddClient(employees.EmployeeId);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //clearText();
            //textBox6.Text = e.Start.ToString("dd-MM-yyyy");
            //string dt = textBox6.Text;
            //ConnectBooking connect = new ConnectBooking();
            //dataGridView1.DataSource = connect.viewData(employees.EmployeeId, e.Start.ToString("yyyy-dd-MM"));
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void ViewSTART(Employees employees,string dt)
        {
            ConnectBooking connect = new ConnectBooking();
            dataGridView1.DataSource = connect.viewData(employees, dt);
        }
        //delet button
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
