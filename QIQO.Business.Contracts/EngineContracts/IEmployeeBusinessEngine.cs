using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IEmployeeBusinessEngine : IBusinessEngine
    {
        List<Employee> GetEmployeesByCompany(Company company);
        Employee GetEmployeeByCredentials(string user_name);
        int EmployeeSave(Employee employee);
        bool EmployeeDelete(Employee employee);
        Employee GetEmployeeByID(int entity_person_key);

        List<Representative> GetAccountRepsByCompany(int company_key);
        List<Representative> GetSalesRepsByCompany(int company_key);
        List<Representative> GetAccountRepsByCompany(Company company);
        List<Representative> GetSalesRepsByCompany(Company company);
        Representative GetAccountRepByKey(int entity_person_key);
        Representative GetSalesRepByKey(int entity_person_key);
    }
}