﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Serv {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Serv.IServ")]
    public interface IServ {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/LoginForm", ReplyAction="http://tempuri.org/IServ/LoginFormResponse")]
        string[] LoginForm(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/LoginForm", ReplyAction="http://tempuri.org/IServ/LoginFormResponse")]
        System.Threading.Tasks.Task<string[]> LoginFormAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/LoginForm_load", ReplyAction="http://tempuri.org/IServ/LoginForm_loadResponse")]
        char LoginForm_load(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/LoginForm_load", ReplyAction="http://tempuri.org/IServ/LoginForm_loadResponse")]
        System.Threading.Tasks.Task<char> LoginForm_loadAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Fac_find_stud", ReplyAction="http://tempuri.org/IServ/Fac_find_studResponse")]
        string Fac_find_stud(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Fac_find_stud", ReplyAction="http://tempuri.org/IServ/Fac_find_studResponse")]
        System.Threading.Tasks.Task<string> Fac_find_studAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Spec_find_stud", ReplyAction="http://tempuri.org/IServ/Spec_find_studResponse")]
        string Spec_find_stud(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Spec_find_stud", ReplyAction="http://tempuri.org/IServ/Spec_find_studResponse")]
        System.Threading.Tasks.Task<string> Spec_find_studAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Sal_find_stud", ReplyAction="http://tempuri.org/IServ/Sal_find_studResponse")]
        string Sal_find_stud(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Sal_find_stud", ReplyAction="http://tempuri.org/IServ/Sal_find_studResponse")]
        System.Threading.Tasks.Task<string> Sal_find_studAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_people", ReplyAction="http://tempuri.org/IServ/Take_rows_peopleResponse")]
        System.Data.DataTable Take_rows_people();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_people", ReplyAction="http://tempuri.org/IServ/Take_rows_peopleResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_peopleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_students", ReplyAction="http://tempuri.org/IServ/Take_rows_studentsResponse")]
        System.Data.DataTable Take_rows_students();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_students", ReplyAction="http://tempuri.org/IServ/Take_rows_studentsResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_studentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_teachers", ReplyAction="http://tempuri.org/IServ/Take_rows_teachersResponse")]
        System.Data.DataTable Take_rows_teachers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_teachers", ReplyAction="http://tempuri.org/IServ/Take_rows_teachersResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_teachersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_staff", ReplyAction="http://tempuri.org/IServ/Take_rows_staffResponse")]
        System.Data.DataTable Take_rows_staff();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_staff", ReplyAction="http://tempuri.org/IServ/Take_rows_staffResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_staffAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_specials", ReplyAction="http://tempuri.org/IServ/Take_rows_specialsResponse")]
        System.Data.DataTable Take_rows_specials();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_specials", ReplyAction="http://tempuri.org/IServ/Take_rows_specialsResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_specialsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_faculties", ReplyAction="http://tempuri.org/IServ/Take_rows_facultiesResponse")]
        System.Data.DataTable Take_rows_faculties();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_faculties", ReplyAction="http://tempuri.org/IServ/Take_rows_facultiesResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_facultiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_salary", ReplyAction="http://tempuri.org/IServ/Take_rows_salaryResponse")]
        System.Data.DataTable Take_rows_salary();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_salary", ReplyAction="http://tempuri.org/IServ/Take_rows_salaryResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_salaryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Create_people", ReplyAction="http://tempuri.org/IServ/Create_peopleResponse")]
        char Create_people(string fio, string password, string address, string email, string registration, string b_date, string about, string phone, string company, string card_number, string role, string spec_name, string fac_name, string salary, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Create_people", ReplyAction="http://tempuri.org/IServ/Create_peopleResponse")]
        System.Threading.Tasks.Task<char> Create_peopleAsync(string fio, string password, string address, string email, string registration, string b_date, string about, string phone, string company, string card_number, string role, string spec_name, string fac_name, string salary, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_address", ReplyAction="http://tempuri.org/IServ/Take_rows_addressResponse")]
        System.Data.DataTable Take_rows_address();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_address", ReplyAction="http://tempuri.org/IServ/Take_rows_addressResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_addressAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_company", ReplyAction="http://tempuri.org/IServ/Take_rows_companyResponse")]
        System.Data.DataTable Take_rows_company();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_company", ReplyAction="http://tempuri.org/IServ/Take_rows_companyResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_companyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Analysis_spec_fac", ReplyAction="http://tempuri.org/IServ/Analysis_spec_facResponse")]
        string[] Analysis_spec_fac(string name_spec, string name_fac);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Analysis_spec_fac", ReplyAction="http://tempuri.org/IServ/Analysis_spec_facResponse")]
        System.Threading.Tasks.Task<string[]> Analysis_spec_facAsync(string name_spec, string name_fac);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Find_Created", ReplyAction="http://tempuri.org/IServ/Find_CreatedResponse")]
        void Find_Created(string id, string table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Find_Created", ReplyAction="http://tempuri.org/IServ/Find_CreatedResponse")]
        System.Threading.Tasks.Task Find_CreatedAsync(string id, string table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_card_number", ReplyAction="http://tempuri.org/IServ/Take_rows_card_numberResponse")]
        System.Data.DataTable Take_rows_card_number();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Take_rows_card_number", ReplyAction="http://tempuri.org/IServ/Take_rows_card_numberResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_card_numberAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_people", ReplyAction="http://tempuri.org/IServ/Update_table_peopleResponse")]
        char Update_table_people(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_people", ReplyAction="http://tempuri.org/IServ/Update_table_peopleResponse")]
        System.Threading.Tasks.Task<char> Update_table_peopleAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_students", ReplyAction="http://tempuri.org/IServ/Update_table_studentsResponse")]
        char Update_table_students(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_students", ReplyAction="http://tempuri.org/IServ/Update_table_studentsResponse")]
        System.Threading.Tasks.Task<char> Update_table_studentsAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_teachers", ReplyAction="http://tempuri.org/IServ/Update_table_teachersResponse")]
        char Update_table_teachers(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_teachers", ReplyAction="http://tempuri.org/IServ/Update_table_teachersResponse")]
        System.Threading.Tasks.Task<char> Update_table_teachersAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_staff", ReplyAction="http://tempuri.org/IServ/Update_table_staffResponse")]
        char Update_table_staff(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_staff", ReplyAction="http://tempuri.org/IServ/Update_table_staffResponse")]
        System.Threading.Tasks.Task<char> Update_table_staffAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_specials", ReplyAction="http://tempuri.org/IServ/Update_table_specialsResponse")]
        char Update_table_specials(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_specials", ReplyAction="http://tempuri.org/IServ/Update_table_specialsResponse")]
        System.Threading.Tasks.Task<char> Update_table_specialsAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_faculties", ReplyAction="http://tempuri.org/IServ/Update_table_facultiesResponse")]
        char Update_table_faculties(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_faculties", ReplyAction="http://tempuri.org/IServ/Update_table_facultiesResponse")]
        System.Threading.Tasks.Task<char> Update_table_facultiesAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_salary", ReplyAction="http://tempuri.org/IServ/Update_table_salaryResponse")]
        char Update_table_salary(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_salary", ReplyAction="http://tempuri.org/IServ/Update_table_salaryResponse")]
        System.Threading.Tasks.Task<char> Update_table_salaryAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_address", ReplyAction="http://tempuri.org/IServ/Update_table_addressResponse")]
        char Update_table_address(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_address", ReplyAction="http://tempuri.org/IServ/Update_table_addressResponse")]
        System.Threading.Tasks.Task<char> Update_table_addressAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_company", ReplyAction="http://tempuri.org/IServ/Update_table_companyResponse")]
        char Update_table_company(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_company", ReplyAction="http://tempuri.org/IServ/Update_table_companyResponse")]
        System.Threading.Tasks.Task<char> Update_table_companyAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_card_number", ReplyAction="http://tempuri.org/IServ/Update_table_card_numberResponse")]
        char Update_table_card_number(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Update_table_card_number", ReplyAction="http://tempuri.org/IServ/Update_table_card_numberResponse")]
        System.Threading.Tasks.Task<char> Update_table_card_numberAsync(string table, string name_set, string set, string where, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Delete_table", ReplyAction="http://tempuri.org/IServ/Delete_tableResponse")]
        string Delete_table(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Delete_table", ReplyAction="http://tempuri.org/IServ/Delete_tableResponse")]
        System.Threading.Tasks.Task<string> Delete_tableAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Top_Sal", ReplyAction="http://tempuri.org/IServ/Top_SalResponse")]
        string Top_Sal(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Top_Sal", ReplyAction="http://tempuri.org/IServ/Top_SalResponse")]
        System.Threading.Tasks.Task<string> Top_SalAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Exit_to_del", ReplyAction="http://tempuri.org/IServ/Exit_to_delResponse")]
        string Exit_to_del(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Exit_to_del", ReplyAction="http://tempuri.org/IServ/Exit_to_delResponse")]
        System.Threading.Tasks.Task<string> Exit_to_delAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Delete_Online", ReplyAction="http://tempuri.org/IServ/Delete_OnlineResponse")]
        void Delete_Online(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Delete_Online", ReplyAction="http://tempuri.org/IServ/Delete_OnlineResponse")]
        System.Threading.Tasks.Task Delete_OnlineAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Plus_Mun50", ReplyAction="http://tempuri.org/IServ/Plus_Mun50Response")]
        System.Data.DataTable Plus_Mun50(string table, int offset, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Plus_Mun50", ReplyAction="http://tempuri.org/IServ/Plus_Mun50Response")]
        System.Threading.Tasks.Task<System.Data.DataTable> Plus_Mun50Async(string table, int offset, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Count_table", ReplyAction="http://tempuri.org/IServ/Count_tableResponse")]
        int Count_table(string table, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServ/Count_table", ReplyAction="http://tempuri.org/IServ/Count_tableResponse")]
        System.Threading.Tasks.Task<int> Count_tableAsync(string table, string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServChannel : Client.Serv.IServ, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServClient : System.ServiceModel.ClientBase<Client.Serv.IServ>, Client.Serv.IServ {
        
        public ServClient() {
        }
        
        public ServClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] LoginForm(string login, string password) {
            return base.Channel.LoginForm(login, password);
        }
        
        public System.Threading.Tasks.Task<string[]> LoginFormAsync(string login, string password) {
            return base.Channel.LoginFormAsync(login, password);
        }
        
        public char LoginForm_load(string token) {
            return base.Channel.LoginForm_load(token);
        }
        
        public System.Threading.Tasks.Task<char> LoginForm_loadAsync(string token) {
            return base.Channel.LoginForm_loadAsync(token);
        }
        
        public string Fac_find_stud(string token) {
            return base.Channel.Fac_find_stud(token);
        }
        
        public System.Threading.Tasks.Task<string> Fac_find_studAsync(string token) {
            return base.Channel.Fac_find_studAsync(token);
        }
        
        public string Spec_find_stud(string token) {
            return base.Channel.Spec_find_stud(token);
        }
        
        public System.Threading.Tasks.Task<string> Spec_find_studAsync(string token) {
            return base.Channel.Spec_find_studAsync(token);
        }
        
        public string Sal_find_stud(string token) {
            return base.Channel.Sal_find_stud(token);
        }
        
        public System.Threading.Tasks.Task<string> Sal_find_studAsync(string token) {
            return base.Channel.Sal_find_studAsync(token);
        }
        
        public System.Data.DataTable Take_rows_people() {
            return base.Channel.Take_rows_people();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_peopleAsync() {
            return base.Channel.Take_rows_peopleAsync();
        }
        
        public System.Data.DataTable Take_rows_students() {
            return base.Channel.Take_rows_students();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_studentsAsync() {
            return base.Channel.Take_rows_studentsAsync();
        }
        
        public System.Data.DataTable Take_rows_teachers() {
            return base.Channel.Take_rows_teachers();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_teachersAsync() {
            return base.Channel.Take_rows_teachersAsync();
        }
        
        public System.Data.DataTable Take_rows_staff() {
            return base.Channel.Take_rows_staff();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_staffAsync() {
            return base.Channel.Take_rows_staffAsync();
        }
        
        public System.Data.DataTable Take_rows_specials() {
            return base.Channel.Take_rows_specials();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_specialsAsync() {
            return base.Channel.Take_rows_specialsAsync();
        }
        
        public System.Data.DataTable Take_rows_faculties() {
            return base.Channel.Take_rows_faculties();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_facultiesAsync() {
            return base.Channel.Take_rows_facultiesAsync();
        }
        
        public System.Data.DataTable Take_rows_salary() {
            return base.Channel.Take_rows_salary();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_salaryAsync() {
            return base.Channel.Take_rows_salaryAsync();
        }
        
        public char Create_people(string fio, string password, string address, string email, string registration, string b_date, string about, string phone, string company, string card_number, string role, string spec_name, string fac_name, string salary, string token) {
            return base.Channel.Create_people(fio, password, address, email, registration, b_date, about, phone, company, card_number, role, spec_name, fac_name, salary, token);
        }
        
        public System.Threading.Tasks.Task<char> Create_peopleAsync(string fio, string password, string address, string email, string registration, string b_date, string about, string phone, string company, string card_number, string role, string spec_name, string fac_name, string salary, string token) {
            return base.Channel.Create_peopleAsync(fio, password, address, email, registration, b_date, about, phone, company, card_number, role, spec_name, fac_name, salary, token);
        }
        
        public System.Data.DataTable Take_rows_address() {
            return base.Channel.Take_rows_address();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_addressAsync() {
            return base.Channel.Take_rows_addressAsync();
        }
        
        public System.Data.DataTable Take_rows_company() {
            return base.Channel.Take_rows_company();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_companyAsync() {
            return base.Channel.Take_rows_companyAsync();
        }
        
        public string[] Analysis_spec_fac(string name_spec, string name_fac) {
            return base.Channel.Analysis_spec_fac(name_spec, name_fac);
        }
        
        public System.Threading.Tasks.Task<string[]> Analysis_spec_facAsync(string name_spec, string name_fac) {
            return base.Channel.Analysis_spec_facAsync(name_spec, name_fac);
        }
        
        public void Find_Created(string id, string table) {
            base.Channel.Find_Created(id, table);
        }
        
        public System.Threading.Tasks.Task Find_CreatedAsync(string id, string table) {
            return base.Channel.Find_CreatedAsync(id, table);
        }
        
        public System.Data.DataTable Take_rows_card_number() {
            return base.Channel.Take_rows_card_number();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Take_rows_card_numberAsync() {
            return base.Channel.Take_rows_card_numberAsync();
        }
        
        public char Update_table_people(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_people(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_peopleAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_peopleAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_students(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_students(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_studentsAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_studentsAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_teachers(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_teachers(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_teachersAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_teachersAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_staff(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_staff(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_staffAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_staffAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_specials(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_specials(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_specialsAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_specialsAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_faculties(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_faculties(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_facultiesAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_facultiesAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_salary(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_salary(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_salaryAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_salaryAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_address(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_address(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_addressAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_addressAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_company(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_company(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_companyAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_companyAsync(table, name_set, set, where, token);
        }
        
        public char Update_table_card_number(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_card_number(table, name_set, set, where, token);
        }
        
        public System.Threading.Tasks.Task<char> Update_table_card_numberAsync(string table, string name_set, string set, string where, string token) {
            return base.Channel.Update_table_card_numberAsync(table, name_set, set, where, token);
        }
        
        public string Delete_table(string token) {
            return base.Channel.Delete_table(token);
        }
        
        public System.Threading.Tasks.Task<string> Delete_tableAsync(string token) {
            return base.Channel.Delete_tableAsync(token);
        }
        
        public string Top_Sal(string token) {
            return base.Channel.Top_Sal(token);
        }
        
        public System.Threading.Tasks.Task<string> Top_SalAsync(string token) {
            return base.Channel.Top_SalAsync(token);
        }
        
        public string Exit_to_del(string token) {
            return base.Channel.Exit_to_del(token);
        }
        
        public System.Threading.Tasks.Task<string> Exit_to_delAsync(string token) {
            return base.Channel.Exit_to_delAsync(token);
        }
        
        public void Delete_Online(string token) {
            base.Channel.Delete_Online(token);
        }
        
        public System.Threading.Tasks.Task Delete_OnlineAsync(string token) {
            return base.Channel.Delete_OnlineAsync(token);
        }
        
        public System.Data.DataTable Plus_Mun50(string table, int offset, string token) {
            return base.Channel.Plus_Mun50(table, offset, token);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> Plus_Mun50Async(string table, int offset, string token) {
            return base.Channel.Plus_Mun50Async(table, offset, token);
        }
        
        public int Count_table(string table, string token) {
            return base.Channel.Count_table(table, token);
        }
        
        public System.Threading.Tasks.Task<int> Count_tableAsync(string table, string token) {
            return base.Channel.Count_tableAsync(table, token);
        }
    }
}
