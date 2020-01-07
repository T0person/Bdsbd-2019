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
        int offset,max;
        Serv.ServClient client = new Serv.ServClient("NetTcpBinding_IServ");
        public Teacher()
        {
            InitializeComponent();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            client.Delete_Online(Settings.Default["token"].ToString());
            Settings.Default["id"] = null;
            Settings.Default["role"] = null;
            Settings.Default.Save();
            Application.Exit();
        }

        private void My_sal_Click(object sender, EventArgs e)
        {
            Sal.Text = "Монетки: " + client.Sal_find_stud(Settings.Default["token"].ToString());
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void My_fac_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_faculties(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());

        }

        private void My_spec_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_specials(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }

        private void Plus50_Click(object sender, EventArgs e)
        {
            offset += 50;
            if (offset > max)
                offset = max - offset;
            dataGridView1.DataSource = client.Plus_Mun50(dataGridView1.DataSource.ToString(), offset, Settings.Default["token"].ToString());
        }

        private void Mun50_Click(object sender, EventArgs e)
        {
            if (offset > 0)
                offset -= 50;
            dataGridView1.DataSource = client.Plus_Mun50(dataGridView1.DataSource.ToString(), offset, Settings.Default["token"].ToString());
        }
    }
}
