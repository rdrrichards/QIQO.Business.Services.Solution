using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class AuditLogRepository : RepositoryBase<AuditLogData>, IAuditLogRepository
    {
        private IMainDBContext entity_context;
        
        public AuditLogRepository(IMainDBContext dbc, IAuditLogMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AuditLogData> GetAll()
        {
            Log.Info("Accessing AuditLogRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_audit_log_all"));
            }
        }

        public IEnumerable<AuditLogData> GetAll(string business_object)
        {
            Log.Info("Accessing AuditLogRepo GetAll by BO function");

            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@bus_obj", business_object) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_audit_log_all_bus_obj", pcol));
            }
        }

        public override AuditLogData GetByID(int audit_log_key)
        {
            Log.Info("Accessing AuditLogRepo GetByID function");

            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@audit_log_key", audit_log_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_audit_log_get", pcol));
            }
        }

        public override AuditLogData GetByCode(string audit_log_code, string entity_code)
        {
            Log.Info("Accessing AuditLogRepo GetByCode function");
            var pcol = new List<SqlParameter>() { 
                Mapper.BuildParam("@audit_log_code", audit_log_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_audit_log_get_c", pcol));
            }
        }

        public override int Insert(AuditLogData entity)
        {
            Log.Info("Accessing AuditLogRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AuditLogData entity)
        {
            Log.Info("Accessing AuditLogRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AuditLogData entity)
        {
            Log.Warn("Accessing AuditLogRepo Delete function. You cannot delete audit logs entries via this menthod. Nothing will be done.");
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Warn("Accessing AuditLogRepo DeleteByID function. You cannot delete audit logs entries via this menthod. Nothing will be done.");
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Warn("Accessing AuditLogRepo DeleteByCode function. You cannot delete audit logs entries via this menthod. Nothing will be done.");
        }

        private int Upsert(AuditLogData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_audit_log_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}