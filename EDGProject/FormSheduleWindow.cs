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
            //first or defult
            InitializeComponent();
            this.employees.Name = employees.Name;
            this.employees.Surname = employees.Surname;
            this.employees.EmployeeId = employees.EmployeeId;
            string godzina = 

            textBox6.Text = DateTime.Now.ToString("dd.MM.yyyy");
            string dt = DateTime.Now.ToString("yyyy-MM-dd");
            viewStart(employees,dt);
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {
            string info = employees.Name + " " + employees.Surname;
            uzytkowniktoolStripStatusLabel1.Text = info;
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
            Booking booking = new Booking();
            booking.Name = textBox1.Text;
            booking.Surname = textBox2.Text;
            booking.Phone = textBox3.Text;
            booking.jobName = textBox4.Text;
            booking.Time = TimeSpan.Parse(textBox5.Text);
            booking.Date = DateTime.Parse(textBox6.Text);
            FormxAddClient form = new FormxAddClient(booking,employees.EmployeeId);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            clearText();
            textBox6.Text = e.Start.ToString("dd-MM-yyyy");
            string dt = textBox6.Text;
            ConnectBooking connect = new ConnectBooking();
            dataGridView1.DataSource = connect.viewData(employees, e.Start.ToString("yyyy-MM-dd"));
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
        
 
        private void viewStart(Employees employees,string dt)
        {
            ConnectBooking connect = new ConnectBooking();
            dataGridView1.DataSource = connect.viewData(employees, dt);

            IEnumerable<string> list = dataGridView1.Rows  // template dla calego row
                .OfType<DataGridViewRow>().Where(x => x.Cells[0].Value != null)
                .Select(x => x.Cells[0].Value.ToString())
                .ToList();

            textBox5.Text = list.First();
        }

        //delet button
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
