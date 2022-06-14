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
    public partial class DobavClient : MetroFramework.Forms.MetroForm
    {
        public DobavClient()
        {
            InitializeComponent();
        }
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();
        string id_selected_rows = "0";
        private void DobavClient_Load(object sender, EventArgs e)
        {
            GetListUsers();
        }
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
        }
        public void GetListUsers()
        {
            string commandStr = $"SELECT login,password,lvl_low,lvl_medium,lvl_high,frozen_zapis FROM autorization";
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
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            //добавление
            string login = metroTextBox1.Text;
            string password = metroTextBox2.Text;
            bool d_dobav = metroCheckBox1.Checked;
            bool d_redact = metroCheckBox2.Checked;
            bool d_full = metroCheckBox3.Checked;
            bool d_moroz = metroCheckBox6.Checked;
            int InsertCount = 0;
            Connect.conn.Open();
            string sql = $"INSERT INTO autorization (login,password,lvl_low,lvl_medium,lvl_high,frozen_zapis) VALUES ('{login}', '{password}', '{d_dobav}', '{d_redact}', '{d_full}','{d_moroz}')";
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Connect.conn);
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

                }
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            // удаление
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string login = metroTextBox1.Text;
            string password = metroTextBox2.Text;
            bool d_dobav = metroCheckBox1.Checked;
            bool d_redact = metroCheckBox2.Checked;
            bool d_full = metroCheckBox3.Checked;
            bool d_moroz = metroCheckBox6.Checked;
            // сохранение
          //  string sql_update = $"UPDATE '' SET ='{}',='{}',='{}',='{}',='{}',='{}'" +
          //$"WHERE (='{PVHP.ID_Uch}')";
          //  Connect.conn.Open();
          //  MySqlCommand command = new MySqlCommand(sql_update, Connect.conn);
          //  command.ExecuteNonQuery();
          //  Connect.conn.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DobavClient dobavClient = new DobavClient();
            dobavClient.Close();
        }
        
    }
}
//if (metroCheckBox1.Checked == true)
//{
//    // код для проверки доступа к чему либо
//}
//else
//{
//   // код для проверки доступа к чему либо
//} без бд невозможно дальше работать