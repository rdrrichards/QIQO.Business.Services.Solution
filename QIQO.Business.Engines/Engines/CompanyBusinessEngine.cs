using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Engines
{
    public class CompanyBusinessEngine : EngineBase, ICompanyBusinessEngine
    {
        private readonly ICompanyRepository _company_repo;
        private readonly ICompanyEntityService _comp_es;
        private readonly IPersonEntityService _pers_es;
        private readonly IEntityAttributeBusinessEngine _entity_attrib_be;
        private readonly IPersonRepository _person_respository;
        private readonly IChartOfAccountBusinessEngine _coa_be;
        private readonly IAddressBusinessEngine _address_be;
        private readonly IEntityPersonRepository _entity_person_repository;

        public CompanyBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _company_repo = _data_repository_factory.GetDataRepository<ICompanyRepository>();
            _comp_es = _entity_service_factory.GetEntityService<ICompanyEntityService>();
            _pers_es = _entity_service_factory.GetEntityService<IPersonEntityService>();
            _entity_attrib_be = _business_engine_factory.GetBusinessEngine<IEntityAttributeBusinessEngine>();
            _person_respository = _data_repository_factory.GetDataRepository<IPersonRepository>();
            _coa_be = _business_engine_factory.GetBusinessEngine<IChartOfAccountBusinessEngine>();
            _address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            _entity_person_repository = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();
        }

        public bool CompanyDelete(Company company)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var company_data = _comp_es.Map(company);
                _company_repo.Delete(company_data);
                return true;
            });
        }

        public int CompanySave(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var company_data = _comp_es.Map(company);
                int company_key = _company_repo.Insert(company_data);

                if (company.CompanyAttributes != null)
                {
                    Log.Info($"Company attributes to be saved -> {company.CompanyAttributes.Count}");
                    foreach (EntityAttribute attribute in company.CompanyAttributes)
                    {
                        attribute.EntityKey = company_key;
                        attribute.EntityType = QIQOEntityType.Company;
                        int attr_key = _entity_attrib_be.EntityAttributeUpdate(attribute);
                    }
                }

                if (company.Employees != null)
                {
                    Log.Info($"Company employees to be saved -> {company.Employees.Count}");
                    foreach (Employee employee in company.Employees)
                    {
                            int emp_key = _person_respository.Insert(_pers_es.Map(employee));
                            int ep_key = AddEmployee(company, employee, employee.RoleInCompany, employee.Comment);
                    }
                }

                if (company.GLAccounts != null)
                {
                    Log.Info($"Company chart of accounts to be saved -> {company.GLAccounts.Count}");
                    foreach (ChartOfAccount coa in company.GLAccounts)
                    {
                        int coa_key = _coa_be.ChartOfAccountSave(coa);
                    }
                }

                if (company.CompanyAddresses != null)
                {
                    Log.Info($"Company addresses to be saved -> {company.CompanyAddresses.Count}");
                    foreach (Address addr in company.CompanyAddresses)
                    {
                        int address_key = _address_be.AddressSave(addr);
                    }
                }

                return company_key;
            });
        }

        public Company GetCompanyByID(int company_key)
        {
            Log.Info("Accessing CompanyBusinessEngine GetCompanyByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var company_data = _company_repo.GetByID(company_key);
                Log.Info("CompanyBusinessEngine GetByID function completed");

                if (company_data.CompanyKey != 0)
                {
                    return _comp_es.Map(company_data);
                }
                else
                {
                     NotFoundException ex = new NotFoundException($"Company with key {company_key} is not in database");
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<Company> GetCompaniesByEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return ExecuteFaultHandledOperation(() =>
            {
                var companys = new List<Company>();
                var person = new PersonData() { PersonKey = employee.PersonKey };

                var companys_data = _company_repo.GetAll(person);

                foreach (CompanyData company_data in companys_data)
                {
                    Company company = _comp_es.Map(company_data);
                    company.CompanyAttributes = _entity_attrib_be.GetAttributeByEntity(company.CompanyKey, QIQOEntityType.Company);
                    company.CompanyAddresses = _address_be.GetAddressesByCompany(company);
                    company.GLAccounts = _coa_be.GetChartOfAccountsByCompany(company);
                    companys.Add(company);
                }
                return companys;
            });
        }

        public string GetEmployeeRoleInCompany(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return ExecuteFaultHandledOperation(() =>
            {
                var ep_data = _entity_person_repository.GetByID(employee.EntityPersonKey);
                return ep_data.PersonRole;
            });
        }

        public int AddEmployee(Company company, Employee employee, string role, string comment)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var ep_data = new EntityPersonData()
                {
                    EntityKey = company.CompanyKey,
                    EntityTypeKey = 1,
                    PersonKey = employee.PersonKey,
                    PersonTypeKey = (int)employee.CompanyRoleType,
                    PersonRole = role,
                    Comment = comment,
                    StartDate = employee.StartDate,
                    EndDate = employee.EndDate,
                    EntityPersonKey = employee.EntityPersonKey
                };

                return _entity_person_repository.Insert(ep_data);
            });
        }

        public bool DeteteEmployee(Company company, Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var ep_data = new EntityPersonData()
                {
                    EntityKey = company.CompanyKey,
                    EntityTypeKey = 1, // Company
                    PersonKey = employee.PersonKey,
                    PersonTypeKey = (int)employee.CompanyRoleType,
                    EntityPersonSeq = 1 // default; not used
                };

                _entity_person_repository.DeleteByObject(ep_data);
                return true;
            });
        }

        public string GetNextEntityNumber(Company company, QIQOEntityNumberType num_type)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var comp = _comp_es.Map(company);
                return _company_repo.GetNextNumber(comp, (int)num_type);
            });
        }
    }
}