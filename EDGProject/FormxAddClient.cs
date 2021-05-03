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
    
    public partial class FormxAddClient : Form
    {

        public FormxAddClient()
        {
            InitializeComponent();
        }

        public FormxAddClient(Employees employee,string time, DateTime date)
        {
            InitializeComponent();
            this._employee = employee;
            dateTimePicker1.Value = date;
            textBox6.Text = time;
        }
        private Employees _employee;

        private void Add_button1_Click(object sender, EventArgs e)
        {
            ConnectCustomer connectCustomer = new ConnectCustomer();
            var customer = new Customer { Name = textBox1.Text, Surname = textBox2.Text, Phone = textBox3.Text };
            var id_customer = connectCustomer.add_Customer(customer);
            

            var connectJob = new ConnectJob();
            var listOfJob = connectJob.getAllJobs();
            var id_job = listOfJob.Where(c => c!=null  &&  c.jobName == comboBox1.Text).FirstOrDefault();

            var connectTime = new ConnectVisitTime();
            var listOfTime = connectTime.getAllTime();
            var id_time = listOfTime.Where(c => c != null && c.Time == TimeSpan.Parse(textBox6.Text)).FirstOrDefault();

            
            ConnectBooking connectBooking = new ConnectBooking();
            Booking booking = new Booking();
            booking.CustomerId = id_customer;
            booking.JobId = id_job.JobId;
            booking.HourId = id_time.HourId;
            booking.Date = dateTimePicker1.Value;
            booking.EmplyeesId = _employee.EmployeeId;


            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
                connectBooking.addBooking(booking);
            else
            {
                var listOfCustomer = connectCustomer.getAllCustomer();
                //customer.CustomerId = listOfCustomer.Where(x=> )
            }
                

        }

    }    
}


//var vistTime = new VisitTime();
//vistTime.Time = TimeSpan.Parse(textBox6.Text);


//Booking booking = new Booking();
//booking.Name = textBox1.Text;
//booking.Surname = textBox2.Text;
//booking.Phone = textBox3.Text;
//booking.jobName = comboBox1.Text;
//booking.Time = TimeSpan.Parse(textBox6.Text);
//booking.Date = dateTimePicker1.Value;

//ConnectBooking connect = new ConnectBooking();
//connect.Add(booking, employees.EmployeeId);

//if (!string.IsNullOrEmpty(customer.Name) && !string.IsNullOrEmpty(customer.Surname) &&
//    !string.IsNullOrEmpty(customer.Phone) && !string.IsNullOrEmpty(customer.CustGodzin) &&
//    !string.IsNullOrEmpty(customer.CustUsluga.ToString()) && customer.CustDate != null)
//{
//    connect.Add(customer, myID);
//    this.Close();
//}
//else
//    MessageBox.Show("Uzupełnij dane", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


//public FormxAddClient(Booking booking, int x)
//{
//    InitializeComponent();
//    textBox1.Text = booking.Name;
//    textBox2.Text = booking.Surname;
//    textBox3.Text = booking.Phone;
//    comboBox1.Text = booking.jobName;
//    textBox6.Text = booking.Time.ToString();
//    dateTimePicker1.Value = booking.Date;
//    employees.EmployeeId = x;
//}