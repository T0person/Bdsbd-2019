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
            //Settings.Default["id"] = null;
            //Settings.Default["role"] = null;
            //Settings.Default.Save();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Convert.ToInt32(Settings.Default["role"]) == '1')
                Application.Run(new Student());
            else if (Convert.ToInt32(Settings.Default["role"]) == '2')
                Application.Run(new Teacher());
            else if (Convert.ToInt32(Settings.Default["role"]) == '3')
                Application.Run(new Staff());
            else
                Application.Run(new Login_form());
        }
    }
}
