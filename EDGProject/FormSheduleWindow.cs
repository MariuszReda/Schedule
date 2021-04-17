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
    public partial class FormSheduleWindow : Form
    {
        public int ID { get; set; }

        public FormSheduleWindow()
        {
            InitializeComponent();
        }
        
        public FormSheduleWindow(int x)
        {
            InitializeComponent();
            ID = x;
            textBox6.Text = DateTime.Now.ToString("dd.MM.yyyy");
            string dt = DateTime.Now.ToString("yyyy-dd-MM");
             ViewSTART(ID,dt);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uzytkowniktoolStripStatusLabel1.Text = System.Environment.UserName;          
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
            
            FormxAddClient form = new FormxAddClient(ID);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            clearText();
            textBox6.Text = e.Start.ToString("dd-MM-yyyy");
            string dt = textBox6.Text;
            ConnectCustomer connect = new ConnectCustomer();
            dataGridView1.DataSource = connect.viewData(ID, e.Start.ToString("yyyy-dd-MM"));
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

        private void ViewSTART(int x,string dt)
        {
            ConnectCustomer connect = new ConnectCustomer();
            dataGridView1.DataSource = connect.viewData(x,dt);
        }
        //delet button
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
