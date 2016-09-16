using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IAuditService
    {
        [OperationContract]
        List<AuditLog> GetAuditLogByBusinessObject(string business_object);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateAuditLog(AuditLog audit_log);
    }
}