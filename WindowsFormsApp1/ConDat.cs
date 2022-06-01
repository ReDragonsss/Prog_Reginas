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
        public  string Avtosalon = "0";
        private const string host = "chuc.caseum.ru";
        private const string port = "33333";
        private const string database = "is_2_19_st21_KURS";
        private const string username = "st_2_19_21";
        private const string password = "70964010";
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
