using Client.Properties;
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
    public partial class Create_people : Form
    {
        Serv.ServClient client = new Serv.ServClient("NetTcpBinding_IServ");
        string role;
        public Create_people()
        {
            InitializeComponent();
        }

        private void Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Role.SelectedItem.ToString())
            {
                case "Студент":
                    Spec_name.Text = "Специальность:";
                    Spec_name.Visible = true;
                    Spec_name_box.Visible = true;
                    Fac_name.Text = "Факультет:";
                    Fac_name.Visible = true;
                    Fac_name_box.Visible = true;
                    Salary.Text = "Стипендия:";
                    Salary.Visible = true;
                    Salary_box.Visible = true;
                    role = "students";
                    break;
                case "Учитель":
                    Spec_name.Text = "Специальность:";
                    Spec_name.Visible = true;
                    Spec_name_box.Visible = true;
                    Fac_name.Text = "Факультет:";
                    Fac_name.Visible = true;
                    Fac_name_box.Visible = true;
                    Salary.Text = "Стипендия:";
                    Salary.Visible = true;
                    Salary_box.Visible = true;
                    role = "teachers";
                    break;
                case "Персонал":
                    Fac_name.Visible = false;
                    Fac_name_box.Visible = false;
                    Spec_name.Text = "Работа:";
                    Spec_name.Visible = true;
                    Spec_name_box.Visible = true;
                    Salary.Text = "Зарплата:";
                    Salary.Visible = true;
                    Salary_box.Visible = true;
                    role = "staff";
                    break;
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string[] ids = new string[2];
            char q = '0';
            if (Fio_box != null && Login_box != null && Password_box != null && Address_box != null && Registration_box != null && About_box != null && Phone_box != null && Company_box != null && Card_box != null && B_date_box != null && Spec_name_box != null && Fac_name_box != null || Salary_box != null)
            {
                if (Login_box.Text.IndexOf("@") == -1 || Login_box.Text.IndexOf("@") != Login_box.Text.LastIndexOf("@"))
                    q = '1';
                else if (!DateTime.TryParseExact(Registration_box.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime formattedDate))
                    q = '1';
                else if (!DateTime.TryParseExact(B_date_box.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out formattedDate))
                    q = '1';
                else if (role == "students" || role == "teachers")
                {
                    ids = client.Analysis_spec_fac(Spec_name_box.Text, Fac_name_box.Text);
                    if (ids[0] == null && ids[1] == null)
                        q = '1';
                }
                else
                {
                    try
                    {
                        string pattern = @"(\d([(])\d{3}([)])\d{3}([-])\d{2}([-])\d{2})";
                        Regex regex = new Regex(pattern);
                        MatchCollection matchCollection = regex.Matches(Phone_box.Text);
                        var f = matchCollection[0].Value;
                    }
                    catch (Exception)
                    {
                        q = '1';
                    }
                    try
                    {
                        string pattern = @"(\d{4}([-])\d{4}([-])\d{4}([-])\d{4})";
                        Regex regex = new Regex(pattern);
                        MatchCollection matchCollection = regex.Matches(Card_box.Text);
                        var f = matchCollection[0].Value;
                    }
                    catch (Exception)
                    {
                        q = '1';
                    }
                    try
                    {
                        Convert.ToInt32(Salary_box.Text);
                    }
                    catch (Exception)
                    {
                        q = '1';
                    }
                }
                switch (q)
                {
                    case '0':
                        Settings.Default["created_id"] = Fio_box.Text + Address_box.Text;
                        Settings.Default["created_table"] = role;
                        Settings.Default.Save();
                        char q1 = client.Create_people(Fio_box.Text, Password_box.Text, Address_box.Text, Login_box.Text, Registration_box.Text, B_date_box.Text, About_box.Text, Phone_box.Text, Company_box.Text, Card_box.Text, role, ids[0], ids[1], Salary_box.Text, Settings.Default["token"].ToString());
                        switch (q1)
                        {
                            case '0':
                                MessageBox.Show("Ты не онлайн!");
                                break;
                            case '1':
                                MessageBox.Show("Такой пользователь уже есть!!!");
                                break;
                            case '2':
                                MessageBox.Show("Все прошло удачно!");
                                Create.Visible = false;
                                Settings.Default["created_id"] = null;
                                Settings.Default["created_table"] = null;
                                Settings.Default.Save();
                                break;

                        }
                        break;
                    case '1':
                        MessageBox.Show("Не правильно заполнены поля!");
                        break;
                }
            }
            else
                MessageBox.Show("Поля не заполнены!");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Hide();
            Staff nextform = new Staff();
            nextform.Show();
        }

        private void Spec_name_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
