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
    class ControlData
    {
        public static string ID_PC = "0";
        public static string ComboId = "0";
        private const string host = "caseum.ru";
        private const string port = "33333";
        private const string database = "st_2_21_19";
        private const string username = "st_2_21_19";
        private const string password = "30518003";
        //Объявляем и инициализируем соединение
        private static readonly MySqlConnection conn = GetDBConnection();
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private static readonly MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private static readonly BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private static DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private static DataTable table = new DataTable();
        //Статичный метод, формирующий строку для подключения и возвращающий MySqlConnection
        public static MySqlConnection GetDBConnection()
        {
            string connString = $"server={host};port={port};user={username};database={database};password={password};";
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
