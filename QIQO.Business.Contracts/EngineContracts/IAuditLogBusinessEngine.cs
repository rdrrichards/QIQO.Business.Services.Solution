using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IAuditLogBusinessEngine : IBusinessEngine
    {
        int AuditLogSave(AuditLog audit_log);
        List<AuditLog> GetAuditLogBusinessObject(string business_object);
        void AuditObject(string service_name, string comment, object obj_to_audit);
    }
}