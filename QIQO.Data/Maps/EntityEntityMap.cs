using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class EntityEntityMap : MapperBase, IEntityEntityMap
    { // EntityEntityMap class opener
        public EntityEntityData Map(DataRow record)
        {
            try
            {
                return new EntityEntityData()
                {
                    EntityEntityKey = NullCheck<int>(record["entity_entity_key"]),
                    PrimaryEntityKey = NullCheck<int>(record["primary_entity_key"]),
                    PrimaryEntityTypeKey = NullCheck<int>(record["primary_entity_type_key"]),
                    SecondaryEntityKey = NullCheck<int>(record["secondary_entity_key"]),
                    SecondaryEntityTypeKey = NullCheck<int>(record["secondary_entity_type_key"]),
                    EntityEntitySeq = NullCheck<int>(record["entity_entity_seq"]),
                    EntityEntityRole = NullCheck<string>(record["entity_entity_role"]),
                    Comment = NullCheck<string>(record["comment"]),
                    StartDate = NullCheck<DateTime>(record["start_date"]),
                    EndDate = NullCheck<DateTime>(record["end_date"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"EntityEntityMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(EntityEntityData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_entity_key", entity.EntityEntityKey));
            sql_params.Add(new SqlParameter("@primary_entity_key", entity.PrimaryEntityKey));
            sql_params.Add(new SqlParameter("@primary_entity_type_key", entity.PrimaryEntityTypeKey));
            sql_params.Add(new SqlParameter("@secondary_entity_key", entity.SecondaryEntityKey));
            sql_params.Add(new SqlParameter("@secondary_entity_type_key", entity.SecondaryEntityTypeKey));
            sql_params.Add(new SqlParameter("@entity_entity_seq", entity.EntityEntitySeq));
            sql_params.Add(new SqlParameter("@entity_entity_role", entity.EntityEntityRole));
            sql_params.Add(new SqlParameter("@comment", entity.Comment));
            sql_params.Add(new SqlParameter("@start_date", entity.StartDate));
            sql_params.Add(new SqlParameter("@end_date", entity.EndDate));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(EntityEntityData entity)
        {
            return MapParamsForDelete(entity.EntityEntityKey);
        }

        public List<SqlParameter> MapParamsForDelete(int entity_entity_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_entity_key", entity_entity_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // EntityEntityMap class closer
}