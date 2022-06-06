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
    public partial class FormIzmenenie : Form
    {
        MySqlConnection conn;
        public string avtosalon = "0";
        public FormIzmenenie()
        {
            InitializeComponent();
        }
        
        public void SelectData()
        {
            Ohelp();
            conn.Open();
            //Меняет на форме название, с указанием того имени, которого меняется
            this.Text = $"Меняем пользователя ID: {ControlData.ID_PC}";
            string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM {avtosalon} WHERE name_pc = '{ControlData.ID_PC}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(SqlSelect, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();

            }
            reader.Close();
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text=ControlData.ComboId;
            string connStr = "server=caseum.ru;port=33333;user=st_2_21_19;database=st_2_21_19;password=30518003";
            conn = new MySqlConnection(connStr);
            SelectData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string n_pc = textBox1.Text;
            string wind = textBox2.Text;
            string n_cp = textBox3.Text;
            string opermem = textBox4.Text;
            string avtosalon = null;
                string sql_update = $"UPDATE '{avtosalon}' SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
           $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
        }
        public void Ohelp()
        {
            if (ControlData.ComboId=="Changan")
            {
                avtosalon = "Comp1";
            }
            else if (ControlData.ComboId=="Kia")
            {
                avtosalon = "Comp2";
            }
            else if (ControlData.ComboId=="Naval")
            {
                avtosalon = "Comp3";
            }
            else if (ControlData.ComboId=="Shkoda")
            {
                avtosalon = "Comp4";
            }
            else if (ControlData.ComboId=="Nissan")
            {
                avtosalon = "Comp5";
            }
            else if (ControlData.ComboId=="Mitsubishi")
            {
                avtosalon = "Comp6";
            }
            else if (ControlData.ComboId=="Subaru")
            {
                avtosalon = "Comp7";
            }
            else if (ControlData.ComboId=="Geely")
            {
                avtosalon = "Comp8";
            }
            else if (ControlData.ComboId=="Peugeot")
            {
                avtosalon = "Comp9";
            }
            else if (ControlData.ComboId=="Opel")
            {
                avtosalon = "Comp10";
            }
            else if (ControlData.ComboId=="Trade-in")
            {
                avtosalon = "Comp11";
            }
        }
    }
}
