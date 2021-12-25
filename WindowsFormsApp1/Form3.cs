using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string host;
        public string port;
        public string database;
        public string username;
        public string password;
        private void button2_Click(object sender, EventArgs e)
        {
            host=textBox1.Text;
            port=textBox2.Text;
            database=textBox3.Text;
            username=textBox4.Text;
            password=textBox5.Text;
            ControlData.GetDBConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            host=textBox1.Text;
            port=textBox2.Text;
            database=textBox3.Text;
            username=textBox4.Text;
            password=textBox5.Text;
            string connString = $"server={host};port={port};user={username};database={database};password={password};";
            MySqlConnection conn = new MySqlConnection(connString);
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("База данных работает стабильно");
                    conn.Close();
                }
                catch (Exception osh)
                {
                    MessageBox.Show("Произошла ошибка"+ osh);
                    conn.Close();
                }
            }
        }
    }
}
