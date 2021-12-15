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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public bool InsertComp(string namepc,string window, string namecp, string operativmemory, string kodpc)
        {
            int InsertCount = 0;
            bool result = false;
            conn.Open();
            string sql = $"INSERT INTO Comp1 (name_pc, windows, name_cp, operativ_memory, kod_pc) VALUES ('{namepc}', '{window}', '{namecp}', '{operativmemory}', '{kodpc}')";// запрос на дбавление параметров
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                // закрываем подключение к БД
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount !=0)
                {
                    //то результат операции - истина
                    result = true;
                }
            }
            //Вернём результat
            return result;
        }
        public void GetListComp(ListBox lb)
        {
            //Чистим ListBox
            lb.Items.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql1 = $"SELECT * FROM Comp1";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql1, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                lb.Items.Add($"name: {reader[1].ToString()}");
                lb.Items.Add($"wind{reader[2].ToString()}");
                lb.Items.Add($"cp{reader[3].ToString()}");
                lb.Items.Add($"operativ{reader[4].ToString()}");
                lb.Items.Add($"kodPc{reader[5].ToString()}");

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
        MySqlConnection conn;
        private void Form2_Load(object sender, EventArgs e)
        {
            string connStr = "server=caseum.ru;port=33333;user=st_2_21_19;database=st_2_21_19;password=30518003";
            conn=new MySqlConnection(connStr);
            GetListComp(listBox1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string NamePc =textBox1.Text;
            string Windows =textBox2.Text;
            string NameCp =textBox3.Text;
            string OperativMemory =textBox4.Text;
            string KodPc =textBox5.Text;
            if (InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Произошла ошибка.");

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                try//проверка на правильность данных
                {
                    conn.Open();
                    MessageBox.Show("Подключение");
                    conn.Close();

                }
                catch (Exception osh)
                {
                    MessageBox.Show("Произошла ошибка"+ osh);
                    conn.Close();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
