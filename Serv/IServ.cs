using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Serv
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServ" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServ
    {
        [OperationContract]
        string[] LoginForm(string login, string password);
        [OperationContract]
        char LoginForm_load(string token);
        [OperationContract]
        string Fac_find_stud(string token);
        [OperationContract]
        string Spec_find_stud(string token);
        [OperationContract]
        string Sal_find_stud(string token);
        [OperationContract]
        DataTable Take_rows_people();
        [OperationContract]
        DataTable Take_rows_students();
        [OperationContract]
        DataTable Take_rows_teachers();
        [OperationContract]
        DataTable Take_rows_staff();
        [OperationContract]
        DataTable Take_rows_specials();
        [OperationContract]
        DataTable Take_rows_faculties();
        [OperationContract]
        DataTable Take_rows_salary();
        [OperationContract]
        char Create_people(string fio, string password, string address, string email, string registration, string b_date, string about, string phone, string company, string card_number, string role, string spec_name, string fac_name, string salary, string token);
        [OperationContract]
        DataTable Take_rows_address();
        [OperationContract]
        DataTable Take_rows_company();
        [OperationContract]
        string[] Analysis_spec_fac(string name_spec, string name_fac);
        [OperationContract]
        void Find_Created(string id, string table);
        [OperationContract]
        DataTable Take_rows_card_number();
        [OperationContract]
        char Update_table_people(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_students(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_teachers(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_staff(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_specials(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_faculties(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_salary(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_address(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_company(string table, string name_set, string set, string where, string token);
        [OperationContract]
        char Update_table_card_number(string table, string name_set, string set, string where, string token);
        [OperationContract]
        string Delete_table(string token);
        [OperationContract]
        string Top_Sal(string token);
        [OperationContract]
        string Exit_to_del(string token);
        [OperationContract]
        void Delete_Online(string token);
        [OperationContract]
        DataTable Plus_Mun50(string table, int offset, string token);
        [OperationContract]
        int Count_table(string table, string token);
    }
}
