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
        public string avtosalon = "0";
        public FormIzmenenie()
        {
            InitializeComponent();
        }
        
        public void SelectData()
        {
            Ohelp();
            Connect.conn.Open();
            //Меняет на форме название, с указанием того имени, которого меняется
            this.Text = $"Меняем пользователя ID: {PVHP.ID_PC}";
            string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM {avtosalon} WHERE name_pc = '{PVHP.ID_PC}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(SqlSelect, Connect.conn);
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
            Connect.conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text= PVHP.ComboId;
            SelectData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string n_pc = textBox1.Text;
            string wind = textBox2.Text;
            string n_cp = textBox3.Text;
            string opermem = textBox4.Text;
                string sql_update = $"UPDATE {avtosalon} SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}' WHERE name_pc='{PVHP.ID_PC}'";
            Connect.conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, Connect.conn);
                command.ExecuteNonQuery();
            Connect.conn.Close();
                this.Close();
        }
        public void Ohelp()
        {
            switch (PVHP.ComboId)
            {
                case "Changan":
                    avtosalon = "Comp1";
                    break;
                case "Kia":
                    avtosalon = "Comp2";
                    break;
                case "Naval":
                    avtosalon = "Comp3";
                    break;
                case "Shkoda":
                    avtosalon = "Comp4";
                    break;
                case "Nissan":
                    avtosalon = "Comp5";
                    break;
                case "Mitsubishi":
                    avtosalon = "Comp6";
                    break;
                case "Subaru":
                    avtosalon = "Comp7";
                    break;
                case "Geely":
                    avtosalon = "Comp8";
                    break;
                case "Peugeot":
                    avtosalon = "Comp9";
                    break;
                case "Opel":
                    avtosalon = "Comp10";
                    break;
                case "Trade-in":
                    avtosalon = "Comp11";
                    break;
            }
        }
    }
}
