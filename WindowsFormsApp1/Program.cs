using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
}
