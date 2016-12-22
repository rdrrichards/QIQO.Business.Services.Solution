using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class ProductMap : MapperBase, IProductMap
    { // ProductMap class opener
        public ProductData Map(DataRow record)
        {
            try
            {
                return new ProductData()
                {
                    ProductKey = NullCheck<int>(record["product_key"]),
                    ProductTypeKey = NullCheck<int>(record["product_type_key"]),
                    ProductCode = NullCheck<string>(record["product_code"]),
                    ProductName = NullCheck<string>(record["product_name"]),
                    ProductDesc = NullCheck<string>(record["product_desc"]),
                    ProductNameShort = NullCheck<string>(record["product_name_short"]),
                    ProductNameLong = NullCheck<string>(record["product_name_long"]),
                    ProductImagePath = NullCheck<string>(record["product_image_path"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ProductMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public ProductData Map(IDataReader record)
        {
            try
            {
                return new ProductData()
                {
                    ProductKey = NullCheck<int>(record["product_key"]),
                    ProductTypeKey = NullCheck<int>(record["product_type_key"]),
                    ProductCode = NullCheck<string>(record["product_code"]),
                    ProductName = NullCheck<string>(record["product_name"]),
                    ProductDesc = NullCheck<string>(record["product_desc"]),
                    ProductNameShort = NullCheck<string>(record["product_name_short"]),
                    ProductNameLong = NullCheck<string>(record["product_name_long"]),
                    ProductImagePath = NullCheck<string>(record["product_image_path"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ProductMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ProductData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@product_key", entity.ProductKey));
            sql_params.Add(new SqlParameter("@product_type_key", entity.ProductTypeKey));
            sql_params.Add(new SqlParameter("@product_code", entity.ProductCode));
            sql_params.Add(new SqlParameter("@product_name", entity.ProductName));
            sql_params.Add(new SqlParameter("@product_desc", entity.ProductDesc));
            sql_params.Add(new SqlParameter("@product_name_short", entity.ProductNameShort));
            sql_params.Add(new SqlParameter("@product_name_long", entity.ProductNameLong));
            sql_params.Add(new SqlParameter("@product_image_path", entity.ProductImagePath));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(ProductData entity)
        {
            return MapParamsForDelete(entity.ProductKey);
        }

        public List<SqlParameter> MapParamsForDelete(int product_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@product_key", product_key));
            sql_params.Add(GetOutParam());
            return sql_params;
        }
    } // ProductMap class closer
}