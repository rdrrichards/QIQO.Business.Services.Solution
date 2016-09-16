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
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public EmployeeService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        public int CreateEmployee(Employee employee)
        {
            IEmployeeBusinessEngine employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            return employee_be.EmployeeSave(employee);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        public bool DeleteEmployee(Employee employee)
        {
            IEmployeeBusinessEngine employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            return employee_be.EmployeeDelete(employee);
        }

        public List<Representative> GetAccountRepsByCompany(int company_key)
        {
            IEmployeeBusinessEngine employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            return employee_be.GetAccountRepsByCompany(company_key);
        }

        public Employee GetEmployee(int entity_person_key)
        {
            IEmployeeBusinessEngine employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            return employee_be.GetEmployeeByID(entity_person_key);
        }

        public Employee GetEmployeeByCredentials(string user_name)
        {
            IEmployeeBusinessEngine employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            return employee_be.GetEmployeeByCredentials(user_name);
        }

        public List<Employee> GetEmployees(Company company)
        {
            IEmployeeBusinessEngine employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            return employee_be.GetEmployeesByCompany(company);
        }

        public List<Representative> GetSalesRepsByCompany(int company_key)
        {
            IEmployeeBusinessEngine employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            return employee_be.GetSalesRepsByCompany(company_key);
        }
    }
}