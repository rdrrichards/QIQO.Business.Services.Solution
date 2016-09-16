using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class ProductTypeMap : MapperBase, IProductTypeMap
    { // ProductTypeMap class opener
        public ProductTypeData Map(DataRow record)
        {
            try
            {
                return new ProductTypeData()
                {
                    ProductTypeKey = NullCheck<int>(record["product_type_key"]),
                    ProductTypeCategory = NullCheck<string>(record["product_type_category"]),
                    ProductTypeCode = NullCheck<string>(record["product_type_code"]),
                    ProductTypeName = NullCheck<string>(record["product_type_name"]),
                    ProductTypeDesc = NullCheck<string>(record["product_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException("ProductTypeMap Exception occured", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ProductTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@product_type_key", entity.ProductTypeKey));
            sql_params.Add(new SqlParameter("@product_type_category", entity.ProductTypeCategory));
            sql_params.Add(new SqlParameter("@product_type_code", entity.ProductTypeCode));
            sql_params.Add(new SqlParameter("@product_type_name", entity.ProductTypeName));
            sql_params.Add(new SqlParameter("@product_type_desc", entity.ProductTypeDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(ProductTypeData entity)
        {
            return MapParamsForDelete(entity.ProductTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int product_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@product_type_key", product_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // ProductTypeMap class closer
}