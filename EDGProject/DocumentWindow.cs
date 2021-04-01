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
    public partial class DocumentWindow : Form
    {
        public int ID { get; set; }

        public DocumentWindow()
        {
            InitializeComponent();
        }
        
        public DocumentWindow(int x)
        {
            InitializeComponent();
            ID = x;
            View();
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
            FormAddClient form = new FormAddClient();
            form.ShowDialog();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            clearText();
            textBox6.Text = e.Start.ToString("yyyy-MM-dd");
            //SqlDataAdapter SDA = new SqlDataAdapter("SELECT c.Godz,c.FirstName,c.LastName,c.Number,c.Comments,c.DataDay,e.LastName FROM Cus As c,Emp As e WHERE c.Cus_Emp_ID = e.Emp_ID AND DataDay LIKE '" + textBox5.Text + "%'"
            //    + " AND c.Cus_Emp_ID LIKE'" + textBox8.Text + "%'", con);
            //DataTable dt = new DataTable();
            //SDA.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            // textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            // textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            // monthCalendar1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            // textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void View()
        {
            ConnectCustomer connect = new ConnectCustomer();
            dataGridView1.DataSource = connect.View();
        }
    }
}
