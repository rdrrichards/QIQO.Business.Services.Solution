using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class EntityProductMap : MapperBase, IEntityProductMap
    { // EntityProductMap class opener
        public EntityProductData Map(DataRow record)
        {
            try
            {
                return new EntityProductData()
                {
                    EntityProductKey = NullCheck<int>(record["entity_product_key"]),
                    ProductKey = NullCheck<int>(record["product_key"]),
                    ProductTypeKey = NullCheck<int>(record["product_type_key"]),
                    EntityProductSeq = NullCheck<int>(record["entity_product_seq"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    Comment = NullCheck<string>(record["comment"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"EntityProductMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(EntityProductData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_product_key", entity.EntityProductKey));
            sql_params.Add(new SqlParameter("@product_key", entity.ProductKey));
            sql_params.Add(new SqlParameter("@product_type_key", entity.ProductTypeKey));
            sql_params.Add(new SqlParameter("@entity_product_seq", entity.EntityProductSeq));
            sql_params.Add(new SqlParameter("@entity_key", entity.EntityKey));
            sql_params.Add(new SqlParameter("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(new SqlParameter("@comment", entity.Comment));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(EntityProductData entity)
        {
            return MapParamsForDelete(entity.EntityProductKey);
        }

        public List<SqlParameter> MapParamsForDelete(int entity_product_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@entity_product_key", entity_product_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // EntityProductMap class closer
}