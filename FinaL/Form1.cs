using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinaL
{
    public partial class Form1 : Form
    {
       // SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        L c = new L();
     
  

      

        private void Button2_Click(object sender, EventArgs e)
        {
            c.Name = textBox3.Text;
            c.Surname = textBox4.Text;
            c.Doctor = textBox5.Text;
            c.Disease = textBox6.Text;

            bool success = c.Insert(c);
            if (success)
            {
                MessageBox.Show("New Patient Added");
                Clear();
            }
            else
            {
                MessageBox.Show("FAIL");
            }
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Write: ID, Name, Surname, Doctor or Disease";//подсказка
            textBox1.ForeColor = Color.Gray;
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            c.ID = int.Parse(textBox2.Text);
            c.Name = textBox3.Text;
            c.Surname = textBox4.Text;
            c.Doctor = textBox5.Text;
            c.Disease = textBox6.Text;
         
            bool success = c.Update(c);
            if (success)
            {
                MessageBox.Show("Updated.");
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to update.");
            }
        }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;

            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl WHERE Name LIKE '%" + keyword + "%' OR Surname LIKE '%" + keyword + "%' OR Doctor LIKE '%" + keyword + "%' OR Disease LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            c.ID = Convert.ToInt32(textBox2.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                MessageBox.Show("Deleted.");
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to delete.");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Process.Start("http://almaty-cgkb.kz/ru/");
        }
    }
}

