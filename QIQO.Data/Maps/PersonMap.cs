using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class PersonMap : MapperBase, IPersonMap
    { // PersonMap class opener
        public PersonData Map(DataRow record)
        {
            try
            {
                return new PersonData()
                {
                    PersonKey = NullCheck<int>(record["person_key"]),
                    PersonCode = NullCheck<string>(record["person_code"]),
                    PersonFirstName = NullCheck<string>(record["person_first_name"]),
                    PersonMi = NullCheck<string>(record["person_mi"]),
                    PersonLastName = NullCheck<string>(record["person_last_name"]),
                    ParentPersonKey = NullCheck<int>(record["parent_person_key"]),
                    PersonDob = (DBNull.Value == record["person_dob"]) ? null : record["person_dob"] as DateTime?,
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"PersonMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(PersonData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@person_key", entity.PersonKey));
            sql_params.Add(new SqlParameter("@person_code", entity.PersonCode));
            sql_params.Add(new SqlParameter("@person_first_name", entity.PersonFirstName));
            sql_params.Add(new SqlParameter("@person_mi", entity.PersonMi));
            sql_params.Add(new SqlParameter("@person_last_name", entity.PersonLastName));
            sql_params.Add(new SqlParameter("@parent_person_key", entity.ParentPersonKey));
            sql_params.Add(new SqlParameter("@person_dob", entity.PersonDob));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(PersonData entity)
        {
            return MapParamsForDelete(entity.PersonKey);
        }

        public List<SqlParameter> MapParamsForDelete(int person_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@person_key", person_key));
            sql_params.Add(GetOutParam());
            return sql_params;
        }
    } // PersonMap class closer
}