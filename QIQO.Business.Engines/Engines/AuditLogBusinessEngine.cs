using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QIQO.Business.Engines
{
    public class AuditLogBusinessEngine : EngineBase, IAuditLogBusinessEngine
    {
        private readonly IAuditLogRepository _audit_log_repo;
        public AuditLogBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact) 
            : base (data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _audit_log_repo = _data_repository_factory.GetDataRepository<IAuditLogRepository>();
        }

        public int AuditLogSave(AuditLog audit_log)
        {
            if (audit_log == null)
                throw new ArgumentNullException(nameof(audit_log));

            return ExecuteFaultHandledOperation(() =>
            {
                AuditLogData prod_data = Map(audit_log);
                return _audit_log_repo.Insert(prod_data);
            });
        }

        public List<AuditLog> GetAuditLogBusinessObject(string business_object)
        {
            Log.Info("Accessing AuditLogBusinessEngine GetAuditLogByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var audit_log_data = _audit_log_repo.GetAll(business_object);
                List<AuditLog> audits = new List<AuditLog>();
                Log.Info("AuditLogBusinessEngine GetByID function completed");

                foreach (AuditLogData log_entry in audit_log_data)
                {
                    audits.Add(Map(log_entry));
                }
                return audits;
            });
        }

        public void AuditObject(string service_name, string comment, object obj_to_audit)
        {
            if (obj_to_audit == null) return;

            XmlSerializer serializer = GetSerializer(obj_to_audit);
            string xml;

            try
            {
                using (StringWriter text_writer = new StringWriter())
                {
                    serializer.Serialize(text_writer, obj_to_audit);
                    xml = text_writer.ToString();
                }

                AuditLogData audit_entry = new AuditLogData()
                {
                    AuditLogKey = 0,
                    AuditAction = "S",
                    AuditDatetime = DateTime.Now,
                    AuditAppName = $"App=({service_name})",
                    AuditUserId = $"{Environment.UserDomainName}\\{Environment.UserName}",
                    AuditBusObj = obj_to_audit.ToString().Replace("QIQO.Business.Entities.", ""),
                    AuditHostName = Environment.MachineName,
                    AuditComment = $"Object {obj_to_audit.ToString()} read from database via {comment}",
                    AuditDataOld = "",
                    AuditDataNew = xml
                };
                
                int audit_log_key = _audit_log_repo.Insert(audit_entry);

            }
            catch(Exception ex)
            {
                DumpException(ex);
            }
        }

        private XmlSerializer GetSerializer(object obj_to_audit)
        {
            return new XmlSerializer(obj_to_audit.GetType());
        }

        private AuditLog Map(AuditLogData audit_log_data)
        {
            AuditLog audit = new AuditLog()
            {
                AuditLogKey = audit_log_data.AuditLogKey,
                AuditAction = audit_log_data.AuditAction,
                AuditBusinessObject = audit_log_data.AuditBusObj,
                AuditDateTime = audit_log_data.AuditDatetime,
                AuditUserID = audit_log_data.AuditUserId,
                AuditHostName = audit_log_data.AuditHostName,
                AuditApplicationName = audit_log_data.AuditAppName,
                AuditComment = audit_log_data.AuditComment,
                AuditOldDataXML = audit_log_data.AuditDataOld,
                AuditNewDataXML = audit_log_data.AuditDataNew,
                AddedUserID = audit_log_data.AuditAddUserId,
                AddedDateTime = audit_log_data.AuditAddDatetime,
                UpdateUserID = audit_log_data.AuditUpdateUserId,
                UpdateDateTime = audit_log_data.AuditUpdateDatetime
            };

            return audit;
        }

        private AuditLogData Map(AuditLog audit_log)
        {
            AuditLogData audit_log_data = new AuditLogData()
            {
                AuditAction = audit_log.AuditAction,
                AuditBusObj = audit_log.AuditBusinessObject,
                AuditDatetime = audit_log.AuditDateTime,
                AuditUserId = audit_log.AuditUserID,
                AuditHostName = audit_log.AuditHostName,
                AuditAppName = audit_log.AuditApplicationName,
                AuditComment = audit_log.AuditComment,
                AuditDataOld = audit_log.AuditOldDataXML,
                AuditDataNew = audit_log.AuditNewDataXML
            };

            return audit_log_data;
        }

        private void DumpException(Exception ex)
        {
            Log.Debug("--------- Outer Exception Data ---------");
            WriteExceptionInfo(ex);
            ex = ex.InnerException;
            if (null != ex)
            {
                Log.Debug("--------- Inner Exception Data ---------");
                WriteExceptionInfo(ex);
                ex = ex.InnerException;
            }
        }
        private void WriteExceptionInfo(Exception ex)
        {
            Log.Debug($"Message: {ex.Message}");
            Log.Debug($"Exception Type: {ex.GetType().FullName}");
            Log.Debug($"Source: {ex.Source}");
            Log.Debug($"StrackTrace: {ex.StackTrace}");
            Log.Debug($"TargetSite: {ex.TargetSite}");
        }
    }
}