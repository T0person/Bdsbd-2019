using Client.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Staff : Form
    {
        int offset, max;
        Serv.ServClient client = new Serv.ServClient("NetTcpBinding_IServ");
        public Staff()
        {
            InitializeComponent();
        }

        private void All_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_people(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Students_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_students(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Teachers_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_teachers(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Staff_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_staff(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Fac_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_faculties(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Spec_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_specials(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Sal_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_salary(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
            Top_Sal.Text = "Монеток всего: " + client.Top_Sal(Settings.Default["token"].ToString());
            Top_Sal.Visible = true;
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            Hide();
            Update nextform = new Update();
            nextform.Show();
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            Hide();
            Delete nextform = new Delete();
            nextform.Show();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            client.Delete_Online(Settings.Default["token"].ToString());
            Settings.Default["id"] = null;
            Settings.Default["role"] = null;
            Settings.Default.Save();
            Application.Exit();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Staff_Load(object sender, EventArgs e)
        {

        }

        private void Mun50_Click(object sender, EventArgs e)
        {
            if(offset > 0)
                offset -= 50;
            dataGridView1.DataSource = client.Plus_Mun50(dataGridView1.DataSource.ToString(), offset, Settings.Default["token"].ToString());
        }

        private void Plus50_Click(object sender, EventArgs e)
        {
            offset += 50;
            if (offset > max)
                offset = max - offset;
            dataGridView1.DataSource = client.Plus_Mun50(dataGridView1.DataSource.ToString(), offset, Settings.Default["token"].ToString());
        }

        private void Address_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_address(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Company_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_company(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }

        private void Top_Sal_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MySqlConnection SqlConnection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=kurs");
            SqlConnection.Open();
            string id = "";
            string id_spec = "", id_fac = "";
            int refresh = 1, who = 1;
            int i = 1, j = 1;
            for (int i1 = 1; i1 <= 5000; i1++)
            {
                using (SHA1 shaM = new SHA1Managed())
                {
                    byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(i1.ToString() + ")"));
                    id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                }
                MySqlCommand faculties = new MySqlCommand("INSERT INTO faculties VALUE(@id,@f_name,@f_dir,@f_sub_dir)", SqlConnection);
                faculties.Parameters.AddWithValue("@id", id);
                faculties.Parameters.AddWithValue("@f_name", i1.ToString() + "_faculty");
                faculties.Parameters.AddWithValue("@f_dir", i1.ToString() + "_faculty_dir");
                faculties.Parameters.AddWithValue("@f_sub_dir", i1.ToString() + "_faculty_sub_dir");
                faculties.ExecuteNonQuery();
            }
            for (int i1 = 1; i1 <= 10000; i1++)
            {
                using (SHA1 shaM = new SHA1Managed())
                {
                    byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(i1.ToString() + "."));
                    id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                }
                MySqlCommand specials = new MySqlCommand("INSERT INTO specials VALUE(@id,@spec_name,@spec_dir)", SqlConnection);
                specials.Parameters.AddWithValue("@id", id);
                specials.Parameters.AddWithValue("@spec_name", i1.ToString() + "_spec_name");
                specials.Parameters.AddWithValue("@spec_dir", i1.ToString() + "_spec_dir");
                specials.ExecuteNonQuery();
            }
            StreamReader f1 = new StreamReader("table1");
            while (!f1.EndOfStream)
            {

                string s1 = f1.ReadLine();
                string[] words1 = s1.Split(new char[] { ',' });
                MySqlCommand people = new MySqlCommand("INSERT INTO people VALUE(@id,@fio,MD5(@password))", SqlConnection);
                using (SHA1 shaM = new SHA1Managed())
                {
                    byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(words1[0] + words1[1]));
                    byte[] hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(i.ToString() + "."));
                    byte[] hash1 = shaM.ComputeHash(Encoding.UTF8.GetBytes(j.ToString() + ")"));
                    id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                    id_spec = BitConverter.ToString(hash).Replace("-", "").ToLower();
                    id_fac = BitConverter.ToString(hash1).Replace("-", "").ToLower();
                }
                people.Parameters.AddWithValue("@id", id);
                people.Parameters.AddWithValue("@fio", words1[0]);
                people.Parameters.AddWithValue("@password", words1[3]);
                people.ExecuteNonQuery();
                if (who == 1)
                {
                    MySqlCommand students = new MySqlCommand("INSERT INTO students VALUE(@id,@id_spec,@id_fac)", SqlConnection);
                    students.Parameters.AddWithValue("@id", id);
                    students.Parameters.AddWithValue("@id_spec", id_spec);
                    students.Parameters.AddWithValue("@id_fac", id_fac);
                    students.ExecuteNonQuery();
                }
                else if (who == 2)
                {
                    MySqlCommand teachers = new MySqlCommand("INSERT INTO teachers VALUE(@id,@id_spec,@id_fac)", SqlConnection);
                    teachers.Parameters.AddWithValue("@id", id);
                    teachers.Parameters.AddWithValue("@id_spec", id_spec);
                    teachers.Parameters.AddWithValue("@id_fac", id_fac);
                    teachers.ExecuteNonQuery();
                }
                else if (who == 3)
                {
                    if (i == 10000)
                        i = 0;
                    if (j == 5000)
                        j = 0;
                    i++;
                    j++;
                    MySqlCommand staff = new MySqlCommand("INSERT INTO staff VALUE(@id,@job_name)", SqlConnection);
                    staff.Parameters.AddWithValue("@id", id);
                    staff.Parameters.AddWithValue("@job_name", refresh.ToString() + "_job_name");
                    staff.ExecuteNonQuery();
                    refresh++;
                }
                MySqlCommand address = new MySqlCommand("INSERT INTO address VALUE(@id,@address,@email,STR_TO_DATE(@registration,'%a %b %d %Y %T'))", SqlConnection);
                address.Parameters.AddWithValue("@id", id);
                address.Parameters.AddWithValue("@address", words1[1]);
                address.Parameters.AddWithValue("@email", words1[2]);
                address.Parameters.AddWithValue("@registration", words1[4]);
                address.ExecuteNonQuery();
                if (who == 3)
                    who = 1;
                else
                    who++;
            }
            StreamReader f2 = new StreamReader("table2");
            while (!f2.EndOfStream)
            {
                string s2 = f2.ReadLine();
                string[] words2 = s2.Split(new char[] { ',' });
                MySqlCommand company = new MySqlCommand("INSERT INTO company VALUE(@id,STR_TO_DATE(@b_data,'%a %b %d %Y %T'),@about,@phone,@company)", SqlConnection);
                using (SHA1 shaM = new SHA1Managed())
                {
                    byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(words2[0] + words2[1]));
                    id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                }
                company.Parameters.AddWithValue("@id", id);
                company.Parameters.AddWithValue("@b_data", words2[2]);
                company.Parameters.AddWithValue("@about", words2[3]);
                company.Parameters.AddWithValue("@phone", words2[4]);
                company.Parameters.AddWithValue("@company", words2[5]);
                company.ExecuteNonQuery();
            }
            StreamReader f3 = new StreamReader("table3");
            while (!f3.EndOfStream)
            {
                string s3 = f3.ReadLine();
                string[] words3 = s3.Split(new char[] { ',' });
                MySqlCommand card_number = new MySqlCommand("INSERT INTO card_number VALUE(@id,@card_number)", SqlConnection);
                MySqlCommand salary = new MySqlCommand("INSERT INTO salary VALUE(@id,@amount)", SqlConnection);
                using (SHA1 shaM = new SHA1Managed())
                {
                    byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(words3[0] + words3[1]));
                    id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                }
                card_number.Parameters.AddWithValue("@id", id);
                card_number.Parameters.AddWithValue("@card_number", words3[2]);
                card_number.ExecuteNonQuery();
                salary.Parameters.AddWithValue("@id", id);
                salary.Parameters.AddWithValue("@amount", words3[3]);
                salary.ExecuteNonQuery();
            }
            Application.Exit();

        }

        private void Card_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.Take_table_card_number(Settings.Default["token"].ToString());
            offset = 0;
            max = client.Count_table(dataGridView1.DataSource.ToString(), Settings.Default["token"].ToString());
        }
    }
}