using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class OrderStatusMap : MapperBase, IOrderStatusMap
    { // OrderStatusMap class opener
        public OrderStatusData Map(DataRow record)
        {
            try
            {
                return new OrderStatusData()
                {
                    OrderStatusKey = NullCheck<int>(record["order_status_key"]),
                    OrderStatusCode = NullCheck<string>(record["order_status_code"]),
                    OrderStatusName = NullCheck<string>(record["order_status_name"]),
                    OrderStatusType = NullCheck<string>(record["order_status_type"]),
                    OrderStatusDesc = NullCheck<string>(record["order_status_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderStatusMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public OrderStatusData Map(IDataReader record)
        {
            try
            {
                return new OrderStatusData()
                {
                    OrderStatusKey = NullCheck<int>(record["order_status_key"]),
                    OrderStatusCode = NullCheck<string>(record["order_status_code"]),
                    OrderStatusName = NullCheck<string>(record["order_status_name"]),
                    OrderStatusType = NullCheck<string>(record["order_status_type"]),
                    OrderStatusDesc = NullCheck<string>(record["order_status_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderStatusMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(OrderStatusData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@order_status_key", entity.OrderStatusKey));
            sql_params.Add(new SqlParameter("@order_status_code", entity.OrderStatusCode));
            sql_params.Add(new SqlParameter("@order_status_name", entity.OrderStatusName));
            sql_params.Add(new SqlParameter("@order_status_type", entity.OrderStatusType));
            sql_params.Add(new SqlParameter("@order_status_desc", entity.OrderStatusDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(OrderStatusData entity)
        {
            return MapParamsForDelete(entity.OrderStatusKey);
        }

        public List<SqlParameter> MapParamsForDelete(int order_status_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@order_status_key", order_status_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // OrderStatusMap class closer
}