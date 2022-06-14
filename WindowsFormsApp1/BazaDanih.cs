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
using Excel = Microsoft.Office.Interop.Excel;



namespace WindowsFormsApp1
{
    public partial class _1avtosalon : Form
    {
        public _1avtosalon()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        public string avtosalon="Comp1";
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        private void _1avtosalon_Load(object sender, EventArgs e)
        {
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_2_19_21;database=is_2_19_st21_KURS;password=70964010";
            conn =new MySqlConnection(connStr);
            GetListUsers();
            //Видимость полей в гриде
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            //Ширина полей
            dataGridView1.Columns[0].FillWeight = 14;
            dataGridView1.Columns[1].FillWeight = 21;
            dataGridView1.Columns[2].FillWeight = 25;
            dataGridView1.Columns[3].FillWeight = 28;
            dataGridView1.Columns[4].FillWeight = 12;
            //Режим для полей "Только для чтения"
            dataGridView1.Columns[0].ReadOnly = false;
            dataGridView1.Columns[1].ReadOnly = false;
            dataGridView1.Columns[2].ReadOnly = false;
            dataGridView1.Columns[3].ReadOnly = false;
            dataGridView1.Columns[4].ReadOnly = true;
            //Растягивание полей грида
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Убираем заголовки строк
            dataGridView1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText="Имя компьютера";
            dataGridView1.Columns[1].HeaderText="Версия винды";
            dataGridView1.Columns[2].HeaderText="Процессор";
            dataGridView1.Columns[3].HeaderText="Кол-во оперативки";
            dataGridView1.Columns[4].HeaderText="Код инвентаризации";
        }
        public void reload_list()
        {
            table.Clear();
            GetListUsers();
        }
        //Метод получения ID выделенной строки, для последующего вызова его в нужных методах
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            //Указываем ID выделенной строки в метке
            toolStripLabel2.Text = id_selected_rows;
            PVHP.ID_PC = id_selected_rows;
        }
        public void GetListUsers()
        {
            Ohelp();
            string commandStr = $"SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM {avtosalon}";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            conn.Close();
            //Отражаем количество записей в ДатаГриде
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
        }
        public bool DeleteInfo()// Запрос на удаление
        {
            conn.Open();
            int InsertCount = 0;
            bool result = false;
            string SqlDelete = $"DELETE FROM {avtosalon} WHERE name_pc ='"+ id_selected_rows+"'";
            try
            {
                MySqlCommand command = new MySqlCommand(SqlDelete, conn);
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
                    MessageBox.Show($"Успешное удаление данных");
                    reload_list();
                }
            }
            return result;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            reload_list();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DeleteInfo();
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PVHP.ComboId =toolStripComboBox1.Text;
            PVHP.ID_PC = id_selected_rows;
            FormIzmenenie form1 = new FormIzmenenie();
            form1.ShowDialog();
            reload_list();
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PVHP.ComboId =toolStripComboBox1.Text;
            PVHP.ID_PC = id_selected_rows;
            FormIzmenenie form1 = new FormIzmenenie();
            form1.ShowDialog();
            reload_list();
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
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)// метод для получения номера выбранного столбца в комбобоксе
        {
            int Test;
            Test = toolStripComboBox1.SelectedIndex;
            id_auto = Convert.ToString(Test);
            // напрямую не могу вытащить код не позвoляет.
            reload_list();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Открытие БД Inventorizacia в excel
            Excel.Application exApp = new Excel.Application(); // предположительно открытие Exel
            exApp.Workbooks.Add(); // предположительно это создание файла в Exel
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet; // может быть создание листа? 
            int j, i; // переменные
            for (i = 0; i <= dataGridView1.RowCount - 1; i++) // начало сбора данных из датагрида
            {
                for (j = 0; j < dataGridView1.ColumnCount - 0; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }  // конец сбора данных из датагрида
            }
            exApp.Visible = true;
        }
    }
}
//--------------------------------------------------------------------------------------\\
////Открытие БД Inventorizacia в excel
//Excel.Application exApp = new Excel.Application(); // предположительно открытие Exel
//exApp.Workbooks.Add(); // предположительно это создание файла в Exel
//Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet; // может быть создание листа? 
//int j, i; // переменные
//for (i = 0; i <= dataGridView2.RowCount - 2; i++) // начало сбора данных из датагрида
//{
//    for (j = 0; j < dataGridView2.ColumnCount - 1; j++)
//    {
//        wsh.Cells[i + 1, j + 1] = dataGridView2[j, i].Value.ToString();
//    }  // конец сбора данных из датагрида

//}
//exApp.Visible = true;
//--------------------------------------------------------------------------------------\\


