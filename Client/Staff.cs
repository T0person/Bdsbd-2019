﻿using Client.Properties;
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
        public Staff()
        {
            InitializeComponent();
        }

        private void All_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("people", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void Students_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("students", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void Teachers_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("teachers", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void Staff_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("staff", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void Fac_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("faculties", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void Spec_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("specials", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
        }

        private void Sal_button_Click(object sender, EventArgs e)
        {
            var client = new Serv.ServClient("NetTcpBinding_IServ");
            DataTable dt = client.Take_table("salary", Settings.Default["id"].ToString());
            dataGridView1.DataSource = dt;
            MessageBox.Show("Всего монеток" + client.Top_Sal(Settings.Default["id"].ToString()));
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

        private void Insert_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это сикретная функция, уди отсюда");
            //
            //Hide();
            //MySqlConnection SqlConnection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=kurs");
            //SqlConnection.Open();
            //string id = "";
            //string id_spec = "", id_fac = "";
            //int refresh = 1, who = 1;
            //int i = 1, j = 1;
            //for (int i1 = 1; i1 <= 5000; i1++)
            //{
            //    using (SHA1 shaM = new SHA1Managed())
            //    {
            //        byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(i1.ToString() + ")"));
            //        id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
            //    }
            //    MySqlCommand faculties = new MySqlCommand("INSERT INTO faculties VALUE(@id,@f_name,@f_dir,@f_sub_dir)", SqlConnection);
            //    faculties.Parameters.AddWithValue("@id", id);
            //    faculties.Parameters.AddWithValue("@f_name", i1.ToString() + "_faculty");
            //    faculties.Parameters.AddWithValue("@f_dir", i1.ToString() + "_faculty_dir");
            //    faculties.Parameters.AddWithValue("@f_sub_dir", i1.ToString() + "_faculty_sub_dir");
            //    faculties.ExecuteNonQuery();
            //}
            //for (int i1 = 1; i1 <= 10000; i1++)
            //{
            //    using (SHA1 shaM = new SHA1Managed())
            //    {
            //        byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(i1.ToString() + "."));
            //        id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
            //    }
            //    MySqlCommand specials = new MySqlCommand("INSERT INTO specials VALUE(@id,@spec_name,@spec_dir)", SqlConnection);
            //    specials.Parameters.AddWithValue("@id", id);
            //    specials.Parameters.AddWithValue("@spec_name", i1.ToString() + "_spec_name");
            //    specials.Parameters.AddWithValue("@spec_dir", i1.ToString() + "_spec_dir");
            //    specials.ExecuteNonQuery();
            //}
            //StreamReader f1 = new StreamReader("table1");
            //while (!f1.EndOfStream)
            //{
            //    SqlConnection.Close();
            //    string s1 = f1.ReadLine();
            //    string[] words1 = s1.Split(new char[] { ',' });
            //    MySqlCommand people = new MySqlCommand("INSERT INTO people VALUE(@id,@fio,MD5(@password))", SqlConnection);
            //    SqlConnection.Open();
            //    using (SHA1 shaM = new SHA1Managed())
            //    {
            //        byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(words1[0] + words1[1]));
            //        byte[] hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(i.ToString() + "."));
            //        byte[] hash1 = shaM.ComputeHash(Encoding.UTF8.GetBytes(j.ToString() + ")"));
            //        id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
            //        id_spec = BitConverter.ToString(hash).Replace("-", "").ToLower();
            //        id_fac = BitConverter.ToString(hash1).Replace("-", "").ToLower();
            //    }
            //    people.Parameters.AddWithValue("@id", id);
            //    people.Parameters.AddWithValue("@fio", words1[0]);
            //    people.Parameters.AddWithValue("@password", words1[3]);
            //    people.ExecuteNonQuery();
            //    if (who == 1)
            //    {
            //        MySqlCommand students = new MySqlCommand("INSERT INTO students VALUE(@id,@id_spec,@id_fac)", SqlConnection);
            //        students.Parameters.AddWithValue("@id", id);
            //        students.Parameters.AddWithValue("@id_spec", id_spec);
            //        students.Parameters.AddWithValue("@id_fac", id_fac);
            //        students.ExecuteNonQuery();
            //    }
            //    else if (who == 2)
            //    {
            //        MySqlCommand teachers = new MySqlCommand("INSERT INTO teachers VALUE(@id,@id_spec,@id_fac)", SqlConnection);
            //        teachers.Parameters.AddWithValue("@id", id);
            //        teachers.Parameters.AddWithValue("@id_spec", id_spec);
            //        teachers.Parameters.AddWithValue("@id_fac", id_fac);
            //        teachers.ExecuteNonQuery();
            //    }
            //    else if (who == 3)
            //    {
            //        if (i == 10000)
            //            i = 0;
            //        if (j == 5000)
            //            j = 0;
            //        i++;
            //        j++;
            //        MySqlCommand staff = new MySqlCommand("INSERT INTO staff VALUE(@id,@job_name)", SqlConnection);
            //        staff.Parameters.AddWithValue("@id", id);
            //        staff.Parameters.AddWithValue("@job_name", refresh.ToString() + "_job_name");
            //        staff.ExecuteNonQuery();
            //        refresh++;
            //    }
            //    MySqlCommand table1 = new MySqlCommand("INSERT INTO table1 VALUE(@id,@address,@email,STR_TO_DATE(@registration,'%a %b %d %Y %T'))", SqlConnection);
            //    table1.Parameters.AddWithValue("@id", id);
            //    table1.Parameters.AddWithValue("@address", words1[1]);
            //    table1.Parameters.AddWithValue("@email", words1[2]);
            //    table1.Parameters.AddWithValue("@registration", words1[4]);
            //    table1.ExecuteNonQuery();
            //    if (who == 3)
            //        who = 1;
            //    else
            //        who++;
            //}
            //StreamReader f2 = new StreamReader("table2");
            //while (!f2.EndOfStream)
            //{
            //    string s2 = f2.ReadLine();
            //    string[] words2 = s2.Split(new char[] { ',' });
            //    MySqlCommand table2 = new MySqlCommand("INSERT INTO table2 VALUE(@id,STR_TO_DATE(@b_data,'%a %b %d %Y %T'),@about,@phone,@company)", SqlConnection);
            //    using (SHA1 shaM = new SHA1Managed())
            //    {
            //        byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(words2[0] + words2[1]));
            //        id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
            //    }
            //    table2.Parameters.AddWithValue("@id", id);
            //    table2.Parameters.AddWithValue("@b_data", words2[2]);
            //    table2.Parameters.AddWithValue("@about", words2[3]);
            //    table2.Parameters.AddWithValue("@phone", words2[4]);
            //    table2.Parameters.AddWithValue("@company", words2[5]);
            //    table2.ExecuteNonQuery();

            //}
            //StreamReader f3 = new StreamReader("table3");
            //while (!f3.EndOfStream)
            //{
            //    string s3 = f3.ReadLine();
            //    string[] words3 = s3.Split(new char[] { ',' });
            //    MySqlCommand table3 = new MySqlCommand("INSERT INTO table3 VALUE(@id,@card_number)", SqlConnection);
            //    MySqlCommand salary = new MySqlCommand("INSERT INTO salary VALUE(@id,@amount)", SqlConnection);
            //    using (SHA1 shaM = new SHA1Managed())
            //    {
            //        byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(words3[0] + words3[1]));
            //        id = BitConverter.ToString(hash2).Replace("-", "").ToLower();
            //    }
            //    table3.Parameters.AddWithValue("@id", id);
            //    table3.Parameters.AddWithValue("@card_number", words3[2]);
            //    table3.ExecuteNonQuery();

            //    salary.Parameters.AddWithValue("@id", id);
            //    salary.Parameters.AddWithValue("@amount", words3[3]);
            //    salary.ExecuteNonQuery();
            //}
            //Application.Exit();
            //
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

        private void Staff_Load(object sender, EventArgs e)
        {

        }
    }
}
