using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IAccountBusinessEngine : IBusinessEngine
    {
        Account GetAccountByID(int account_key, bool full_load = false);
        //Account GetAccountByIDLite(int account_key);
        Account GetAccountByCode(string account_code, string company_code);
        Account GetAccountByCode(string account_code, Company company);
        List<Account> GetAccountsByCompany(Company company);
        List<Account> GetAccountsByRep(Employee employee);
        List<Account> FindAccountsByCompany(Company company, string search_pattern);
        int AccountSave(Account account);
        bool AccountDelete(Account account);
        string GetNextEntityNumber(Account account, QIQOEntityNumberType num_type);
    }
}