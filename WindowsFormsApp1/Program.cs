using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
        }
        public static class Auth// данные авторизации
        {
            public static bool auth = false;//Статичное поле, которое хранит значение статуса авторизации
            public static string auth_id = null;//Статичное поле, которое хранит значения ID пользователя
            public static string auth_login = null;//Статичное поле, которое хранит значения ФИО пользователя
            public static int auth_role = 0;//Статичное поле, которое хранит количество привелегий пользователя
        }
    }
    public class PVHP
    {
        public static string ID_PC = "0";
        public string Avtosalon = "0";
        public static string ComboId = "0";
    }
    public class Connect
    {
        private const string host = "chuc.caseum.ru";
        private const string port = "33333";
        private const string database = "is_2_19_st21_KURS";
        private const string username = "st_2_19_21";
        private const string password = "70964010";
        //Объявляем и инициализируем соединение
        public static readonly MySqlConnection conn = new MySqlConnection($"server={host};port={port};user={username};database={database};password={password};");
    }
}
