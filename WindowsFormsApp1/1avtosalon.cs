using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class _1avtosalon : Form
    {
        public _1avtosalon()
        {
            InitializeComponent();
        }

        private void _1avtosalon_Load(object sender, EventArgs e)
        {
            //vivod conn = new vivod();//создание конекта
            //MySqlConnection connn = new MySqlConnection(conn.Connstring);// сторка подключения
            //string sql = $"SELECT";// запрос в бд
            //try// правильность подключ
            //{
            //    connn.Open();
            //    MessageBox.Show("Подключение");
            //    MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connn);
            //DataSet dataset = new DataSet();
            //IDataAdapter.Fill(dataset);// заполнение датагрида
            //    dataGridView1.DataSource = dataset.Tables[0];
            //    connn.Close();
            //}
            //catch (Exception osh)
            //{
            //    MessageBox.Show("Произошла ошибка" + osh);
            //    connn.Close();
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
        public void reloading()
        {
            //ControlData.ReoladList();
            //ControlData.GetListUsers();
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentCell.Selected= true;
                // GetSelectedIDSring();
            }
        }
        public void GetSelectedIDString()
        {
            string IndexSelectedRows;
            IndexSelectedRows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //IdSelectedRows = dataGridView1.Rows[Convert.ToInt32(IndexSelectedRows)].Cells[0].Value.ToString;
            //toolStripLabel2.Text = IdSelectedRows;
            //ControlData.ID_STUD = IdSelectedRows; 
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}


