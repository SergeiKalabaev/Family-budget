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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 RegistrationForm = new Form3();
            RegistrationForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Kys\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True;User Instance=True";
        private void button3_Click(object sender, EventArgs e)
        {

            {
                IDbConnection Connection = new SqlConnection(connectionString);

                Connection.Open();
                IDbCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Login = @login AND Password = @password");
                cmd.Parameters.Add(new SqlParameter("Login", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("Password", textBox2.Text));
                cmd.Connection = Connection;
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Не верный пользователь или пароль");
                    // Действия, осуществляемые при неудачном входе
                }
                else
                {
                    MessageBox.Show("Вход выполнен успешно");
                    // Действия, осуществляемые при удачном входе
                    Form2 mainMenu = new Form2();
                    mainMenu.Show();
                    this.Hide();
                }
                IAppDomainSetup;
            i: string;

            }


        

           
          
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            
            sqlConnection = new SqlConnection(connectionString);
           
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Users]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
    }
}
