using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<Employee> GetEmployees(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateEmployee(Employee employee);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteEmployee(Employee employee);

        [OperationContract]
        Employee GetEmployee(int entity_person_key);

        [OperationContract]
        Employee GetEmployeeByCredentials(string user_name);

        [OperationContract]
        List<Representative> GetAccountRepsByCompany(int company_key);

        [OperationContract]
        List<Representative> GetSalesRepsByCompany(int company_key);
    }
}