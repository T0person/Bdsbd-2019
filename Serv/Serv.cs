using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace Serv
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Serv" в коде и файле конфигурации.
    public class Serv : IServ
    {
        //int user_range = 0;
        MySqlConnection SqlConnection = new MySqlConnection("server=localhost; port=3306;username=User;password=T8J0TglfNkBuDLOV;database=kurs");
        //---Логин
        public string[] LoginForm(string login, string password)
        {
            SqlConnection.Open();
            string token;
            string[] str = new string[3];
            var role = '0';
            var rand = new Random();
            MySqlCommand command = new MySqlCommand("SELECT id FROM table1 WHERE email = @uL", SqlConnection);
            command.Parameters.AddWithValue("@uL", login);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string id = reader["id"].ToString();
                reader.Close();
                command = new MySqlCommand("SELECT id FROM people WHERE id = @id AND password = MD5(@uP)", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@uP", password);
                reader = command.ExecuteReader();
            }
            if (reader.Read())
            {
                using (SHA1 shaM = new SHA1Managed())
                {
                    byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(Convert.ToString(rand.Next(256))));
                    token = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                }
                string id = Convert.ToString(reader["id"]);
                reader.Close();
                var online = Insert_Online(id, token);
                if (online == '0')
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        str[i] = "0";
                    }
                    return str;
                }
                role = Choice_student(token);
                if (role == '0')
                    role = Choice_teacher(token);
                if (role == '0')
                    role = Choice_staff(token);
                if (role == '0')
                {
                    for(int i = 0; i < str.Length; i++)
                    {
                        str[i] = "-1";
                    }
                    return str;
                }
                str[0] = id;
                str[1] = token;
                str[2] = role.ToString();
                return str;
            }
            else
            {
                reader.Close();
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = "-1";
                }
                return str;
            }
        }

        //---Логин автоматом
        public char LoginForm_load(string token)
        {
            SqlConnection.Open();
            var id = Select_Online(token);
            if (id != null)
            {
                var role = Choice_student(token);
                if (role == '0')
                    role = Choice_teacher(token);
                if (role == '0')
                    role = Choice_staff(token);
                return role;
            }
            else
                return '0';
        }

        //---Поиск факультета
        public string Fac_find_stud(string token)
        {
            SqlConnection.Open();
            string id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT faculty_name FROM faculties WHERE id IN (SELECT id_faculty FROM students WHERE id = @id)", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var str = Convert.ToString(reader["faculty_name"]);
                    SqlConnection.Close();
                    reader.Close();
                    return str;
                }
                else
                {
                    SqlConnection.Close();
                    reader.Close();
                    return "Не нашло!";
                }
            }
            else
            {
                SqlConnection.Close();
                return "Ты не авторизирован";
            }
        }

        //---Поиск специальности
        public string Spec_find_stud(string token)
        {
            SqlConnection.Open();
            string id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT special_name FROM specials WHERE id IN (SELECT id_special FROM students WHERE id = @id)", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var str = Convert.ToString(reader["special_name"]);
                    SqlConnection.Close();
                    reader.Close();
                    return str;
                }
                else
                {
                    SqlConnection.Close();
                    reader.Close();
                    return "Не нашло!";
                }
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        //---Поиск зарплаты
        public string Sal_find_stud(string token)
        {
            SqlConnection.Open();
            string id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT salary FROM salary WHERE id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var str = Convert.ToString(reader["salary"]);
                    reader.Close();
                    SqlConnection.Close();
                    return str;
                }
                else
                {
                    SqlConnection.Close();
                    reader.Close();
                    return "Не нашло!";
                }
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        //---Получить таблицы
        public DataTable Take_table_people(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM people limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("people");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_students(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM students limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("students");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_teachers(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM teachers limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("teachers");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_staff(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM staff limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("staff");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_specials(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM specials limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("specials");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_faculties(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM faculties limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("faculties");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_salary(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM salary limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("salary");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_table1(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM table1 limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("table1");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_table2(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM table2 limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("table2");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        public DataTable Take_table_table3(string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM table3 limit 50", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable("table3");
                addapter.Fill(dt);
                SqlConnection.Close();
                return dt;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        //---Получить название строк
        public DataTable Take_rows_people()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE people", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("people");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_students()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE students", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("students");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_teachers()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE teachers", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("teachers");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_staff()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE staff", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("staff");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_specials()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE specials", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("specials");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_faculties()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE faculties", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("faculties");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_salary()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE salary", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("salary");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_table1()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE table1", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("table1");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_table2()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE table2", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("table2");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        public DataTable Take_rows_table3()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("DESCRIBE table3", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("table3");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        //---Изменить данные
        public char Update_table_people(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM people WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_people_id(set, where);
                            SqlConnection.Close();
                            return q;
                        case "password":
                            q = Update_people_password(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_people_fio(set, where);
                            SqlConnection.Close();
                            return q;

                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        public char Update_table_students(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM students WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_students_id(set, where);
                            SqlConnection.Close();
                            return q;
                        case "id_special":
                            q = Update_students_id_specials(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_students_id_faculties(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        public char Update_table_teachers(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM teachers WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_teachers_id(set, where);
                            SqlConnection.Close();
                            return q;
                        case "id_specials":
                            q = Update_teachers_id_specials(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_teachers_id_faculties(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        public char Update_table_staff(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM staff WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_staff_id(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_staff_job_name(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        public char Update_table_specials(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM specials WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_specials_id(set, where);
                            SqlConnection.Close();
                            return q;
                        case "special_name":
                            q = Update_specials_special_name(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_specials_special_director(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        public char Update_table_faculties(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM faculties WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_faculties_id(set, where);
                            SqlConnection.Close();
                            return q;
                        case "facilty_name":
                            q = Update_faculties_faculty_name(set, where);
                            SqlConnection.Close();
                            return q;
                        case "faculty_director":
                            q = Update_faculties_faculty_director(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_faculties_faculty_sub_director(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        public char Update_table_salary(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM salary WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_salary_id(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_salary_salary(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        public char Update_table_table1(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM table1 WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_table1_id(set, where);
                            SqlConnection.Close();
                            return q;
                        case "address":
                            q = Update_table1_address(set, where);
                            SqlConnection.Close();
                            return q;
                        case "email":
                            q = Update_table1_email(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_table1_registration(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }
        public char Update_table_table2(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM table2 WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_table2_id(set, where);
                            SqlConnection.Close();
                            return q;
                        case "b_date":
                            q = Update_table2_b_date(set, where);
                            SqlConnection.Close();
                            return q;
                        case "about":
                            q = Update_table2_about(set, where);
                            SqlConnection.Close();
                            return q;
                        case "phoneNumber":
                            q = Update_table2_phoneNumber(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_table2_company(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }
        public char Update_table_table3(string table, string name_set, string set, string where, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM table3 WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    char q;
                    switch (name_set)
                    {
                        case "id":
                            q = Update_table3_id(set, where);
                            SqlConnection.Close();
                            return q;
                        default:
                            q = Update_table3_card_number(set, where);
                            SqlConnection.Close();
                            return q;
                    }
                }
                SqlConnection.Close();
                return '0';
            }
            else
            {
                SqlConnection.Close();
                return '0';
            }
        }

        //---Удаление таблицы
        public string Delete_table(string token)
        {
            SqlConnection.Open();
            string id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM people WHERE id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command = new MySqlCommand("DELETE FROM people WHERE id = @id", SqlConnection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    Delete_Online(token);
                    return "1";
                }
                else
                {
                    return "-1";
                }
            }
            else
            {
                return null;
            }
        }

        //---Вся зарплата
        public string Top_Sal(string token)
        {
            SqlConnection.Open();
            if (token != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT salary FROM top_sal WHERE id = 1", SqlConnection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string kek = Convert.ToString(reader["salary"]);
                    SqlConnection.Close();
                    reader.Close();
                    return kek;
                }
                SqlConnection.Close();
                reader.Close();
                return null;
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        //---Выход при удалении
        public string Exit_to_del(string token)
        {
            SqlConnection.Open();
            string id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM people WHERE id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return "1";
                }
                else
                {
                    reader.Close();
                    return "Вы удалили себя!";
                }
            }
            else
            {
                return null;
            }
        }
        
        //---Плюс 50
        public DataTable Plus_Mun50(string table, int offset, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                switch (table)
                {
                    case "people":
                        return Roll_people(offset);
                    case "students":
                        return Roll_students(offset);
                    case "teachers":
                        return Roll_teachers(offset);
                    case "staff":
                        return Roll_staff(offset);
                    case "specials":
                        return Roll_specials(offset);
                    case "faculties":
                        return Roll_faculties(offset);
                    case "salary":
                        return Roll_salary(offset);
                    case "table1":
                        return Roll_table1(offset);
                    case "table2":
                        return Roll_table2(offset);
                    case "table3":
                        return Roll_table3(offset);
                    default:
                        return null;
                }
            }
            else
            {
                SqlConnection.Close();
                return null;
            }
        }

        //---Максимальная строка
        public int Count_table(string table, string token)
        {
            SqlConnection.Open();
            if (Select_Online(token) != null)
            {
                switch (table)
                {
                    case "people":
                        return Count_people();
                    case "students":
                        return Count_students();
                    case "teachers":
                        return Count_teachers();
                    case "staff":
                        return Count_staff();
                    case "specials":
                        return Count_specials();
                    case "faculties":
                        return Count_faculties();
                    case "salary":
                        return Count_salary();
                    case "table1":
                        return Count_table1();
                    case "table2":
                        return Count_table2();
                    case "table3":
                        return Count_table3();
                    default:
                        return -1;
                }
            }
            else
            {
                SqlConnection.Close();
                return -1;
            }
        }
        //---Онлайн
        private char Insert_Online(string id,string token)
        {
            if (Select_Online(token) == null)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO online VALUE(@id,@token)", SqlConnection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@token", token);
                    command.ExecuteNonQuery();
                    return '1';
                }
                catch (Exception)
                {
                    return '0';
                }
            }
            else
                return '0';
        }

        //---Офлайн
        public void Delete_Online(string token)
        {
            SqlConnection.Open();
            string id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM online where id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                SqlConnection.Close();
            }
        }

        //---Проверка онлайна
        private string Select_Online(string token)
        {
            MySqlCommand command = new MySqlCommand("SELECT id FROM online WHERE token = @token", SqlConnection);
            command.Parameters.AddWithValue("@token", token);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string read = reader["id"].ToString();
                reader.Close();
                return read;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        //---Выбор студента
        private char Choice_student(string token)
        {
            var id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM students WHERE id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return '1';
                }
                else
                {
                    reader.Close();
                    return '0';
                }
            }
            else
                return '0';
        }

        //---Выбор учителя
        private char Choice_teacher(string token)
        {
            var id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM teachers WHERE id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return '2';
                }
                else
                {
                    reader.Close();
                    return '0';
                }
            }
            else
                return '0';
        }

        //---Выбор персонала
        private char Choice_staff(string token)
        {
            var id = Select_Online(token);
            if (id != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT id FROM staff WHERE id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return '3';
                }
                else
                {
                    reader.Close();
                    return '0';
                }
            }
            else
                return '0';
        }

        //---Изменение id people
        private char Update_people_id (string set, string where)
        {
            using (SHA1 shaM = new SHA1Managed())
            {
                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
            }
            MySqlCommand command = new MySqlCommand("UPDATE people SET id  = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id students
        private char Update_students_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE students SET id  = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_students_id_specials(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE students SET id_special  = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_students_id_faculties(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE students SET id_faculty = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id teachers
        private char Update_teachers_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE teachers SET id  = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_teachers_id_specials(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE teachers SET id_special  = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_teachers_id_faculties(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE teachers SET id_faculty = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id staff
        private char Update_staff_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE staff SET id = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id specials
        private char Update_specials_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE specials SET id = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id faculties
        private char Update_faculties_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE faculties SET id = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id salary
        private char Update_salary_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE salary SET id = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id table1
        private char Update_table1_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table1 SET id = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id table2
        private char Update_table2_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table2 SET id = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение id table3
        private char Update_table3_id(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table3 SET id = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение password
        private char Update_people_password(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE people SET password = MD5(@set) WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого people
        private char Update_people_fio(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE people SET fio = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого staff
        private char Update_staff_job_name(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE staff SET job_name = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого specials
        private char Update_specials_special_name(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE specials SET special_name = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_specials_special_director(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE specials SET special_director = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого faculties
        private char Update_faculties_faculty_name(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE faculties SET faculty_name = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_faculties_faculty_director(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE faculties SET faculty_director = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_faculties_faculty_sub_director(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE faculties SET faculty_sub_director = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого salary
        private char Update_salary_salary(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE salary SET salary = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого salary
        private char Update_table1_address(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table1 SET address = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого table1
        private char Update_table1_email(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table1 SET email = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_table1_registration(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table1 SET registration = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого table2
        private char Update_table2_b_date(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table2 SET b_date = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_table2_about(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table2 SET about = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_table2_phoneNumber(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table2 SET phoneNumber = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        private char Update_table2_company(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table2 SET company = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Изменение простого table3
        private char Update_table3_card_number(string set, string where)
        {
            MySqlCommand command = new MySqlCommand("UPDATE table3 SET card_number = @set  WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@set", set);
            command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
            return '1';
        }

        //---Прокрутка таблиц
        private DataTable Roll_people(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM people limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("people");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_students(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM students limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("students");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_teachers(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM teachers limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("teachers");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_staff(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM staff limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("staff");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_specials(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM specials limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("specials");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_faculties(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM faculties limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("faculties");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_salary(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM salary limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("salary");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_table1(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM table1 limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("table1");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_table2(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM table2 limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("table2");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        private DataTable Roll_table3(int offset)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM table3 limit 50 offset @offset", SqlConnection);
            command.Parameters.AddWithValue("@offset", offset);
            command.ExecuteNonQuery();
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable("table3");
            addapter.Fill(dt);
            SqlConnection.Close();
            return dt;
        }

        //---Длина таблиц
        private int Count_people()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM people", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_students()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM students", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_teachers()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM teachers", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_staff()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM staff", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_specials()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM specials", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_faculties()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM faculties", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_salary()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM salary", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_table1()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM table1", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_table2()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM table2", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }

        private int Count_table3()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(0) FROM table3", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader["COUNT(0)"]);
                SqlConnection.Close();
                reader.Close();
                return count;
            }
            else
            {
                SqlConnection.Close();
                reader.Close();
                return 0;
            }
        }
    }
}