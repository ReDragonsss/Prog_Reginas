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
    public partial class DobavAuto : Form
    {
        public DobavAuto()
        {
            InitializeComponent();
        }
        public string avtosalon = "0";
        public bool InsertComp(string namepc, string window, string namecp, string operativmemory, string kodpc)
        {
            bool result = false;
            int InsertCount = 0;
            Ohelp();
            conn.Open();
            string sql = $"INSERT INTO {avtosalon} (name_pc, windows, name_cp, operativ_memory, kod_pc) VALUES ('{namepc}', '{window}', '{namecp}', '{operativmemory}', '{kodpc}')";
            try
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                InsertCount = command.ExecuteNonQuery();
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    result = true;
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
            lb.Items.Clear();
            lb.Items.Add($"Имя компьютера: {NamePc}");
            lb.Items.Add($"Версия Windows: {Windows}");
            lb.Items.Add($"Имя Процессора: {NameCp}");
            lb.Items.Add($"Количество RAM: {OperativMemory}");
            lb.Items.Add($"Код компьютера: {KodPc}");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        MySqlConnection conn;
        private void Form2_Load(object sender, EventArgs e)
        {
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_2_19_21;database=is_2_19_st21_KURS;password=70964010";
            conn = new MySqlConnection(connStr);
            GetListComp(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NamePc = textBox1.Text;
            string Windows = textBox2.Text;
            string NameCp = textBox3.Text;
            string OperativMemory = textBox4.Text;
            string KodPc = textBox5.Text;
            switch (id_auto)
            {
                case "0":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "1":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "2":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "3":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "4":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "5":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "6":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "7":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "8":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "9":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                case "10":
                    InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc);
                    GetListComp(listBox1); ;
                    break;
                default: MessageBox.Show($"Что-то пошло не по плану. Возможно не выбран автосервис! Или таблица перестала существовать?");
                    break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("База данных работает стабильно");
                    conn.Close();
                }
                catch (Exception osh)
                {
                    MessageBox.Show("Произошла ошибка" + osh);
                    conn.Close();
                }
            }
        }
        public void Ohelp()
        {
            switch (id_auto)
            {
                case "0":
                avtosalon = "Comp1";
                break;
                case "1":
                    avtosalon = "Comp2";
                    break;
                case "2":
                    avtosalon = "Comp3";
                    break;
                case "3":
                    avtosalon = "Comp4";
                    break;
                case "4":
                    avtosalon = "Comp5";
                    break;
                case "5":
                    avtosalon = "Comp6";
                    break;
                case "6":
                    avtosalon = "Comp7";
                    break;
                case "7":
                    avtosalon = "Comp8";
                    break;
                case "8":
                    avtosalon = "Comp9";
                    break;
                case "9":
                    avtosalon = "Comp10";
                    break;
                case "10":
                    avtosalon = "Comp11";
                    break;
            }
        }
        public string id_auto;// переменная для хранения номера выбранного столбца в комбобоксе
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // метод для получения номера выбранного столбца в комбобоксе
        {
            int Test;
            Test = comboBox1.SelectedIndex;
            id_auto = Convert.ToString(Test);
            // напрямую не могу вытащить код не позвoляет.
        }
    }
}


