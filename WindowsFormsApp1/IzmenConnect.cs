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
    public partial class IzmenConnect : Form
    {
        // здесь должен происходить выбор своего подключения..
        public IzmenConnect()
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
            database =textBox3.Text;
            username=textBox4.Text;
            password=textBox5.Text;
           // ControlData.conn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            host=textBox1.Text;
            port=textBox2.Text;
            database=textBox3.Text;
            username=textBox4.Text;
            password=textBox5.Text;
           // ControlData.conn();
        }
        // ..оно даже почти готово просто надо изменить в ConDat параметры подключения
    }
}
