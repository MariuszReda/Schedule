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
        public DocumentWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uzytkowniktoolStripStatusLabel1.Text = System.Environment.UserName;
        }

        private void Add_button1_Click(object sender, EventArgs e)
        {
            FormAddClient form = new FormAddClient();
            form.ShowDialog();
        }
    }
}
