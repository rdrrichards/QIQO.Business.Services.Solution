using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IAuditLogRepository : IRepository<AuditLogData>
    {
        IEnumerable<AuditLogData> GetAll(string business_object);
    }
}