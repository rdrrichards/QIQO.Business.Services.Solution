using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface ILedgerRepository : IRepository<LedgerData>
    {
        IEnumerable<LedgerData> GetAll(CompanyData company);
        IEnumerable<LedgerData> GetAll(int company_key);
    }
}