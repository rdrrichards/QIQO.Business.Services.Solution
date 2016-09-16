using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class ContactMap : MapperBase, IContactMap
    { // ContactMap class opener
        public ContactData Map(DataRow record)
        {
            try
            {
                return new ContactData()
                {
                    ContactKey = NullCheck<int>(record["contact_key"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    ContactTypeKey = NullCheck<int>(record["contact_type_key"]),
                    ContactValue = NullCheck<string>(record["contact_value"]),
                    ContactDefaultFlg = NullCheck<int>(record["contact_default_flg"]),
                    ContactActiveFlg = NullCheck<int>(record["contact_active_flg"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"]),
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ContactMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ContactData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@contact_key", entity.ContactKey));
            sql_params.Add(new SqlParameter("@entity_key", entity.EntityKey));
            sql_params.Add(new SqlParameter("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(new SqlParameter("@contact_type_key", entity.ContactTypeKey));
            sql_params.Add(new SqlParameter("@contact_value", entity.ContactValue));
            sql_params.Add(new SqlParameter("@contact_default_flg", entity.ContactDefaultFlg));
            sql_params.Add(new SqlParameter("@contact_active_flg", entity.ContactActiveFlg));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(ContactData entity)
        {
            return MapParamsForDelete(entity.ContactKey);
        }

        public List<SqlParameter> MapParamsForDelete(int contact_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@contact_key", contact_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // ContactMap class closer
}