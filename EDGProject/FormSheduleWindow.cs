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
        public Employees employee;

        public FormSheduleWindow(DataTable data)
        {
            InitializeComponent();
        }
        public FormSheduleWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employee = Handler?.Invoke();
            string info = employee.Name + " " + employee.Surname;
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

        private void selectFirstRow()
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void Booking_button1_Click(object sender, EventArgs e)
        {
            FormxAddClient form1 = new FormxAddClient(Handler?.Invoke(),textBox5.Text, DateTime.Parse(textBox6.Text));
            form1.StartPosition = FormStartPosition.CenterParent;           
            form1.ShowDialog();
            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            clearText();
            textBox6.Text = e.Start.ToString("dd-MM-yyyy");
            string dt = textBox6.Text;
            ConnectBooking connect = new ConnectBooking();
            dataGridView1.DataSource = connect.viewData(Handler?.Invoke(),e.Start.ToString("yyyy-MM-dd"));
            selectFirstRow();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
                selectFirstRow();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure?", "Do you whant remove", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                ConnectBooking connectBooking = new ConnectBooking();
                var list = connectBooking.getAllBookings();
                ConnectVisitTime connectVisit = new ConnectVisitTime();
                var timeList = connectVisit.getAllTime();
                Booking booking = new Booking();
                VisitTime visitTime = new VisitTime();
                var n = timeList.Where(x => x != null && x.Time == TimeSpan.Parse(textBox5.Text)).FirstOrDefault();

                booking = list.Where(x =>
                    x.EmplyeesId == Handler?.Invoke().EmployeeId
                        && x.HourId == n.HourId
                        && x.Date == DateTime.Parse(textBox6.Text)).FirstOrDefault();
                            
                connectBooking.deleteBooking(booking);
            }
        }

        public delegate void ScheduleWindowClose(Employees employee);
        public event ScheduleWindowClose OnScheduleWindowClosed;

        private void FormSheduleWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnScheduleWindowClosed(employee);
        }
    }
}