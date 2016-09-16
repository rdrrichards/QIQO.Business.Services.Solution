using QIQO.Data.Entities;
using QIQO.Business.Entities;
using System;
using QIQO.Data.Interfaces;
using QIQO.Common.Contracts;
using QIQO.Business.Contracts;
using System.Collections.Generic;
using QIQO.Common.Core.Logging;

namespace QIQO.Business.Engines
{
    public class AccountEmployeeBusinessEngine : EngineBase, IAccountEmployeeBusinessEngine
    {
        private readonly IEntityPersonRepository _entity_person_repo;
        private readonly IPersonRepository _person_repo;
        private readonly IAccountEntityService _acct_es;
        private readonly IPersonEntityService _pers_es;

        public AccountEmployeeBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _entity_person_repo = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();
            _person_repo = _data_repository_factory.GetDataRepository<IPersonRepository>();
            _acct_es = _entity_service_factory.GetEntityService<IAccountEntityService>();
            _pers_es = _entity_service_factory.GetEntityService<IPersonEntityService>();
        }

        public bool EmployeeDelete(Account account, AccountPerson employee)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return ExecuteFaultHandledOperation(() =>
            {
                var person = _pers_es.Map(employee);
                person.PersonKey = employee.PersonKey;

                EntityPersonData ep_data = new EntityPersonData()
                {
                    EntityKey = account.AccountKey,
                    EntityTypeKey = 3, // Account
                    PersonKey = employee.PersonKey,
                    PersonTypeKey = employee.PersonTypeData.PersonTypeKey,
                    EntityPersonSeq = 1 // default; not used
                };

                _entity_person_repo.DeleteByObject(ep_data);
                _person_repo.Delete(person);

                return true;
            });
        }

        public int EmployeeSave(Account account, AccountPerson employee, string role, string comment)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return ExecuteFaultHandledOperation(() =>
            {
                var person = _pers_es.Map(employee);
                person.PersonKey = employee.PersonKey;

                int person_key = _person_repo.Insert(person);

                //Log.Debug($"{person.PersonLastName} Employee Comment: {employee.Comment}");

                EntityPersonData ep_data = new EntityPersonData()
                {
                    EntityKey = account.AccountKey,
                    EntityTypeKey = 3,
                    PersonKey = person_key,
                    PersonTypeKey = (int)QIQOPersonType.AccountContact, //employee.PersonTypeData.PersonTypeKey,
                    PersonRole = employee.RoleInCompany,
                    Comment = employee.Comment,
                    StartDate = employee.StartDate,
                    EndDate = employee.EndDate,
                    EntityPersonKey = employee.EntityPersonKey
                };
                int ep_ret = _entity_person_repo.Insert(ep_data);

                return person_key;

            });
        }

        public List<AccountPerson> GetEmployeeListByAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            return ExecuteFaultHandledOperation(() =>
            {
                var employees = new List<AccountPerson>();
                var acct = new AccountData() { AccountKey = account.AccountKey };

                var emps_data = _entity_person_repo.GetAll(acct);

                foreach (EntityPersonData emp_data in emps_data)
                {
                    Log.Debug("EntityPersonKey {0}", emp_data.EntityPersonKey);
                    AccountPerson employee = _acct_es.Map(emp_data);
                    //employee.PersonAttributes = entity_attrib_be.GetAttributeByEntity(employee.PersonKey, QIQOEntityType.Person);
                    //employee.Addresses = address_be.GetAddressesByEntityID(employee.PersonKey, QIQOEntityType.Person);

                    PersonData ent_per = _person_repo.GetByID(employee.PersonKey);
                    _pers_es.InitPersonData(employee, ent_per);

                    Log.Info($"Employee: {employee.PersonLastName}; Role: {employee.RoleInCompany}; Type: {employee.CompanyRoleType}; EntityPersonKey {employee.EntityPersonKey}");

                    employees.Add(employee);
                }
                return employees;
            });
        }
    }
}
