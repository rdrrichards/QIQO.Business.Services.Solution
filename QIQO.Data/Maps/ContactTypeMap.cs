using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class ContactTypeMap : MapperBase, IContactTypeMap
    { // ContactTypeMap class opener
        public ContactTypeData Map(DataRow record)
        {
            try
            {
                return new ContactTypeData()
                {
                    ContactTypeKey = NullCheck<int>(record["contact_type_key"]),
                    ContactTypeCategory = NullCheck<string>(record["contact_type_category"]),
                    ContactTypeCode = NullCheck<string>(record["contact_type_code"]),
                    ContactTypeName = NullCheck<string>(record["contact_type_name"]),
                    ContactTypeDesc = NullCheck<string>(record["contact_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ContactTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public ContactTypeData Map(IDataReader record)
        {
            try
            {
                return new ContactTypeData()
                {
                    ContactTypeKey = NullCheck<int>(record["contact_type_key"]),
                    ContactTypeCategory = NullCheck<string>(record["contact_type_category"]),
                    ContactTypeCode = NullCheck<string>(record["contact_type_code"]),
                    ContactTypeName = NullCheck<string>(record["contact_type_name"]),
                    ContactTypeDesc = NullCheck<string>(record["contact_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ContactTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ContactTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@contact_type_key", entity.ContactTypeKey));
            sql_params.Add(new SqlParameter("@contact_type_category", entity.ContactTypeCategory));
            sql_params.Add(new SqlParameter("@contact_type_code", entity.ContactTypeCode));
            sql_params.Add(new SqlParameter("@contact_type_name", entity.ContactTypeName));
            sql_params.Add(new SqlParameter("@contact_type_desc", entity.ContactTypeDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(ContactTypeData entity)
        {
            return MapParamsForDelete(entity.ContactTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int contact_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@contact_type_key", contact_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // ContactTypeMap class closer
}