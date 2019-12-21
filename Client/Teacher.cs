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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            client.Delete_Online(Settings.Default["id"].ToString());
            Settings.Default["id"] = null;
            Settings.Default["role"] = null;
            Settings.Default.Save();
            Application.Exit();
        }

        private void My_sal_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            Sal.Text = "Монетки: " + client.Sal_find_stud(Convert.ToString(Settings.Default["id"]), Settings.Default["id"].ToString());
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            client.Delete_Online(Settings.Default["id"].ToString());
            Application.Exit();
        }

        private void My_fac_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("faculties", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void My_spec_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("specials", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }
    }
}
