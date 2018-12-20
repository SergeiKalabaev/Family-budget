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

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 MainMenu = new Form2();
            MainMenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        } 
        private void LoadData()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Kys\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True;User Instance=True";
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            string query = "SELECT * FROM Users ORDER BY Id";
            SqlCommand command = new SqlCommand(query, Connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[3].ToString();
                data[data.Count - 1][2] = reader[4].ToString();
                data[data.Count - 1][3] = reader[5].ToString();
            }
            reader.Close();

            Connection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
       
        }
    }
}
