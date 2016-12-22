using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class AddressTypeMap : MapperBase, IAddressTypeMap
    { // AddressTypeMap class opener
        public AddressTypeData Map(DataRow record)
        {
            try
            {
                return new AddressTypeData() { 
                    AddressTypeKey = NullCheck<int>(record["address_type_key"]),
                    AddressTypeCode = NullCheck<string>(record["address_type_code"]),
                    AddressTypeName = NullCheck<string>(record["address_type_name"]),
                    AddressTypeDesc = NullCheck<string>(record["address_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AddressTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public AddressTypeData Map(IDataReader record)
        {
            try
            {
                return new AddressTypeData()
                {
                    AddressTypeKey = NullCheck<int>(record["address_type_key"]),
                    AddressTypeCode = NullCheck<string>(record["address_type_code"]),
                    AddressTypeName = NullCheck<string>(record["address_type_name"]),
                    AddressTypeDesc = NullCheck<string>(record["address_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AddressTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AddressTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@address_type_key", entity.AddressTypeKey));
            sql_params.Add(new SqlParameter("@address_type_code", entity.AddressTypeCode));
            sql_params.Add(new SqlParameter("@address_type_name", entity.AddressTypeName));
            sql_params.Add(new SqlParameter("@address_type_desc", entity.AddressTypeDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AddressTypeData entity)
        {
            return MapParamsForDelete(entity.AddressTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int address_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@address_type_key", address_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // AddressTypeMap class closer
}