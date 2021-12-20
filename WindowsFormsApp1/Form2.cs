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
            bool result = false;
            int InsertCount = 0;
            if (comboBox1.SelectedIndex==0)
            {
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
            }
            else if (comboBox1.SelectedIndex==1)
            {
                conn.Open();
                string sql1 = $"INSERT INTO Comp2 (name_pc, windows, name_cp, operativ_memory, kod_pc) VALUES ('{namepc}', '{window}', '{namecp}', '{operativmemory}', '{kodpc}')";// запрос на дбавление параметров
                try
                {
                    // объект для выполнения SQL-запроса
                    MySqlCommand command = new MySqlCommand(sql1, conn);
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
            }
            else if (comboBox1.SelectedIndex==2)
            {
                conn.Open();
                string sql2 = $"INSERT INTO Comp3 (name_pc, windows, name_cp, operativ_memory, kod_pc) VALUES ('{namepc}', '{window}', '{namecp}', '{operativmemory}', '{kodpc}')";// запрос на дбавление параметров
                try
                {
                    // объект для выполнения SQL-запроса
                    MySqlCommand command = new MySqlCommand(sql2, conn);
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
            }
            else if (comboBox1.SelectedIndex==3)
            {
                conn.Open();
                string sql3 = $"INSERT INTO Comp4 (name_pc, windows, name_cp, operativ_memory, kod_pc) VALUES ('{namepc}', '{window}', '{namecp}', '{operativmemory}', '{kodpc}')";// запрос на дбавление параметров
                try
                {
                    // объект для выполнения SQL-запроса
                    MySqlCommand command = new MySqlCommand(sql3, conn);
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
            }
            else if (comboBox1.SelectedIndex==4)
            {
                conn.Open();
                string sql4 = $"INSERT INTO Comp5 (name_pc, windows, name_cp, operativ_memory, kod_pc) VALUES ('{namepc}', '{window}', '{namecp}', '{operativmemory}', '{kodpc}')";// запрос на дбавление параметров
                try
                {
                    // объект для выполнения SQL-запроса
                    MySqlCommand command = new MySqlCommand(sql4, conn);
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
            }
            return result;
        }
        public void GetListComp(ListBox lb)
        {
            string NamePc = textBox1.Text;
            string Windows = textBox2.Text;
            string NameCp = textBox3.Text;
            string OperativMemory = textBox4.Text;
            string KodPc = textBox5.Text;
            //Чистим ListBox
            lb.Items.Clear();
            lb.Items.Add($"Имя компьютера: {NamePc}");
            lb.Items.Add($"Версия Windows: {Windows}");
            lb.Items.Add($"Имя Процессора: {NameCp}");
            lb.Items.Add($"Количество RAM: {OperativMemory}");
            lb.Items.Add($"Код компьютера: {KodPc}");
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
            if (comboBox1.SelectedIndex == 0 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 1 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 2 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc) && comboBox1.SelectedIndex == 3)
            {
                GetListComp(listBox1);
            }
            else if (InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc) && comboBox1.SelectedIndex == 4)
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
    }
}
