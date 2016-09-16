using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class AuditService : ServiceBase, IAuditService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public AuditService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int CreateAuditLog(AuditLog audit_log)
        {
            IAuditLogBusinessEngine audit_be = _business_engine_factory.GetBusinessEngine<IAuditLogBusinessEngine>();
            return audit_be.AuditLogSave(audit_log);
        }
        
        public List<AuditLog> GetAuditLogByBusinessObject(string business_object)
        {
            IAuditLogBusinessEngine audit_be = _business_engine_factory.GetBusinessEngine<IAuditLogBusinessEngine>();
            return audit_be.GetAuditLogBusinessObject(business_object);
        }
    }
}