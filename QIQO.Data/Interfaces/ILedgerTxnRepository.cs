using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface ILedgerTxnRepository : IRepository<LedgerTxnData>
    {
        IEnumerable<LedgerTxnData> GetAll(LedgerData gl_data);
    }
}