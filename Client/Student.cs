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
    public partial class Student : Form
    {
        public Student()
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

        private void Close_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            client.Delete_Online(Settings.Default["id"].ToString());
            Application.Exit();
        }

        private void Find_fac_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            Fac.Text = client.Fac_find_stud(Convert.ToString(Settings.Default["id"]));
        }

        private void Find_spec_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            Spec.Text = client.Spec_find_stud(Convert.ToString(Settings.Default["id"]));
        }

        private void Find_sal_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            Sal.Text = client.Sal_find_stud(Convert.ToString(Settings.Default["id"]));
        }

        private void Find_all_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            Fac.Text = client.Fac_find_stud(Convert.ToString(Settings.Default["id"]));
            Spec.Text = client.Spec_find_stud(Convert.ToString(Settings.Default["id"]));
            Sal.Text = client.Sal_find_stud(Convert.ToString(Settings.Default["id"]));
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }
    }
}
