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
        public static MySqlConnection GetDBConnection()
        {
            string connString = $"server={host};port={port};user={username};database={database};password={password};";
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
