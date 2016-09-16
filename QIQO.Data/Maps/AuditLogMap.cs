using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class AuditLogMap : MapperBase, IAuditLogMap
    { // AuditLogMap class opener
        public AuditLogData Map(DataRow record)
        {
            try
            {
                return new AuditLogData() { 
                    AuditLogKey = NullCheck<int>(record["audit_log_key"]),
                    AuditAction = NullCheck<string>(record["audit_action"]),
                    AuditBusObj = NullCheck<string>(record["audit_bus_obj"]),
                    AuditDatetime = NullCheck<DateTime>(record["audit_datetime"]),
                    AuditUserId = NullCheck<string>(record["audit_user_id"]),
                    AuditAppName = NullCheck<string>(record["audit_app_name"]),
                    AuditHostName = NullCheck<string>(record["audit_host_name"]),
                    AuditComment = NullCheck<string>(record["audit_comment"]),
                    AuditDataOld = NullCheck<string>(record["audit_data_old"]),
                    AuditDataNew = NullCheck<string>(record["audit_data_new"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AuditLogMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AuditLogData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@audit_log_key", entity.AuditLogKey));
            sql_params.Add(new SqlParameter("@audit_action", entity.AuditAction));
            sql_params.Add(new SqlParameter("@audit_bus_obj", entity.AuditBusObj));
            sql_params.Add(new SqlParameter("@audit_datetime", entity.AuditDatetime));
            sql_params.Add(new SqlParameter("@audit_user_id", entity.AuditUserId));
            sql_params.Add(new SqlParameter("@audit_app_name", entity.AuditAppName));
            sql_params.Add(new SqlParameter("@audit_host_name", entity.AuditHostName));
            sql_params.Add(new SqlParameter("@audit_comment", entity.AuditComment));
            sql_params.Add(new SqlParameter("@audit_data_old", entity.AuditDataOld));
            sql_params.Add(new SqlParameter("@audit_data_new", entity.AuditDataNew));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AuditLogData entity)
        {
            return MapParamsForDelete(entity.AuditLogKey);
        }

        public List<SqlParameter> MapParamsForDelete(int audit_log_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@audit_log_key", audit_log_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // AuditLogMap class closer
}