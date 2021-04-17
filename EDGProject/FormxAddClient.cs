﻿using EDGProject.Model;
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
        public int myID { get; set; }
        public FormxAddClient(int x)
        {
            InitializeComponent();
            myID = x;
        }

        private void Add_button1_Click(object sender, EventArgs e)
        {
            MCustomer customer = new MCustomer();
            ConnectBooking connect = new ConnectBooking();
            customer.CustName = textBox1.Text;
            customer.CustSurname = textBox2.Text;
            customer.CustPhone = textBox3.Text;
            customer.CustUsluga = comboBox1.SelectedIndex;
            customer.CustGodzin = textBox6.Text;
            customer.CustDate = dateTimePicker1.Value;

            if (!string.IsNullOrEmpty(customer.CustName) && !string.IsNullOrEmpty(customer.CustSurname) &&
                !string.IsNullOrEmpty(customer.CustPhone) && !string.IsNullOrEmpty(customer.CustGodzin) &&
                !string.IsNullOrEmpty(customer.CustUsluga.ToString()) && customer.CustDate != null)
            {
                connect.Add(customer, myID);
                this.Close();
            }
            else
                MessageBox.Show("Uzupełnij dane", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);



        }
    }
}
