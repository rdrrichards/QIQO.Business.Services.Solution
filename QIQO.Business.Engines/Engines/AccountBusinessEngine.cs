using QIQO.Data.Entities;
using QIQO.Business.Entities;
using System;
using QIQO.Data.Interfaces;
using System.ServiceModel;
using QIQO.Common.Core;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Business.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Engines
{
    public class AccountBusinessEngine : EngineBase, IAccountBusinessEngine
    {
        private readonly IAccountRepository _acct_repo; //
        private readonly IAccountEntityService _acct_es; //
        private readonly IAccountTypeBusinessEngine _account_type_be;
        private readonly IAddressBusinessEngine _address_be;
        private readonly IEntityAttributeBusinessEngine _entity_attribute_be;
        private readonly IFeeScheduleBusinessEngine _fee_schedule_be;
        private readonly IAccountEmployeeBusinessEngine _account_employee_be;
        private readonly IContactBusinessEngine _contact_be;
        private readonly ICommentBusinessEngine _comment_be;

        public AccountBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _acct_repo = _data_repository_factory.GetDataRepository<IAccountRepository>();
            _acct_es = _entity_service_factory.GetEntityService<IAccountEntityService>();
            _account_type_be = _business_engine_factory.GetBusinessEngine<IAccountTypeBusinessEngine>();
            _address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            _entity_attribute_be = _business_engine_factory.GetBusinessEngine<IEntityAttributeBusinessEngine>();
            _fee_schedule_be = _business_engine_factory.GetBusinessEngine<IFeeScheduleBusinessEngine>();
            _account_employee_be = _business_engine_factory.GetBusinessEngine<IAccountEmployeeBusinessEngine>();
            _contact_be = _business_engine_factory.GetBusinessEngine<IContactBusinessEngine>();
            _comment_be = _business_engine_factory.GetBusinessEngine<ICommentBusinessEngine>();
        }

        public bool AccountDelete(Account account)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var acct = _acct_es.Map(account);

                if (account.Addresses != null)
                {
                    Log.Info($"Account addresses to be deleted -> {account.Addresses.Count}");
                    foreach (Address address in account.Addresses)
                    {
                        try
                        {
                            bool ret_value = _address_be.AddressDelete(address);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error deleting account address data from the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.AccountAttributes != null)
                {
                    Log.Info($"Account attributes to be deleted -> {account.AccountAttributes.Count}");
                    foreach (EntityAttribute attribute in account.AccountAttributes)
                    {
                        try
                        {
                            bool ret_value = _entity_attribute_be.EntityAttributeDelete(attribute);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error deleting account attribute data from the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.FeeSchedules != null)
                {
                    Log.Info($"Account fee schedule to be deleted -> {account.FeeSchedules.Count}");
                    foreach (FeeSchedule fee_schedule in account.FeeSchedules)
                    {
                        try
                        {
                            bool ret_value = _fee_schedule_be.FeeScheduleDelete(fee_schedule);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error deleting account fee schedule data from the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.Employees != null)
                {
                    Log.Info($"Account employee(s) to be deleted -> {account.FeeSchedules.Count}");
                    foreach (AccountPerson employee in account.Employees)
                    {
                        try
                        {
                            bool ret_value = _account_employee_be.EmployeeDelete(account, employee);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error deleting account employee data from the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.Contacts != null)
                {
                    Log.Info($"Account contact(s) to be deleted -> {account.Contacts.Count}");
                    foreach (Contact contact in account.Contacts)
                    {
                        try
                        {
                            bool ret_value = _contact_be.ContactDelete(contact);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error deleting account contact data from the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.Comments != null)
                {
                    Log.Info($"Account comment(s) to be deleted -> {account.Comments.Count}");
                    foreach (var comment in account.Comments)
                    {
                        try
                        {
                            bool ret_value = _comment_be.CommentDelete(comment);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error deleting account comment data from the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                _acct_repo.Delete(acct);
                return true;
            });
        }

        public int AccountSave(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            return ExecuteFaultHandledOperation(() =>
            {
                var acct = _acct_es.Map(account);

                int account_key = _acct_repo.Insert(acct);

                if (account.Addresses != null)
                {
                    Log.Info($"Account addresses to be saved -> {account.Addresses.Count}");
                    foreach (Address address in account.Addresses)
                    {
                        try
                        {
                            address.EntityKey = account_key;
                            address.EntityType = QIQOEntityType.Account;
                            int addr_key = _address_be.AddressSave(address);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error saving account address data to the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.AccountAttributes != null)
                {
                    Log.Info($"Account attributes to be saved -> {account.AccountAttributes.Count}");
                    foreach (EntityAttribute attribute in account.AccountAttributes)
                    {
                        try
                        {
                            attribute.EntityKey = account_key;
                            attribute.EntityType = QIQOEntityType.Account;
                            int attr_key = _entity_attribute_be.EntityAttributeUpdate(attribute);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error saving account attribute data to the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.FeeSchedules != null)
                {
                    Log.Info("Account fee schedules to be saved -> {0}", account.FeeSchedules.Count);
                    foreach (FeeSchedule fee_schedule in account.FeeSchedules)
                    {
                        try
                        {
                            fee_schedule.AccountKey = account_key;
                            int fee_key = _fee_schedule_be.FeeScheduleSave(fee_schedule);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error saving account fee schedules data to the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.Employees != null)
                {
                    Log.Info($"Account employee(s) to be saved -> {account.Employees.Count}");
                    foreach (AccountPerson employee in account.Employees)
                    {
                        try
                        {
                            account.AccountKey = account_key;
                            int emp_key = _account_employee_be.EmployeeSave(account, employee, "Account Employee", "No comment");
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error saving account employee data to the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.Contacts != null)
                {
                    Log.Info($"Account contact(s) to be saved -> {account.Contacts.Count}");
                    foreach (Contact contact in account.Contacts)
                    {
                        try
                        {
                            contact.EntityKey = account_key;
                            int emp_key = _contact_be.ContactSave(contact);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error saving account contact data to the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                if (account.Comments != null)
                {
                    Log.Info($"Account Comment(s) start [{account.Comments.Count}] items to process");
                    foreach (var comment in account.Comments)
                    {
                        comment.EntityKey = account_key;
                        comment.EntityTypeKey = (int)QIQOEntityType.Account;

                        int comment_key = _comment_be.CommentSave(comment);
                        Log.Info($"Account Comment [{comment_key}] saved to the database sucessfully!");
                    }
                }

                return account_key;
            });
        }

        public List<Account> FindAccountsByCompany(Company company, string search_pattern)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var accounts = new List<Account>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };
                var accts = _acct_repo.FindAll(company.CompanyKey, search_pattern);

                foreach (AccountData acct in accts)
                {
                    var account = _acct_es.Map(acct);
                    account.AccountTypeData = GetAccountTypeData(acct.AccountTypeKey);
                    accounts.Add(account);
                }
                return accounts;
            });
        }

        public Account GetAccountByCode(string account_code, Company company)
        {
            return GetAccountByCode(account_code, company.CompanyCode);
        }

        public Account GetAccountByCode(string account_code, string company_code)
        {
            Log.Info("Accessing AccountBusinessEngine GetAccountByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                var acct_data = _acct_repo.GetByCode(account_code, company_code);
                Log.Info("AccountBusinessEngine GetAccountByCode function completed");

                if (acct_data.AccountKey != 0)
                {
                    var account = _acct_es.Map(acct_data);
                    
                    account.Addresses = GetAddresses(acct_data.AccountKey, QIQOEntityType.Account);
                    account.AccountAttributes = GetAttributes(acct_data.AccountKey, QIQOEntityType.Account);
                    account.FeeSchedules = GetFeeSchedules(account);
                    account.Employees = GetEmployees(account);
                    account.Contacts = GetContacts(acct_data.AccountKey, QIQOEntityType.Account);
                    account.AccountTypeData = GetAccountTypeData(acct_data.AccountTypeKey);
                    account.Comments = GetComments(acct_data.AccountKey, QIQOEntityType.Account);

                    return account;
                }
                else
                {
                    Log.Error($"AccountBusinessEngine Error: Unable to find account with code {account_code}");
                    NotFoundException ex = new NotFoundException($"Account with code {account_code} is not in database");
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public Account GetAccountByID(int account_key, bool full_load = false)
        {
            Log.Info("Accessing AccountBusinessEngine GetAccountByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var acct_data = _acct_repo.GetByID(account_key);
                Log.Info("AccountBusinessEngine GetByID function completed");

                if (acct_data.AccountKey != 0)
                {
                    var account = _acct_es.Map(acct_data);

                    if (full_load)
                    {
                        // Create repos or business engines and add to the account object
                        account.Addresses = GetAddresses(acct_data.AccountKey, QIQOEntityType.Account);
                        account.AccountAttributes = GetAttributes(acct_data.AccountKey, QIQOEntityType.Account);
                        account.FeeSchedules = GetFeeSchedules(account);
                        account.Employees = GetEmployees(account);
                        account.Contacts = GetContacts(acct_data.AccountKey, QIQOEntityType.Account);
                        account.AccountTypeData = GetAccountTypeData(acct_data.AccountTypeKey);
                        account.Comments = GetComments(acct_data.AccountKey, QIQOEntityType.Account);
                    }

                    return account;
                }
                else
                {
                    Log.Error($"AccountBusinessEngine Error: Unable to find account with key {account_key}");
                    NotFoundException ex = new NotFoundException($"Account with key {account_key} is not in database");
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<Account> GetAccountsByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var accounts = new List<Account>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };

                IEnumerable<AccountData> accts = _acct_repo.GetAll(comp);

                foreach (AccountData acct in accts)
                {
                    var account = _acct_es.Map(acct);

                    // Create repos or business engines and add to the account object
                    account.Addresses = GetAddresses(acct.AccountKey, QIQOEntityType.Account);
                    account.AccountAttributes = GetAttributes(acct.AccountKey, QIQOEntityType.Account);
                    account.FeeSchedules = GetFeeSchedules(account);
                    account.Employees = GetEmployees(account);
                    account.Contacts = GetContacts(acct.AccountKey, QIQOEntityType.Account);
                    account.AccountTypeData = GetAccountTypeData(acct.AccountTypeKey);
                    account.Comments = GetComments(acct.AccountKey, QIQOEntityType.Account);
                    accounts.Add(account);
                }
                return accounts;
            });
        }

        public List<Account> GetAccountsByRep(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return ExecuteFaultHandledOperation(() =>
            {
                var accounts = new List<Account>();
                var person = new PersonData() { PersonKey = employee.PersonKey };

                IEnumerable<AccountData> accts = _acct_repo.GetAll(person);

                foreach (AccountData acct in accts)
                {
                    var account = _acct_es.Map(acct);
                    account.Addresses = GetAddresses(acct.AccountKey, QIQOEntityType.Account);
                    account.AccountAttributes = GetAttributes(acct.AccountKey, QIQOEntityType.Account);
                    account.FeeSchedules = GetFeeSchedules(account);
                    account.Employees = GetEmployees(account);
                    account.Contacts = GetContacts(acct.AccountKey, QIQOEntityType.Account);
                    account.AccountTypeData = GetAccountTypeData(acct.AccountTypeKey);
                    account.Comments = GetComments(acct.AccountKey, QIQOEntityType.Account);
                    accounts.Add(account);
                }
                return accounts;
            });
        }

        public string GetNextEntityNumber(Account account, QIQOEntityNumberType num_type)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var acct = _acct_es.Map(account);

            return ExecuteFaultHandledOperation(() =>
            {
                return _acct_repo.GetNextNumber(acct, (int)num_type);
            });
        }

        private AccountType GetAccountTypeData(int account_type_key)
        {
            return _account_type_be.GetTypeByKey(account_type_key);
        }

        private List<Address> GetAddresses(int acct_key, QIQOEntityType type)
        {
            return _address_be.GetAddressesByEntityID(acct_key, type);
        }

        private List<EntityAttribute> GetAttributes(int acct_key, QIQOEntityType type)
        {
            return _entity_attribute_be.GetAttributeByEntity(acct_key, type);
        }

        private List<FeeSchedule> GetFeeSchedules(Account account)
        {
            return _fee_schedule_be.GetFeeSchedulesByAccount(account);
        }

        private List<AccountPerson> GetEmployees(Account account)
        {
            return _account_employee_be.GetEmployeeListByAccount(account);
        }

        private List<Contact> GetContacts(int acct_key, QIQOEntityType type)
        {
            return _contact_be.GetContactsByEntity(acct_key, type);
        }

        private List<Comment> GetComments(int acct_key, QIQOEntityType type)
        {
            return _comment_be.GetCommentsByEntity(acct_key, type);
        }
    }
}
