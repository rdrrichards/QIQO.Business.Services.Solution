using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class AuditLogEntityService : IAuditLogEntityService
    {
        public AuditLog Map(AuditLogData audit_log_data)
        {
            return new AuditLog()
            {
                AuditLogKey = audit_log_data.AuditLogKey,
                AuditAction = audit_log_data.AuditAction,
                AuditBusinessObject = audit_log_data.AuditBusObj,
                AuditDateTime = audit_log_data.AuditDatetime,
                AuditUserID = audit_log_data.AuditUserId,
                AuditApplicationName = audit_log_data.AuditAppName,
                AuditHostName = audit_log_data.AuditHostName,
                AuditComment = audit_log_data.AuditComment,
                AuditOldDataXML = audit_log_data.AuditDataOld,
                AuditNewDataXML = audit_log_data.AuditDataNew,
                AddedUserID = audit_log_data.AuditAddUserId,
                AddedDateTime = audit_log_data.AuditAddDatetime,
                UpdateUserID = audit_log_data.AuditUpdateUserId,
                UpdateDateTime = audit_log_data.AuditUpdateDatetime,
            };
        }

        public AuditLogData Map(AuditLog audit_log)
        {
            return new AuditLogData()
            {
                AuditAction = audit_log.AuditAction,
                AuditBusObj = audit_log.AuditBusinessObject,
                AuditDatetime = audit_log.AuditDateTime,
                AuditUserId = audit_log.AuditUserID,
                AuditAppName = audit_log.AuditApplicationName,
                AuditHostName = audit_log.AuditHostName,
                AuditComment = audit_log.AuditComment,
                AuditDataOld = audit_log.AuditOldDataXML,
                AuditDataNew = audit_log.AuditNewDataXML
            };
        }
    }
}