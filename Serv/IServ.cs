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
        string LoginForm(string login, string password);
        [OperationContract]
        char LoginForm_load(string id);
        [OperationContract]
        string Fac_find_stud(string id);
        [OperationContract]
        string Spec_find_stud(string id);
        [OperationContract]
        string Sal_find_stud(string id);
        [OperationContract]
        DataTable Take_table(string table);
        [OperationContract]
        DataTable Take_rows(string table);
        [OperationContract]
        string Update_table(string table, string name_set, string set, string where);
        [OperationContract]
        string Delete_table(string id);
        [OperationContract]
        string Top_Sal();
        [OperationContract]
        string Exit_to_del(string id);
        [OperationContract]
        void Insert_Online(string id);
        [OperationContract]
        void Delete_Online(string id);
    }
}
