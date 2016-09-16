using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface ICompanyService
    {
        [OperationContract]
        List<Company> GetCompanies(Employee emp);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateCompany(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteCompany(Company company);

        [OperationContract]
        Company GetCompany(int company_key);

        [OperationContract]
        string GetEmployeeRoleInCompany(Employee emp); // , Company company

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CompanyAddEmployee(Company company, Employee emp, string role, string comment);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string GetCompanyNextNumber(Company company, QIQOEntityNumberType number_type);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool CompanyDeleteEmployee(Company company, Employee emp);
    }
}