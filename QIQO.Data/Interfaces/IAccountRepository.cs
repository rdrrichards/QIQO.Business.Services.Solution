using QIQO.Data.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IAccountRepository : IRepository<AccountData>
    {
        string GetNextNumber(AccountData account, int entity_desc);
        IEnumerable<AccountData> GetAll(CompanyData company);
        IEnumerable<AccountData> GetAll(PersonData employee);
        IEnumerable<AccountData> FindAll(int company_key, string pattern);
    }
}