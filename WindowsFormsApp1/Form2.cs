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
        public string avtosalon = "0";
        public bool InsertComp(string namepc,string window, string namecp, string operativmemory, string kodpc)
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
                    if (InsertCount !=0)
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
            else if (comboBox1.SelectedIndex == 3 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 4 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 5 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 6 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 7 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 8 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 9 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else if (comboBox1.SelectedIndex == 10 && InsertComp(NamePc, Windows, NameCp, OperativMemory, KodPc))
            {
                GetListComp(listBox1);
            }
            else
            {
                MessageBox.Show($"Что-то пошло не по плану. Возможно не выбран автосервис! Или таблица перестала существовать?");
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
                    MessageBox.Show("Произошла ошибка"+ osh);
                    conn.Close();
                }
            }
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

