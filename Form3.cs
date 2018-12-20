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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 LoginForm = new Form1();
            LoginForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Kys\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True;User Instance=True";
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();//соед с бд
            string sInsSql = "Insert into Users(Id, Login, Password, Name, Lastname)Values({0},'{1}','{2}','{3}','{4}')";
            
            int ID = Convert.ToInt32(textBox5.Text); //Данные с формы
            string Login = textBox1.Text;
            string Password = textBox2.Text;
            string Name = textBox3.Text;
            string Lastname = textBox4.Text;

            string sInsSort = string.Format(sInsSql, ID, Login, Password, Name, Lastname);//Вставка данных в БД с формы
            SqlCommand cmdIns = new SqlCommand(sInsSort, Connection);
            cmdIns.ExecuteNonQuery();
            MessageBox.Show(string.Format("Запись {0} успешно добавлена !", Name, Lastname), "Сообщение");
                
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
