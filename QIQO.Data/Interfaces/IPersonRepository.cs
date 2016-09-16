using QIQO.Data.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IPersonRepository : IRepository<PersonData>
    {
        IEnumerable<PersonData> GetAll(CompanyData comp);
        IEnumerable<PersonData> GetAll(AccountData acct);
        PersonData GetByUserName(string user_name);
        IEnumerable<PersonData> GetAllReps(CompanyData comp, int rep_type);
    }
}