using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    //**** THIS CLASS IS NO LONGER USED
    public class UserSessionMap : MapperBase, IUserSessionMap
    { // UserSessionMap class opener
        public UserSessionData Map(DataRow record)
        {
            try
            {
                UserSessionData obj = new UserSessionData();

                obj.SessionKey = (DBNull.Value == record["session_key"]) ? 0 : (int)record["session_key"];
                obj.SessionCode = (DBNull.Value == record["session_code"]) ? string.Empty : (string)record["session_code"];
                obj.HostName = (DBNull.Value == record["host_name"]) ? string.Empty : (string)record["host_name"];
                obj.UserDomain = (DBNull.Value == record["user_domain"]) ? string.Empty : (string)record["user_domain"];
                obj.UserName = (DBNull.Value == record["user_name"]) ? string.Empty : (string)record["user_name"];
                obj.ProcessId = (DBNull.Value == record["process_id"]) ? 0 : (int)record["process_id"];
                obj.CompanyKey = (DBNull.Value == record["company_key"]) ? 0 : (int)record["company_key"];
                obj.StartDate = (DBNull.Value == record["start_date"]) ? DateTime.MinValue : (DateTime)record["start_date"];
                obj.EndDate = (DBNull.Value == record["end_date"]) ? null : record["end_date"] as DateTime?;
                obj.ActiveFlg = (DBNull.Value == record["active_flg"]) ? 0 : (int)record["active_flg"];
                obj.AuditAddUserId = (DBNull.Value == record["audit_add_user_id"]) ? string.Empty : (string)record["audit_add_user_id"];
                obj.AuditAddDatetime = (DBNull.Value == record["audit_add_datetime"]) ? DateTime.MinValue : (DateTime)record["audit_add_datetime"];
                obj.AuditUpdateUserId = (DBNull.Value == record["audit_update_user_id"]) ? string.Empty : (string)record["audit_update_user_id"];
                obj.AuditUpdateDatetime = (DBNull.Value == record["audit_update_datetime"]) ? DateTime.MinValue : (DateTime)record["audit_update_datetime"];

                return obj;
            }
            catch (Exception ex)
            {
                throw new MapException("UserSessionMap Exception occured", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(UserSessionData entity)
        {
            List<SqlParameter> sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@session_key", entity.SessionKey));
            sql_params.Add(new SqlParameter("@session_code", entity.SessionCode));
            sql_params.Add(new SqlParameter("@host_name", entity.HostName));
            sql_params.Add(new SqlParameter("@user_domain", entity.UserDomain));
            sql_params.Add(new SqlParameter("@user_name", entity.UserName));
            sql_params.Add(new SqlParameter("@process_id", entity.ProcessId));
            sql_params.Add(new SqlParameter("@company_key", entity.CompanyKey));
            sql_params.Add(new SqlParameter("@start_date", entity.StartDate));
            sql_params.Add(new SqlParameter("@end_date", entity.EndDate));
            sql_params.Add(new SqlParameter("@active_flg", entity.ActiveFlg));
            sql_params.Add(this.GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(UserSessionData entity)
        {
            List<SqlParameter> sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@session_key", entity.SessionKey));
            sql_params.Add(this.GetOutParam());

            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(int session_key)
        {
            List<SqlParameter> sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@session_key", session_key));
            sql_params.Add(this.GetOutParam());

            return sql_params;
        }
    } // UserSessionMap class closer
}