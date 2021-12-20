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
    public partial class _1avtosalon : Form
    {
        public _1avtosalon()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        private void _1avtosalon_Load(object sender, EventArgs e)
        {

            string connStr = "server=caseum.ru;port=33333;user=st_2_21_19;database=st_2_21_19;password=30518003";
            conn=new MySqlConnection(connStr);
            //string sql = $"SELECT name_pc, windows, name_cp, operativ_memory, kod_pc FROM Comp1";// запрос в бд
            GetListUsers();
            //Видимость полей в гриде
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;

            //Ширина полей
            dataGridView1.Columns[0].FillWeight = 15;
            dataGridView1.Columns[1].FillWeight = 20;
            dataGridView1.Columns[2].FillWeight = 25;
            dataGridView1.Columns[3].FillWeight = 30;
            dataGridView1.Columns[4].FillWeight = 10;
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

        }
        public void reload_list()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
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
            //ControlData.ID_STUD = id_selected_rows;
        }
        public void GetListUsers()
        {
            //Запрос для вывода строк в БД
            string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp1";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
            //Отражаем количество записей в ДатаГриде
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
        }

        public void DeleteInfo()
        {
            string SqlDelete = "DELETE FROM Comp1 WHERE name_pc ='"+ id_selected_rows+"'"; //запрос на удаление
            MySqlCommand delete= new MySqlCommand(SqlDelete, conn); // запрос на обновление данных
            try
            {
                conn.Open();
                delete.ExecuteNonQuery();
                MessageBox.Show("Информация о компьютере удалена");
            }
            catch(Exception osh)
            {
                MessageBox.Show("Удаление неуспешно ошибка:"+ osh); 
            }
            finally
            {
                conn.Close();
                reload_list();
            }
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
            string pc = dataGridView1.SelectedCells[0].Value.ToString();
            string wind = dataGridView1.SelectedCells[1].Value.ToString();
            string cp = dataGridView1.SelectedCells[2].Value.ToString();
            string oper = dataGridView1.SelectedCells[3].Value.ToString();
            string new_id = id_selected_rows;
            //refresh();
        }
        public void refresh(string pc, string wind, string cp, string oper, string new_id)
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string update = $"UPDATE Comp1 SET name_pc='{pc}',windows='{wind}', name_cp='{cp}', operativ_memory='{oper}' WHERE (id='{new_id}')";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(update, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            //Обновляем DataGrid
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


