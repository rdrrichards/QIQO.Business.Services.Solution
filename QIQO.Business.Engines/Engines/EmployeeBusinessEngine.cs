using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace QIQO.Business.Engines
{
    public class EmployeeBusinessEngine : EngineBase, IEmployeeBusinessEngine
    {
        private readonly IPersonEntityService _pers_es;
        private readonly IEntityPersonRepository _entity_person_repo;
        private readonly IPersonRepository _person_repo;
        private readonly IEntityAttributeBusinessEngine _entity_attrib_be;
        private readonly IAddressBusinessEngine _address_be;
        private readonly ICompanyBusinessEngine _company_be;

        public EmployeeBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
        : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _pers_es = _entity_service_factory.GetEntityService<IPersonEntityService>();
            _entity_person_repo = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();
            _person_repo = _data_repository_factory.GetDataRepository<IPersonRepository>();
            _entity_attrib_be = _business_engine_factory.GetBusinessEngine<IEntityAttributeBusinessEngine>();
            _address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            _company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
        }

        public List<Employee> GetEmployeesByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() => 
            {
                var employees = new List<Employee>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };

                var emps_data = _entity_person_repo.GetAll(comp);

                foreach (EntityPersonData emp_data in emps_data)
                {
                    Employee employee = _pers_es.Map(emp_data);
                    employee.PersonAttributes = _entity_attrib_be.GetAttributeByEntity(employee.PersonKey, QIQOEntityType.Person);
                    employee.Addresses = _address_be.GetAddressesByEntityID(employee.PersonKey, QIQOEntityType.Person);

                    //employee.Companies = compHelper.GetCompaniesByEmployee(employee); // CAUSES Stack Overflow - of sorts HERE

                    PersonData ent_per = _person_repo.GetByID(employee.PersonKey);

                    //GetEmployeeSupervisor(employee);
                    _pers_es.InitPersonData(employee, ent_per);

                    //Log.Info("Employee: {0}; Role: {1}; Type: {2}; EntityPersonKey {3}", employee.PersonLastName, 
                    //    employee.RoleInCompany, employee.CompanyRoleType, employee.EntityPersonKey);

                    employees.Add(employee);
                }
                return employees;
            });
        }

        public Employee GetEmployeeByCredentials(string user_name)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                Log.Debug($"GetEmployeeByCredentials user_name: {user_name}");
                var emp_data = _person_repo.GetByUserName(user_name);

                var ep_data = _entity_person_repo.GetByID(emp_data.PersonKey);

                var employee = _pers_es.Map(ep_data);
                employee.PersonAttributes = _entity_attrib_be.GetAttributeByEntity(employee.PersonKey, QIQOEntityType.Person);
                employee.Addresses = _address_be.GetAddressesByEntityID(employee.PersonKey, QIQOEntityType.Person);
                employee.Companies = _company_be.GetCompaniesByEmployee(employee);
                //GetEmployeeSupervisor(employee);
                _pers_es.InitPersonData(employee, emp_data);
                return employee;
            });
        }

        public int EmployeeSave(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            int person_key;

            return ExecuteFaultHandledOperation(() =>
            {
                var person = _pers_es.Map(employee);
                person.PersonKey = employee.PersonKey;

                person_key = _person_repo.Insert(person);
                Log.Info($"Employee [{person_key}] saved to the database sucessfully!");

                if (employee.Addresses != null)
                {
                    Log.Info($"Employee addresses to be saved -> {employee.Addresses.Count}");
                    foreach (Address address in employee.Addresses)
                    {
                        address.EntityKey = person_key;
                        address.EntityType = QIQOEntityType.Person;
                        int addr_key = _address_be.AddressSave(address);
                    }
                }

                if (employee.PersonAttributes != null)
                {
                    Log.Info($"Employee attributes to be saved -> {employee.PersonAttributes.Count}");
                    foreach (EntityAttribute attribute in employee.PersonAttributes)
                    {
                        attribute.EntityKey = person_key;
                        attribute.EntityType = QIQOEntityType.Person;
                        int attr_key = _entity_attrib_be.EntityAttributeUpdate(attribute);
                    }
                }

                SaveEmployeeSupervisor(employee);
                return person_key;
            });
        }

        public bool EmployeeDelete(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return ExecuteFaultHandledOperation(() =>
            {
                var person = _pers_es.Map(employee);
                person.PersonKey = employee.PersonKey;

                if (employee.Addresses != null)
                {
                    Log.Info($"Employee addresses to be saved -> {employee.Addresses.Count}");
                    foreach (Address address in employee.Addresses)
                    {
                        _address_be.AddressDelete(address);
                    }
                }

                if (employee.PersonAttributes != null)
                {
                    Log.Info($"Employee attributes to be saved -> {employee.PersonAttributes.Count}");
                    foreach (EntityAttribute attribute in employee.PersonAttributes)
                    {
                        _entity_attrib_be.EntityAttributeDelete(attribute);
                    }
                }

                _person_repo.Delete(person);
                Log.Info($"Employee [{person.PersonKey}] deleted from the database sucessfully!");
                return true;
            });
        }

        public Employee GetEmployeeByID(int entity_person_key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                Log.Debug($"GetEmployeeByID entity_person_key: {entity_person_key}");
                var ep_data = _entity_person_repo.GetByID(entity_person_key);
                var employee = _pers_es.Map(ep_data);

                employee.PersonAttributes = _entity_attrib_be.GetAttributeByEntity(employee.PersonKey, QIQOEntityType.Person);
                employee.Addresses = _address_be.GetAddressesByEntityID(employee.PersonKey, QIQOEntityType.Person);
                employee.Companies = _company_be.GetCompaniesByEmployee(employee);

                var emp_data = _person_repo.GetByID(employee.PersonKey);
                _pers_es.InitPersonData(employee, emp_data);
                GetEmployeeSupervisor(employee);
                return employee;
            });
        }

        public List<Representative> GetAccountRepsByCompany(int company_key)
        {
            return GetRepsByCompany(company_key, QIQOPersonType.AccountRepresentative);
        }

        public List<Representative> GetSalesRepsByCompany(int company_key)
        {
            return GetRepsByCompany(company_key, QIQOPersonType.SalesRepresentative);
        }

        public List<Representative> GetAccountRepsByCompany(Company company)
        {
            return GetRepsByCompany(company.CompanyKey, QIQOPersonType.AccountRepresentative);
        }

        public List<Representative> GetSalesRepsByCompany(Company company)
        {
            return GetRepsByCompany(company.CompanyKey, QIQOPersonType.SalesRepresentative);
        }

        private List<Representative> GetRepsByCompany(int company_key, QIQOPersonType rep_type)
        {
            var company_reps = new List<Representative>();

            return ExecuteFaultHandledOperation(() =>
            {
                var company_data = new CompanyData() { CompanyKey = company_key };
                var reps = _entity_person_repo.GetAllReps(company_data, (int)rep_type);

                foreach (EntityPersonData rep in reps)
                {
                    var pers_data = _person_repo.GetByID(rep.PersonKey);
                    var employee = MapPersonDataToRep(pers_data, rep);
                    employee.PersonAttributes = _entity_attrib_be.GetAttributeByEntity(employee.PersonKey, QIQOEntityType.Person);
                    company_reps.Add(employee);
                }
                return company_reps;
            });
        }

        public Representative GetAccountRepByKey(int entity_person_key)
        {
            return GetRepByKey(entity_person_key);
        }

        public Representative GetSalesRepByKey(int entity_person_key)
        {
            return GetRepByKey(entity_person_key);
        }

        private Representative GetRepByKey(int entity_person_key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var emp_data = _entity_person_repo.GetByID(entity_person_key);
                var pers_data = _person_repo.GetByID(entity_person_key);
                var employee = MapPersonDataToRep(pers_data, emp_data);
                employee.PersonAttributes = _entity_attrib_be.GetAttributeByEntity(employee.PersonKey, QIQOEntityType.Person);
                employee.Addresses = _address_be.GetAddressesByEntityID(employee.PersonKey, QIQOEntityType.Person);
                return employee;
            });
        }

        private void GetEmployeeSupervisor(Employee employee)
        {
            Log.Info($"Get Employee Supervisor Call for {employee.PersonKey}");
            EntityPersonData mgr_data = _entity_person_repo.GetByPersonID(employee.PersonKey, (int)QIQOEntityType.Manager);
            if (mgr_data.EntityPersonKey != 0)
                employee.ParentEmployeeKey = mgr_data.EntityKey;
        }

        private int SaveEmployeeSupervisor(Employee employee)
        {
            if (employee.ParentEmployeeKey == 0) return 0;
 
            Log.Info($"Save Employee Supervisor Call for {employee.PersonKey}");
            return _entity_person_repo.SavePersonSupervisor(employee.PersonKey, employee.ParentEmployeeKey, (int)QIQOEntityType.Manager);
        }

        private Employee MapPersonDataToEmployee(PersonData emp_data)
        {
            return MapPersonData<Employee>(emp_data);
        }

        private T MapPersonData<T>(PersonData emp_data) where T : PersonBase, new()
        {
            T employee = new T();
            _pers_es.InitPersonData(employee as Employee, emp_data);
            return employee;
        }
        
        private Representative MapPersonDataToRep(PersonData per_data, EntityPersonData emp_data)
        {
            Representative rep = MapPersonData<Representative>(per_data);
            _pers_es.Map(emp_data, rep);
            return rep;
        }
    }
}