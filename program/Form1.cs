using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
            LoadList();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TEST;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        
        private void button1_Click(object sender, EventArgs e)                              //button1 ADD
        {
            con.Open();
            cmd.CommandText = "INSERT INTO Cus (Godz,FirstName,LastName,Number,Comments,DataDay,Cus_Emp_ID) VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','"
                + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox8.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTED SUCCESS");
            clear();

        }

        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            monthCalendar1.SelectionEnd = DateTime.Now;
        }
        private void button2_Click(object sender, EventArgs e)                              //button2 VIEW
        {

            string query = "SELECT * FROM Cus WHERE Cus_Emp_ID ='" + textBox8.Text+ "'" ;         
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
           DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            clear();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)        //function select     
        {
            ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            monthCalendar1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }


        private void button3_Click(object sender, EventArgs e)                               //button3 EDIT
        {
            con.Open();
            string query = "UPDATE Cus SET Godz = '" + comboBox1.Text + "', FirstName= '" + textBox1.Text + "', LastName= '" + textBox2.Text + "', Number= '"
                + textBox3.Text + "', Comments= '" + textBox4.Text + "' WHERE Cus_ID = '" + ID.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            Refresh();
            con.Close();
            MessageBox.Show("UPDATE SUCCESS");

        }


        private void button4_Click(object sender, EventArgs e)                               //button4 DELETE
        {
            con.Open();
            string query = "DELETE FROM Cus WHERE Cus_ID = '" + ID.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record delete");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = con;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.textBox5.Text = e.Start.ToString("yyyy-MM-dd");
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT Cus_ID,Godz,FirstName,LastName,Number,Comments,DataDay FROM Cus WHERE DataDay LIKE '" + textBox5.Text + "%'", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)                  //button5 SEARCH
        {
            con.Open();
            string query = "SELECT Cus_ID,Godz,FirstName,LastName,Number,Comments,DataDay FROM Cus WHERE FirstName LIKE '" + textBox1.Text + "%'" +
                           " AND LastName LIKE '" + textBox2.Text + "%'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button6_Click(object sender, EventArgs e)                      //new pracownik
        {

            groupBox3.Visible = true;
            textBox6.Focus();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)                      //add Emp
        {
            string query = "INSERT INTO Emp(LastName) VALUES ('" + textBox6.Text + "')";
            con.Open();
            if (textBox6.Text.Length > 0)
            {
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("INSERTED SUCCESS");
            }
            groupBox3.Visible = false;
            textBox6.Text = "";
            con.Close();
            LoadList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            textBox7.Focus();
        }

        private void button9_Click(object sender, EventArgs e)                      // delete from res
        {
            con.Open();
            string query = "DELETE FROM Emp WHERE LastName = '" + textBox7.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record delete");
            textBox7.Text = "";

            groupBox4.Visible = false;
            textBox7.Text = "";
            LoadList();
        }
        
        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Emp where LastName ='" + listBox1.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            
            while(dr.Read())
            {
                string id = dr.GetInt32("Emp_ID").ToString();
                textBox8.Text = id;
            }
            con.Close();
        }
        public void LoadList()                                                      //metod load item on listbox
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Emp";
            SqlDataReader dr = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["LastName"]);
            }
            con.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Emp";
            SqlDataReader dr = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["LastName"]);
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }


        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }

        }
    }   
}
