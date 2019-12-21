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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            Hide();
            Staff nextform = new Staff();
            nextform.Show();
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            if (Set_id.Text == "" || Set_str.Text == "" || Table_box.SelectedItem == null || Row_box.SelectedItem == null)
            {
                MessageBox.Show("Поля не заполнены!");
            }
            if (Row_box.SelectedItem.ToString() == "salary")
            {
                try
                {
                    Convert.ToInt32(Set_str.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Вы вводите не тот тип!");
                } 
            }
            else
            {
                string str = client.Update_table(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["id"].ToString()).ToString();
                if (str == "1")
                {
                    MessageBox.Show("Все прошло удачно!");
                }

                else
                    MessageBox.Show("Что-то не так!");

            }
        }

        private void Table_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Row_box.Items.Clear();
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            for (int i = 0; i < client.Take_rows(Table_box.SelectedItem.ToString()).Rows.Count; i++)
            {
                Row_box.Items.Add(client.Take_rows(Table_box.SelectedItem.ToString()).Rows[i][0].ToString());
            }
        }

        private void Row_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void Set_str_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
