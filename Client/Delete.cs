using Client.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            Hide();
            Staff nextform = new Staff();
            nextform.Show();
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (Set_id.Text == "")
            {
                MessageBox.Show("Поля не заполнены!");
            }
            else
            {
                var client = new Serv.ServClient("NetTcpBinding_IServ");
                string del = client.Delete_table(Set_id.Text,Settings.Default["id"].ToString());
                if (del == "1")
                {
                    MessageBox.Show("Все прошло удачно!");
                    string exit_del = client.Exit_to_del(Set_id.Text, Settings.Default["id"].ToString());
                    if (exit_del != "1")
                    {
                        Settings.Default["id"] = null;
                        Settings.Default["role"] = null;
                        Settings.Default.Save();
                        Application.Exit();
                    }
                }
                else
                    MessageBox.Show("Нет такого пользователя!");
            }
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
    }
}
