using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface ICompanyBusinessEngine : IBusinessEngine
    {
        bool CompanyDelete(Company company);
        int CompanySave(Company company);
        Company GetCompanyByID(int company_key);
        List<Company> GetCompaniesByEmployee(Employee employee);
        int AddEmployee(Company company, Employee employee, string role, string comment);
        bool DeteteEmployee(Company company, Employee employee);
        string GetNextEntityNumber(Company company, QIQOEntityNumberType num_type);
        string GetEmployeeRoleInCompany(Employee employee);
    }
}