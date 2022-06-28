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
    public partial class BazaDanihM : MetroFramework.Forms.MetroForm
    {
        public BazaDanihM()
        {
            InitializeComponent();
        }

        public string avtosalon = "Comp1";
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        private void BazaDanihM_Load(object sender, EventArgs e)
        {
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
            dataGridView1.Columns[0].HeaderText = "Имя компьютера";
            dataGridView1.Columns[1].HeaderText = "Версия винды";
            dataGridView1.Columns[2].HeaderText = "Процессор";
            dataGridView1.Columns[3].HeaderText = "Кол-во оперативки";
            dataGridView1.Columns[4].HeaderText = "Код инвентаризации";
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
            metroLabel2.Text = id_selected_rows;
           // PVHP.ID_PC = id_selected_rows;
        }
        public void GetListUsers()
        {
            Ohelp();
            string commandStr = $"SELECT name_pc, windows, name_cp, operativ_memory, kod_pc  FROM {avtosalon}";
            Connect.conn.Open();
            MyDA.SelectCommand = new MySqlCommand(commandStr, Connect.conn);
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            Connect.conn.Close();
            //Отражаем количество записей в ДатаГриде
            int count_rows = dataGridView1.RowCount - 1;
            metroLabel2.Text = (count_rows).ToString();
        }
        public bool DeleteInfo()// Запрос на удаление
        {
            Connect.conn.Open();
            int InsertCount = 0;
            bool result = false;
            string SqlDelete = $"DELETE FROM {avtosalon} WHERE name_pc ='" + id_selected_rows + "'";
            try
            {
                MySqlCommand command = new MySqlCommand(SqlDelete, Connect.conn);
                InsertCount = command.ExecuteNonQuery();
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                Connect.conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    MessageBox.Show($"Успешное удаление данных");
                    reload_list();
                }
            }
            return result;
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
        private void metroButton3_Click(object sender, EventArgs e)
        {
            // обновление
            reload_list();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // удаление
            DeleteInfo();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // изменение
            PVHP.ComboId = metroComboBox1.Text;
            PVHP.ID_PC = id_selected_rows;
            FormIzmenenie form1 = new FormIzmenenie();
            form1.ShowDialog();
            reload_list();
        }
        public string id_auto;// переменная для хранения номера выбранного столбца в комбобоксе
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Test;
            Test = metroComboBox1.SelectedIndex;
            id_auto = Convert.ToString(Test);
            // напрямую не могу вытащить код не позвoляет.
            reload_list();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PVHP.ComboId = metroComboBox1.Text;
            PVHP.ID_PC = id_selected_rows;
            FormIzmenenie form1 = new FormIzmenenie();
            form1.ShowDialog();
            reload_list();
        }
    }

}
