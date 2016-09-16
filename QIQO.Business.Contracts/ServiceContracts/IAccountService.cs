using System.ServiceModel;
using QIQO.Business.Entities;
using QIQO.Common.Core;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [FaultContract(typeof(AuthorizationValidationException))]
        Account GetAccountByID(int account_key, bool full_load);

        [OperationContract]
        List<Account> GetAccountsByEmployee(Employee employee);

        [OperationContract]
        List<Account> GetAccountsByCompany(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateAccount(Account account);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteAccount(Account account);

        //[OperationContract]
        //Account GetAccount(int account_key);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string GetAccountNextNumber(Account account, QIQOEntityNumberType number_type);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [FaultContract(typeof(AuthorizationValidationException))]
        Account GetAccountByCode(string account_code, string company_code);

        [OperationContract]
        List<Account> FindAccountByCompany(Company company, string pattern);
    }
}
