using Client.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Convert.ToInt32(Settings.Default["role"]) == '1')
            {
                client.Insert_Online(Settings.Default["id"].ToString());
                Application.Run(new Student());
            }
            else if (Convert.ToInt32(Settings.Default["role"]) == '2')
            {
                client.Insert_Online(Settings.Default["id"].ToString());
                Application.Run(new Teacher());
            }
            else if (Convert.ToInt32(Settings.Default["role"]) == '3')
            {
                client.Insert_Online(Settings.Default["id"].ToString());
                Application.Run(new Staff());
            }
            else
                Application.Run(new Login_form());
        }
    }
}
