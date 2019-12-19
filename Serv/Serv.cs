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
        public string Fac_find_stud(string id)
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

        //---Поиск специальности
        public string Spec_find_stud(string id)
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

        //---Поиск зарплаты
        public string Sal_find_stud(string id)
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

        //Получить таблицы
        public DataTable Take_table(string table)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM " + table, SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable(table);
            addapter.Fill(dt);
            return dt;
        }

        //---Получить название строк
        public DataTable Take_rows(string table)
        {
            MySqlCommand command = new MySqlCommand("DESCRIBE " + table, SqlConnection);
            MySqlDataAdapter addapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable(table);
            addapter.Fill(dt);
            return dt;
        }

        //---Изменить данные
        public string Update_table(string table, string name_set, string set, string where)
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("SELECT id FROM " + table + " WHERE id = @where", SqlConnection);
            command.Parameters.AddWithValue("@where", where);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                if (name_set == "id")
                {
                    using (SHA1 shaM = new SHA1Managed())
                    {
                        byte[] hash2 = shaM.ComputeHash(Encoding.UTF8.GetBytes(set));
                        set = BitConverter.ToString(hash2).Replace("-", "").ToLower();
                    }
                    command = new MySqlCommand("UPDATE " + table + " SET " + name_set + " = @set WHERE id = @where", SqlConnection);
                    command.Parameters.AddWithValue("@set", set);
                    command.Parameters.AddWithValue("@where", where);
                    command.ExecuteNonQuery();
                }
                if(name_set == "salary")
                {
                    command = new MySqlCommand("UPDATE " + table + " SET " + name_set + " = " + set + " WHERE id = @where", SqlConnection);
                    command.Parameters.AddWithValue("@set", set);
                    command.Parameters.AddWithValue("@where", where);
                    command.ExecuteNonQuery();
                }
                else if (name_set == "password")
                {
                    command = new MySqlCommand("UPDATE " + table + " SET " + name_set + " = MD5(@set) WHERE id = @where", SqlConnection);
                    command.Parameters.AddWithValue("@set", set);
                    command.Parameters.AddWithValue("@where", where);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command = new MySqlCommand("UPDATE " + table + " SET " + name_set + " = @set WHERE id = @where", SqlConnection);
                    command.Parameters.AddWithValue("@set", set);
                    command.Parameters.AddWithValue("@where", where);
                    command.ExecuteNonQuery();
                }
                command.ExecuteNonQuery();
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

        //---Удаление
        public string Delete_table(string id)
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
                return "1";
            }
            else
                return "-1";
        }

        //---Вся зарплата
        public string Top_Sal()
        {
            SqlConnection.Open();
            MySqlCommand command = new MySqlCommand("SELECT salary FROM top_sal WHERE id = 1", SqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return Convert.ToString(reader["salary"]);
            return "sdgsd";
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
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        //---Офлайн
        public void Delete_Online(string id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM online where id = @id", SqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
