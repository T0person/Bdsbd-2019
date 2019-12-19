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
                var client = new Serv.ServClient("NetTcpBinding_IServ");
                string id = client.LoginForm(Login_box.Text, Password_box.Text);
                if (id != "-1")
                {
                    Settings.Default["id"] = id;
                    char role = client.LoginForm_load(id);
                    Settings.Default["role"] = role;
                    Settings.Default.Save();
                    if (role == '1')
                    {
                        Hide();
                        Student nextform = new Student();
                        nextform.Show();
                    }
                    else if (role == '2')
                    {
                        Hide();
                        Teacher nextform = new Teacher();
                        nextform.Show();
                    }
                    else if (role == '3')
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
