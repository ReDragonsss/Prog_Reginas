using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string windows =(textBox1.Text);//попробывать сконверить в double или в float
            byte operativka =Convert.ToByte(textBox2.Text);
            ushort diagonal =Convert.ToUInt16(textBox1.Text);
            string model = (textBox2.Text);
            string sql = $"INSERT INTO bd_kompykter (vers_wind, kolvo_operativ)  VALUES ('{windows}','{operativka}')";// запрос на дбавление параметров
            string sql2 = $"INSERT INTO bd_monitor (diagonal, model) VALUES ('{diagonal}','{model}')";
            //try// правильность подключ
            //{
            //    connn.Open();
            //    MessageBox.Show("Данные занесены в базу данных");
            //    MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, conn);
            //    connn.Close();
            //}
            //catch (Exception osh)
            //{
            //    MessageBox.Show("Произошла ошибка" + osh);
            //    connn.Close();
            //}
        }
    }
}
