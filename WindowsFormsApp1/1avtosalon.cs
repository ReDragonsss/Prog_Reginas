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
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        private void _1avtosalon_Load(object sender, EventArgs e)
        {
            string connStr = "server=caseum.ru;port=33333;user=st_2_21_19;database=st_2_21_19;password=30518003";
            conn=new MySqlConnection(connStr);
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
            ControlData.ID_PC = id_selected_rows;
        }
        public void GetListUsers()
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp1";
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
            else if (toolStripComboBox1.SelectedIndex == 1)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp2";
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
            else if (toolStripComboBox1.SelectedIndex == 2)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp3";
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
            else if (toolStripComboBox1.SelectedIndex == 3)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp4";
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
            else if (toolStripComboBox1.SelectedIndex == 4)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp5";
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
            else if (toolStripComboBox1.SelectedIndex == 5)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp6";
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
            else if (toolStripComboBox1.SelectedIndex == 6)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp7";
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
            else if (toolStripComboBox1.SelectedIndex == 7)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp8";
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
            else if (toolStripComboBox1.SelectedIndex == 8)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp9";
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
            else if (toolStripComboBox1.SelectedIndex == 9)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp10";
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
            else if (toolStripComboBox1.SelectedIndex == 10)
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp11";
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
            else
            {
                string commandStr = "SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM Comp1";
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
        }
        public bool DeleteInfo()// Запрос на удаление
        {
            conn.Open();
            int InsertCount = 0;
            bool result = false;
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                string SqlDelete = "DELETE FROM Comp1 WHERE name_pc ='"+ id_selected_rows+"'";
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
            }
            else if (toolStripComboBox1.SelectedIndex == 1)
            {
                string SqlDelete = "DELETE FROM Comp2 WHERE name_pc ='"+ id_selected_rows+"'"; 
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
            }
            else if (toolStripComboBox1.SelectedIndex == 2)
            {
                string SqlDelete = "DELETE FROM Comp3 WHERE name_pc ='"+ id_selected_rows+"'";
                try
                {
                    MySqlCommand command = new MySqlCommand(SqlDelete, conn);
                    InsertCount = command.ExecuteNonQuery();
                }
                catch (Exception osh)
                {
                    InsertCount = 0;
                    MessageBox.Show($"Возникла ошибка -->{osh}");
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
            }
            else if (toolStripComboBox1.SelectedIndex == 3)
            {
                string SqlDelete = "DELETE FROM Comp4 WHERE name_pc ='"+ id_selected_rows+"'";
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
            }
            else if (toolStripComboBox1.SelectedIndex == 4)
            {
                string SqlDelete = "DELETE FROM Comp5 WHERE name_pc ='"+ id_selected_rows+"'";
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
            }
            else if (toolStripComboBox1.SelectedIndex == 5)
            {
                string SqlDelete = "DELETE FROM Comp6 WHERE name_pc ='"+ id_selected_rows+"'"; 
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
            }
            else if (toolStripComboBox1.SelectedIndex == 6)
            {
                string SqlDelete = "DELETE FROM Comp7 WHERE name_pc ='"+ id_selected_rows+"'";
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
            }
            else if (toolStripComboBox1.SelectedIndex == 7)
            {
                string SqlDelete = "DELETE FROM Comp8 WHERE name_pc ='"+ id_selected_rows+"'";
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
            }
            else if (toolStripComboBox1.SelectedIndex == 8)
            {
                string SqlDelete = "DELETE FROM Comp9 WHERE name_pc ='"+ id_selected_rows+"'"; 
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
            }
            else if (toolStripComboBox1.SelectedIndex == 9)
            {
                string SqlDelete = "DELETE FROM Comp10 WHERE name_pc ='"+ id_selected_rows+"'";
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
            }
            else if (toolStripComboBox1.SelectedIndex == 10)
            {
                string SqlDelete = "DELETE FROM Comp11 WHERE name_pc ='"+ id_selected_rows+"'";
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
            }
            else
            {
                MessageBox.Show("Ошибка удаление. Возможно невыбран компьютер?");  
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
            ControlData.ComboId=toolStripComboBox1.Text;
            ControlData.ID_PC = id_selected_rows;
            Form1 form1 = new Form1();
            form1.ShowDialog();
            reload_list();
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ControlData.ComboId=toolStripComboBox1.Text;
            ControlData.ID_PC = id_selected_rows;
            Form1 form1 = new Form1();
            form1.ShowDialog();
            reload_list();
        }
    }
}


