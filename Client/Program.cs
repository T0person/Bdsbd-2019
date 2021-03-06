﻿using Client.Properties;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            client.Find_Created(Settings.Default["created_id"].ToString(), Settings.Default["created_table"].ToString());
            var role = client.LoginForm_load(Settings.Default["token"].ToString());
            if (role == '1')
                Application.Run(new Student());
            else if (role == '2')
                Application.Run(new Teacher());
            else if (role == '3')
                Application.Run(new Staff());
            else
                Application.Run(new Login_form());
        }
    }
}
