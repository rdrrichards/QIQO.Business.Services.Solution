using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class PersonTypeMap : MapperBase, IPersonTypeMap
    { // PersonTypeMap class opener
        public PersonTypeData Map(DataRow record)
        {
            try
            {
                return new PersonTypeData()
                {
                    PersonTypeKey = NullCheck<int>(record["person_type_key"]),
                    PersonTypeCategory = NullCheck<string>(record["person_type_category"]),
                    PersonTypeCode = NullCheck<string>(record["person_type_code"]),
                    PersonTypeName = NullCheck<string>(record["person_type_name"]),
                    PersonTypeDesc = NullCheck<string>(record["person_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"PersonTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public PersonTypeData Map(IDataReader record)
        {
            try
            {
                return new PersonTypeData()
                {
                    PersonTypeKey = NullCheck<int>(record["person_type_key"]),
                    PersonTypeCategory = NullCheck<string>(record["person_type_category"]),
                    PersonTypeCode = NullCheck<string>(record["person_type_code"]),
                    PersonTypeName = NullCheck<string>(record["person_type_name"]),
                    PersonTypeDesc = NullCheck<string>(record["person_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"PersonTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(PersonTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@person_type_key", entity.PersonTypeKey));
            sql_params.Add(new SqlParameter("@person_type_category", entity.PersonTypeCategory));
            sql_params.Add(new SqlParameter("@person_type_code", entity.PersonTypeCode));
            sql_params.Add(new SqlParameter("@person_type_name", entity.PersonTypeName));
            sql_params.Add(new SqlParameter("@person_type_desc", entity.PersonTypeDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(PersonTypeData entity)
        {
            return MapParamsForDelete(entity.PersonTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int person_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@person_type_key", person_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // PersonTypeMap class closer
}