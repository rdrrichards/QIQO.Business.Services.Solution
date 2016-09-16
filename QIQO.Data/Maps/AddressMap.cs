using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class AddressMap : MapperBase, IAddressMap
    { // AddressMap class opener
        public AddressData Map(DataRow record)
        {
            try
            {
                return new AddressData() { 
                    AddressKey = NullCheck<int>(record["address_key"]),
                    AddressTypeKey = NullCheck<int>(record["address_type_key"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    AddressLine1 = NullCheck<string>(record["address_line_1"]),
                    AddressLine2 = NullCheck<string>(record["address_line_2"]),
                    AddressLine3 = NullCheck<string>(record["address_line_3"]),
                    AddressLine4 = NullCheck<string>(record["address_line_4"]),
                    AddressCity = NullCheck<string>(record["address_city"]),
                    AddressStateProv = NullCheck<string>(record["address_state_prov"]),
                    AddressCounty = NullCheck<string>(record["address_county"]),
                    AddressCountry = NullCheck<string>(record["address_country"]),
                    AddressPostalCode = NullCheck<string>(record["address_postal_code"]),
                    AddressNotes = NullCheck<string>(record["address_notes"]),
                    AddressDefaultFlg = NullCheck<int>(record["address_default_flg"]),
                    AddressActiveFlg = NullCheck<int>(record["address_active_flg"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };

            }
            catch (Exception ex)
            {
                throw new MapException($"AddressMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AddressData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@address_key", entity.AddressKey));
            sql_params.Add(new SqlParameter("@address_type_key", entity.AddressTypeKey));
            sql_params.Add(new SqlParameter("@entity_key", entity.EntityKey));
            sql_params.Add(new SqlParameter("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(new SqlParameter("@address_line_1", entity.AddressLine1));
            sql_params.Add(new SqlParameter("@address_line_2", entity.AddressLine2));
            sql_params.Add(new SqlParameter("@address_line_3", entity.AddressLine3));
            sql_params.Add(new SqlParameter("@address_line_4", entity.AddressLine4));
            sql_params.Add(new SqlParameter("@address_city", entity.AddressCity));
            sql_params.Add(new SqlParameter("@address_state_prov", entity.AddressStateProv));
            sql_params.Add(new SqlParameter("@address_county", entity.AddressCounty));
            sql_params.Add(new SqlParameter("@address_country", entity.AddressCountry));
            sql_params.Add(new SqlParameter("@address_postal_code", entity.AddressPostalCode));
            sql_params.Add(new SqlParameter("@address_notes", entity.AddressNotes));
            sql_params.Add(new SqlParameter("@address_default_flg", entity.AddressDefaultFlg));
            sql_params.Add(new SqlParameter("@address_active_flg", entity.AddressActiveFlg));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AddressData entity)
        {
            return MapParamsForDelete(entity.AddressKey);
        }

        public List<SqlParameter> MapParamsForDelete(int address_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@address_key", address_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // AddressMap class closer
}