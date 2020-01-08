using Client.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Update : Form
    {
        Serv.ServClient client = new Serv.ServClient("NetTcpBinding_IServ");
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
            char q = '0';
            if (Set_id.Text == "" || Set_str.Text == "" || Table_box.SelectedItem == null || Row_box.SelectedItem == null)
            {
                MessageBox.Show("Поля не заполнены!");
            }
            else
            {
                switch (Table_box.SelectedItem.ToString())
                {
                    case "people":
                        q = client.Update_table_people(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "students":
                        q = client.Update_table_students(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "teachers":
                        q = client.Update_table_teachers(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "staff":
                        q = client.Update_table_staff(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "specials":
                        q = client.Update_table_specials(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "faculties":
                        q = client.Update_table_faculties(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "salary":
                        if (Row_box.SelectedItem.ToString() == "salary")
                        {
                            try
                            {
                                Convert.ToInt32(Set_str.Text);
                            }
                            catch (Exception)
                            {
                                q = '2';
                                break;
                            }
                        }
                        q = client.Update_table_salary(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "address":
                        if (Row_box.SelectedItem.ToString() == "email")
                        {
                            if (Set_str.Text.IndexOf("@") == -1 || Set_str.Text.IndexOf("@") != Set_str.Text.LastIndexOf("@"))
                            {
                                q = '2';
                                break;
                            }
                        }
                        else if (Row_box.SelectedItem.ToString() == "registration")
                        {
                            if (!DateTime.TryParseExact(Set_str.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime formattedDate))
                            {
                                q = '2';
                                break;
                            }
                        }
                        q = client.Update_table_address(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "company":
                        if (Row_box.SelectedItem.ToString() == "b_date")
                        {
                            if (!DateTime.TryParseExact(Set_str.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime formattedDate))
                            {
                                q = '2';
                                break;
                            }
                        }
                        q = client.Update_table_company(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                    case "card_number":
                        if(Row_box.SelectedItem.ToString() == "card_number")
                        {
                            try
                            {
                                string pattern = @"(\d{4}([-])\d{4}([-])\d{4}([-])\d{4})";
                                Regex regex = new Regex(pattern);
                                MatchCollection matchCollection = regex.Matches(Set_str.Text);
                                var f = matchCollection[0].Value;
                            }
                            catch (Exception)
                            {
                                q = '2';
                                break;
                            }
                        }
                        q = client.Update_table_card_number(Table_box.SelectedItem.ToString(), Row_box.SelectedItem.ToString(), Set_str.Text, Set_id.Text, Settings.Default["token"].ToString());
                        break;
                }
                switch (q)
                {
                    case '1':
                        MessageBox.Show("Все прошло удачно!");
                        break;
                    case '2':
                        MessageBox.Show("Не правильный формат!");
                        break;
                    default:
                        MessageBox.Show("Что-то не так!");
                        break;
                }
            }
        }

        private void Table_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Row_box.Items.Clear();
            switch (Table_box.SelectedItem.ToString())
            {
                case "people":
                    for (int i = 0; i < client.Take_rows_people().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_people().Rows[i][0].ToString());
                    }
                    break;
                case "students":
                    for (int i = 0; i < client.Take_rows_students().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_students().Rows[i][0].ToString());
                    }
                    break;
                case "teachers":
                    for (int i = 0; i < client.Take_rows_teachers().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_teachers().Rows[i][0].ToString());
                    }
                    break;
                case "staff":
                    for (int i = 0; i < client.Take_rows_staff().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_staff().Rows[i][0].ToString());
                    }
                    break;
                case "specials":
                    for (int i = 0; i < client.Take_rows_specials().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_specials().Rows[i][0].ToString());
                    }
                    break;
                case "faculties":
                    for (int i = 0; i < client.Take_rows_faculties().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_faculties().Rows[i][0].ToString());
                    }
                    break;
                case "salary":
                    for (int i = 0; i < client.Take_rows_salary().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_salary().Rows[i][0].ToString());
                    }
                    break;
                case "address":
                    for (int i = 0; i < client.Take_rows_address().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_address().Rows[i][0].ToString());
                    }
                    break;
                case "company":
                    for (int i = 0; i < client.Take_rows_company().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_company().Rows[i][0].ToString());
                    }
                    break;
                case "card_number":
                    for (int i = 0; i < client.Take_rows_card_number().Rows.Count; i++)
                    {
                        Row_box.Items.Add(client.Take_rows_card_number().Rows[i][0].ToString());
                    }
                    break;
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

        private void Set_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
