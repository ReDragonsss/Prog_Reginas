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
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }
        public void SelectData()
        {
            conn.Open();
            //Меняет на форме название, с указанием того имени, которого меняется
            this.Text = $"Меняем пользователя ID: {ControlData.ID_PC}";
            if (ControlData.ComboId=="Changan")
            {             
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp1 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Kia")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp2 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Naval")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp3 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Shkoda")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp4 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Nissan")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp4 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Mitsubishi")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp4 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Subaru")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp4 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Geely")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp4 WHERE name_pc = '{ControlData.ID_PC}'";
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
            else if (ControlData.ComboId=="Peugeot")
            {
                string SqlSelect = $"SELECT name_pc, windows, name_cp, operativ_memory FROM Comp4 WHERE name_pc = '{ControlData.ID_PC}'";
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
            if (ControlData.ComboId=="Changan")
            {
                string sql_update = $"UPDATE Comp1 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
        $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Kia")
            {
                string sql_update = $"UPDATE Comp2 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
  $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Naval")
            {
                string sql_update = $"UPDATE Comp3 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
   $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Shkoda")
            {
                string sql_update = $"UPDATE Comp4 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
  $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Nissan")
            {
                string sql_update = $"UPDATE Comp2 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
  $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Mitsubishi")
            {
                string sql_update = $"UPDATE Comp2 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
  $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Geely")
            {
                string sql_update = $"UPDATE Comp2 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
  $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Peugeot")
            {
                string sql_update = $"UPDATE Comp2 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
  $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            else if (ControlData.ComboId=="Kia")
            {
                string sql_update = $"UPDATE Comp2 SET name_pc='{n_pc}', windows='{wind}', name_cp='{n_cp}', operativ_memory='{opermem}'" +
  $"WHERE (name_pc='{ControlData.ID_PC}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update, conn);
                command.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
        }
    }
}
