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
using static WindowsFormsApp1.Program;
using ConntrolBDHelp;

namespace WindowsFormsApp1
{
    public partial class Autoriz : MetroFramework.Forms.MetroForm
    {
            static string sha256(string randomString)// метод для хеширования пароля
            {
                var crypt = new System.Security.Cryptography.SHA256Managed();
                var hash = new System.Text.StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
            public void GetUserInfo(string login)// метод для получение информации о данных сотрудника который залогинился 
            {
                Connect.conn.Open();
                string sql = $"SELECT * FROM Auto WHERE login='{login}'";
                MySqlCommand command = new MySqlCommand(sql, Connect.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Auth.auth_id = reader[0].ToString();
                    Auth.auth_login = reader[1].ToString();
                    Auth.auth_role = Convert.ToInt32(reader[3].ToString());
                }
                reader.Close();
                Connect.conn.Close();
            }
            public Autoriz()
            {
            InitializeComponent();
            }

            private void Autoriz_Load(object sender, EventArgs e)
            {

            }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Auto WHERE login = @un and password= @up";
            Connect.conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(sql, Connect.conn);
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            command.Parameters["@un"].Value = metroTextBox1.Text;
            command.Parameters["@up"].Value = sha256(metroTextBox2.Text);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Connect.conn.Close();
            if (table.Rows.Count > 0)
            {
                Auth.auth = true;
                GetUserInfo(metroTextBox1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные данные авторизации!");
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
