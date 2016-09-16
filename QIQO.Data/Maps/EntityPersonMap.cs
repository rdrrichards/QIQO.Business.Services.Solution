using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class EntityPersonMap : MapperBase, IEntityPersonMap
    { // EntityPersonMap class opener
        public EntityPersonData Map(DataRow record)
        {
            try
            {
                return new EntityPersonData()
                {
                    EntityPersonKey = NullCheck<int>(record["entity_person_key"]),
                    PersonKey = NullCheck<int>(record["person_key"]),
                    PersonTypeKey = NullCheck<int>(record["person_type_key"]),
                    PersonRole = NullCheck<string>(record["person_role"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
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
                throw new MapException($"EntityPersonMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(EntityPersonData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_person_key", entity.EntityPersonKey));
            sql_params.Add(new SqlParameter("@person_key", entity.PersonKey));
            sql_params.Add(new SqlParameter("@person_type_key", entity.PersonTypeKey));
            //sql_params.Add(new SqlParameter("@entity_person_seq", entity.EntityPersonSeq));
            sql_params.Add(new SqlParameter("@person_role", entity.PersonRole));
            sql_params.Add(new SqlParameter("@entity_key", entity.EntityKey));
            sql_params.Add(new SqlParameter("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(new SqlParameter("@comment", entity.Comment));
            sql_params.Add(new SqlParameter("@start_date", entity.StartDate));
            sql_params.Add(new SqlParameter("@end_date", entity.EndDate));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(EntityPersonData entity)
        {
            return MapParamsForDelete(entity.EntityPersonKey);
        }

        public List<SqlParameter> MapParamsForObjectDelete(EntityPersonData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@person_key", entity.PersonKey));
            sql_params.Add(new SqlParameter("@person_type_key", entity.PersonTypeKey));
            sql_params.Add(new SqlParameter("@entity_key", entity.EntityKey));
            sql_params.Add(new SqlParameter("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(GetOutParam());

            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(int entity_person_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_person_key", entity_person_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // EntityPersonMap class closer
}