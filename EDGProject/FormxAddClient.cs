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

        Employees employees = new Employees();

        public FormxAddClient()
        {
            InitializeComponent();
        }



        private void Add_button1_Click(object sender, EventArgs e)
        {
            ConnectCustomer connectCustomer = new ConnectCustomer();
            connectCustomer.add_Customer(new Customer(textBox1.Text,textBox2.Text, textBox3.Text));

            ConnectBooking connectBooking = new ConnectBooking();
            Booking booking = new Booking();
            //Booking booking = new Booking();
            //booking.Name = textBox1.Text;
            //booking.Surname = textBox2.Text;
            //booking.Phone = textBox3.Text;
            //booking.jobName = comboBox1.Text;
            //booking.Time = TimeSpan.Parse(textBox6.Text);
            //booking.Date = dateTimePicker1.Value;

            //ConnectBooking connect = new ConnectBooking();
            //connect.Add(booking, employees.EmployeeId);
        }


        //private string name { get; set; }
        //public string Name
        //{
        //    get => name;
        //    set => name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
        //}
        //if (!string.IsNullOrEmpty(customer.Name) && !string.IsNullOrEmpty(customer.Surname) &&
        //    !string.IsNullOrEmpty(customer.Phone) && !string.IsNullOrEmpty(customer.CustGodzin) &&
        //    !string.IsNullOrEmpty(customer.CustUsluga.ToString()) && customer.CustDate != null)
        //{
        //    connect.Add(customer, myID);
        //    this.Close();
        //}
        //else
        //    MessageBox.Show("Uzupełnij dane", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);



    }
    
}
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