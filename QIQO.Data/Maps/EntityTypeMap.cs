using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class EntityTypeMap : MapperBase, IEntityTypeMap
    { // EntityTypeMap class opener
        public EntityTypeData Map(DataRow record)
        {
            try
            {
                return new EntityTypeData()
                {
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    EntityTypeCode = NullCheck<string>(record["entity_type_code"]),
                    EntityTypeName = NullCheck<string>(record["entity_type_name"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"EntityTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public EntityTypeData Map(IDataReader record)
        {
            try
            {
                return new EntityTypeData()
                {
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    EntityTypeCode = NullCheck<string>(record["entity_type_code"]),
                    EntityTypeName = NullCheck<string>(record["entity_type_name"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"EntityTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(EntityTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(new SqlParameter("@entity_type_code", entity.EntityTypeCode));
            sql_params.Add(new SqlParameter("@entity_type_name", entity.EntityTypeName));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(EntityTypeData entity)
        {
            return MapParamsForDelete(entity.EntityTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int entity_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_type_key", entity_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // EntityTypeMap class closer
}