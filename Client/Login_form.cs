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
    public partial class Login_form : Form
    {
        Serv.ServClient client = new Serv.ServClient("NetTcpBinding_IServ");
        public Login_form()
        {
            InitializeComponent();
        }

        private void Cansel_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            
            if (Login_box.Text == "" || Password_box.Text == "")
                MessageBox.Show("Поля не заполнены!");
            else
            {
                string[] id_tok = client.LoginForm(Login_box.Text, Password_box.Text);
                if (id_tok[0] == "0")
                    MessageBox.Show("Такой пользователь уже есть!");
                else if (id_tok[0] != "-1")
                {
                    Settings.Default["id"] = id_tok[0];
                    Settings.Default["role"] = Convert.ToChar(id_tok[2]);
                    Settings.Default["token"] = id_tok[1];
                    Settings.Default.Save();
                    if (Convert.ToChar(Settings.Default["role"]) == '1')
                    {
                        Hide();
                        Student nextform = new Student();
                        nextform.Show();
                    }
                    else if (Convert.ToChar(Settings.Default["role"]) == '2')
                    {
                        Hide();
                        Teacher nextform = new Teacher();
                        nextform.Show();
                    }
                    else if (Convert.ToChar(Settings.Default["role"]) == '3')
                    {
                        Hide();
                        Staff nextform = new Staff();
                        nextform.Show();
                    }
                }
                else
                    MessageBox.Show("Нет такого пользователя!");
            }
        }

        private void Login_form_Load(object sender, EventArgs e)
        {

        }
    }
}
