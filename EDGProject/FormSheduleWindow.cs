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
        public event EventHandler Handler;
        public FormSheduleWindow(DataTable data)
        {
            InitializeComponent();
        }
        public FormSheduleWindow()
        {
            InitializeComponent();
        }

        private Employees pickEmployee()
        {
            string q = Handler?.Invoke();
            ConnectEmloyee connect = new ConnectEmloyee();
            return connect.GetEmplo(int.Parse(q));
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            Employees employees = pickEmployee();
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

        private void Booking_button1_Click(object sender, EventArgs e)
        {
            //Employees employees = pickEmployee();
            //Booking booking = new Booking();
            //booking.Name = textBox1.Text;
            //booking.Surname = textBox2.Text;
            //booking.Phone = textBox3.Text;
            //booking.jobName = textBox4.Text;
            //booking.Time = TimeSpan.Parse(textBox5.Text);
            //booking.Date = DateTime.Parse(textBox6.Text);
            //FormxAddClient form = new FormxAddClient(booking, employees.EmployeeId);
            //form.StartPosition = FormStartPosition.CenterParent;
            //form.ShowDialog();
            //Employees employees = pickEmployee();

            FormxAddClient form1 = new FormxAddClient();
            form1.StartPosition = FormStartPosition.CenterParent;
            
            form1.ShowDialog();

        }

        
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            clearText();
            textBox6.Text = e.Start.ToString("dd-MM-yyyy");
            string dt = textBox6.Text;
            ConnectBooking connect = new ConnectBooking();
            dataGridView1.DataSource = connect.viewData(pickEmployee(), e.Start.ToString("yyyy-MM-dd"));
            selectFirstRow();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
        
        //delet button
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void selectFirstRow()           
        {
            //ConnectBooking connect = new ConnectBooking();
            //Employees employees = pickEmployee();
            //string dt = textBox6.Text;
            //dataGridView1.DataSource = connect.viewData(employees, dt);
            IEnumerable<string> list = dataGridView1.Rows
                .OfType<DataGridViewRow>().Where(x => x.Cells[0].Value != null) 
                .Select(x => x.Cells[0].Value.ToString())
                .ToList();

            textBox5.Text= list.First();
        }
    }
}


