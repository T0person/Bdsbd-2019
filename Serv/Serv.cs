using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        MySqlConnection SqlConnection = new MySqlConnection("server=localhost; port=3306;username=User;password=T8J0TglfNkBuDLOV;database=kurs");
        //---Логин
        public string LoginForm(string login, string password)
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("SELECT id FROM people WHERE fio = @uL AND password = MD5(@uP)", SqlConnection);
            command.Parameters.AddWithValue("@uL", login);
            command.Parameters.AddWithValue("@uP", password);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string id = Convert.ToString(reader["id"]);
                reader.Close();
                SqlConnection.Close();
                return id;
            }
            else
            {
                reader.Close();
                SqlConnection.Close();
                return "-1";
            }
        }

        //---Логин автоматом
        public char LoginForm_load(string id)
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("SELECT id FROM students WHERE id = @id", SqlConnection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                SqlConnection.Close();
                return '1';
            }
            reader.Close();
            command = new MySqlCommand("SELECT id FROM teachers WHERE id = @id", SqlConnection);
            command.Parameters.AddWithValue("@id", id);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                SqlConnection.Close();
                return '2';
            }
            reader.Close();
            command = new MySqlCommand("SELECT id FROM staff WHERE id = @id", SqlConnection);
            command.Parameters.AddWithValue("@id", id);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                SqlConnection.Close();
                return '3';
            }
            return '0';
        }

        //---Поиск факультета
        public string Fac_find_stud(string id, string token)
        {
            var select_online = Select_Online(token);
            if (select_online != null)
            {
                SqlConnection.Open();
                MySqlCommand command = new MySqlCommand("SELECT faculty_name FROM faculties WHERE id = @id", SqlConnection);
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
                return "Ты не авторизирован";
        }

        //---Поиск специальности
        public string Spec_find_stud(string id, string token)
        {
            var select_online = Select_Online(token);
            if (select_online != null)
            {
                SqlConnection.Open();
                MySqlCommand command = new MySqlCommand("SELECT special_name FROM specials WHERE id = @id", SqlConnection);
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
                return null;
        }

        //---Поиск зарплаты
        public string Sal_find_stud(string id, string token)
        {
            var select_online = Select_Online(token);
            if (select_online != null)
            {
                SqlConnection.Open();
                MySqlCommand command = new MySqlCommand("SELECT salary FROM salary WHERE id = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var str = Convert.ToString(reader["salary"]);
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
                return null;
        }

        //Получить таблицы
        public DataTable Take_table(string table, string token)
        {
            var select_online = Select_Online(token);
            if (select_online != null)
            {
                MySqlCommand command = null;
                if (table == "people")
                    command = new MySqlCommand("SELECT * FROM people", SqlConnection);
                else if (table == "students")
                    command = new MySqlCommand("SELECT * FROM students", SqlConnection);
                else if (table == "teachers")
                    command = new MySqlCommand("SELECT * FROM teachers", SqlConnection);
                else if (table == "staff")
                    command = new MySqlCommand("SELECT * FROM staff", SqlConnection);
                else if (table == "specials")
                    command = new MySqlCommand("SELECT * FROM specials", SqlConnection);
                else if (table == "faculties")
                    command = new MySqlCommand("SELECT * FROM faculties", SqlConnection);
                else if (table == "salary")
                    command = new MySqlCommand("SELECT * FROM salary", SqlConnection);
                MySqlDataAdapter addapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable(table);
                addapter.Fill(dt);
                return dt;
            }
            else
                return null;
        }

        //---Получить название строк
        public DataTable Take_rows(string table)
        {
            MySqlCommand command = null;
            if (table == "people")
                command = new MySqlCommand("DESCRIBE people", SqlConnection);
            else if (table == "students")
                command = new MySqlCommand("DESCRIBE students", SqlConnection);
            else if (table == "teachers")
                command = new MySqlCommand("DESCRIBE teachers", SqlConnection);
            else if (table == "staff")
                command = new MySqlCommand("DESCRIBE staff", SqlConnection);
            else if (table == "specials")
                command = new MySqlCommand("DESCRIBE specials", SqlConnection);
            else if (table == "faculties")
                command = new MySqlCommand("DESCRIBE faculties", SqlConnection);
            else if (table == "salary")
                command = new MySqlCommand("DESCRIBE salary", SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable(table);
            addapter.Fill(dt);
            return dt;
        }

        //---Изменить данные
        public string Update_table(string table, string name_set, string set, string where, string token)
        {
            var select_online = Select_Online(token);
            if (select_online != null)
            {
                MySqlCommand command = null;
                SqlConnection.Close();
                SqlConnection.Open();
                if (table == "people")
                    command = new MySqlCommand("SELECT id FROM people WHERE id = @where", SqlConnection);
                else if (table == "students")
                    command = new MySqlCommand("SELECT id FROM students WHERE id = @where", SqlConnection);
                else if (table == "teachers")
                    command = new MySqlCommand("SELECT id FROM teachers WHERE id = @where", SqlConnection);
                else if (table == "staff")
                    command = new MySqlCommand("SELECT id FROM staff WHERE id = @where", SqlConnection);
                else if (table == "specials")
                    command = new MySqlCommand("SELECT id FROM specials WHERE id = @where", SqlConnection);
                else if (table == "faculties")
                    command = new MySqlCommand("SELECT id FROM faculties WHERE id = @where", SqlConnection);
                else if (table == "salary")
                    command = new MySqlCommand("SELECT id FROM salary WHERE id = @where", SqlConnection);
                command.Parameters.AddWithValue("@where", where);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    if (table == "people")
                    {
                        if (name_set == "id")
                        {
                            using (SHA1 shaM = new SHA1Managed())
                            {
                                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                            }
                            command = new MySqlCommand("UPDATE people SET id  = @set  WHERE id = @where", SqlConnection);
                        }
                        else if (name_set == "fio")
                            command = new MySqlCommand("UPDATE people SET fio = @set  WHERE id = @where", SqlConnection);
                        else if (name_set == "password")
                            command = new MySqlCommand("UPDATE people SET password = MD5(@set) WHERE id = @where", SqlConnection);
                    }
                    else if (table == "students")
                    {
                        if (name_set == "id")
                        {
                            using (SHA1 shaM = new SHA1Managed())
                            {
                                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                            }
                            command = new MySqlCommand("UPDATE students SET id  = @set  WHERE id = @where", SqlConnection);
                        }
                    }
                    else if (table == "teachers")
                    {
                        if (name_set == "id")
                        {
                            using (SHA1 shaM = new SHA1Managed())
                            {
                                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                            }
                            command = new MySqlCommand("UPDATE teachers SET id  = @set  WHERE id = @where", SqlConnection);
                        }
                    }
                    else if (table == "staff")
                    {
                        if (name_set == "id")
                        {
                            using (SHA1 shaM = new SHA1Managed())
                            {
                                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                            }
                            command = new MySqlCommand("UPDATE staff SET id  = @set  WHERE id = @where", SqlConnection);
                        }
                        else if (name_set == "job_name")
                            command = new MySqlCommand("UPDATE staff SET job_name = @set  WHERE id = @where", SqlConnection);
                    }
                    else if (table == "specials")
                    {
                        if (name_set == "id")
                        {
                            using (SHA1 shaM = new SHA1Managed())
                            {
                                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                            }
                            command = new MySqlCommand("UPDATE specials SET id  = @set  WHERE id = @where", SqlConnection);
                        }
                        else if (name_set == "special_name")
                            command = new MySqlCommand("UPDATE specials SET job_name = @set  WHERE id= @where", SqlConnection);
                        else if (name_set == "special_director")
                            command = new MySqlCommand("UPDATE specials SET job_name = @set  WHERE id= @where", SqlConnection);
                    }
                    else if (table == "faculties")
                    {
                        if (name_set == "id")
                        {
                            using (SHA1 shaM = new SHA1Managed())
                            {
                                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                            }
                            command = new MySqlCommand("UPDATE faculties SET id  = @set  WHERE id = @where", SqlConnection);
                        }
                        else if (name_set == "faculty_name")
                            command = new MySqlCommand("UPDATE faculties SET faculty_name = @set  WHERE id= @where", SqlConnection);
                        else if (name_set == "faculty_director")
                            command = new MySqlCommand("UPDATE faculties SET faculty_director = @set  WHERE id= @where", SqlConnection);
                        else if (name_set == "faculty_sub_director")
                            command = new MySqlCommand("UPDATE faculties SET faculty_sub_director  = @set  WHERE id= @where", SqlConnection);
                    }
                    else if (table == "salary")
                    {
                        if (name_set == "id")
                        {
                            using (SHA1 shaM = new SHA1Managed())
                            {
                                byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                                set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                            }
                            command = new MySqlCommand("UPDATE salary SET id  = @set WHERE id = @where", SqlConnection);
                        }
                        else if (name_set == "salary")
                            command = new MySqlCommand("UPDATE salary SET salary = @set  WHERE id = @where", SqlConnection);
                    }
                    if (name_set == "salary")
                    {
                        command.Parameters.AddWithValue("@set", Convert.ToDecimal(set));
                        command.Parameters.AddWithValue("@where", where);
                        command.ExecuteNonQuery();
                    }
                    else if (name_set == "password")
                    {
                        command.Parameters.AddWithValue("@set", set);
                        command.Parameters.AddWithValue("@where", where);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@set", set);
                        command.Parameters.AddWithValue("@where", where);
                        command.ExecuteNonQuery();
                    }
                    SqlConnection.Close();
                    reader.Close();
                    return "1";
                }
                else
                {
                    SqlConnection.Close();
                    reader.Close();
                    return "-1";
                }
            }
            else
                return "Kek";
        }

        //---Удаление
        public string Delete_table(string id, string token)
        {
            var select_online = Select_Online(token);
            if (select_online != null)
            {
                SqlConnection.Open();
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
                    return "-1";
            }
            else
                return null;
        }

        //---Вся зарплата
        public string Top_Sal(string token)
        {
            var select_online = Select_Online(token);
            if (select_online != null)
            {
                SqlConnection.Open();
                MySqlCommand command = new MySqlCommand("SELECT salary FROM top_sal WHERE id = 1", SqlConnection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return Convert.ToString(reader["salary"]);
                return "sdgsd";
            }
            else
                return null;
        }

        //---Выход при удалении
        public string Exit_to_del(string id)
        {
            MySqlCommand command = new MySqlCommand("SELECT id FROM people WHERE id = @id", SqlConnection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return "1";
            else
                return ("Вы удалили себя!");
        }

        //---Онлайн
        public void Insert_Online(string id)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO online VALUE(@id)", SqlConnection);
            SqlConnection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        //---Офлайн
        public void Delete_Online(string id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM online where id = @id", SqlConnection);
            SqlConnection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        //---Проверка онлайна
        private string Select_Online(string id)
        {
            MySqlCommand command = new MySqlCommand("Select id from online where id = @id", SqlConnection);
            SqlConnection.Open();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return reader["id"].ToString();
            return null;
        }
    }
}
