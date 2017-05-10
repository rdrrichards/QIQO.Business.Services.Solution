using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class AttributeTypeMap : MapperBase, IAttributeTypeMap
    { // AttributeTypeMap class opener
        public AttributeTypeData Map(DataRow record)
        {
            try
            {
                return new AttributeTypeData() { 
                    AttributeTypeKey = NullCheck<int>(record["attribute_type_key"]),
                    AttributeTypeCategory = NullCheck<string>(record["attribute_type_category"]),
                    AttributeTypeCode = NullCheck<string>(record["attribute_type_code"]),
                    AttributeTypeName = NullCheck<string>(record["attribute_type_name"]),
                    AttributeTypeDesc = NullCheck<string>(record["attribute_type_desc"]),
                    AttributeDataTypeKey = NullCheck<int>(record["attribute_data_type_key"]),
                    AttributeDefaultFormat = NullCheck<string>(record["attribute_default_format"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AttributeTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public AttributeTypeData Map(IDataReader record)
        {
            try
            {
                return new AttributeTypeData()
                {
                    AttributeTypeKey = NullCheck<int>(record["attribute_type_key"]),
                    AttributeTypeCategory = NullCheck<string>(record["attribute_type_category"]),
                    AttributeTypeCode = NullCheck<string>(record["attribute_type_code"]),
                    AttributeTypeName = NullCheck<string>(record["attribute_type_name"]),
                    AttributeTypeDesc = NullCheck<string>(record["attribute_type_desc"]),
                    AttributeDataTypeKey = NullCheck<int>(record["attribute_data_type_key"]),
                    AttributeDefaultFormat = NullCheck<string>(record["attribute_default_format"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AttributeTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AttributeTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@attribute_type_key", entity.AttributeTypeKey));
            sql_params.Add(new SqlParameter("@attribute_type_category", entity.AttributeTypeCategory));
            sql_params.Add(new SqlParameter("@attribute_type_code", entity.AttributeTypeCode));
            sql_params.Add(new SqlParameter("@attribute_type_name", entity.AttributeTypeName));
            sql_params.Add(new SqlParameter("@attribute_type_desc", entity.AttributeTypeDesc));
            sql_params.Add(new SqlParameter("@attribute_data_type_key", entity.AttributeDataTypeKey));
            sql_params.Add(new SqlParameter("@attribute_default_format", entity.AttributeDefaultFormat));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AttributeTypeData entity)
        {
            return MapParamsForDelete(entity.AttributeTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int attribute_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@attribute_type_key", attribute_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // AttributeTypeMap class closer
}