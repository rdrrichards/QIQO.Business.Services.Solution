using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class CompanyService : ServiceBase, ICompanyService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public CompanyService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public int CompanyAddEmployee(Company company, Employee emp, string role, string comment)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.AddEmployee(company, emp, role, comment);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public bool CompanyDeleteEmployee(Company company, Employee emp)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.DeteteEmployee(company, emp);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public int CreateCompany(Company company)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.CompanySave(company);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public bool DeleteCompany(Company company)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.CompanyDelete(company);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        public List<Company> GetCompanies(Employee emp)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.GetCompaniesByEmployee(emp);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        public Company GetCompany(int company_key)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.GetCompanyByID(company_key);
        }

        public string GetCompanyNextNumber(Company company, QIQOEntityNumberType number_type)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.GetNextEntityNumber(company, number_type);
        }

        public string GetEmployeeRoleInCompany(Employee emp)
        {
            ICompanyBusinessEngine company_be = _business_engine_factory.GetBusinessEngine<ICompanyBusinessEngine>();
            return company_be.GetEmployeeRoleInCompany(emp);
        }
    }
}