using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class InvoiceMap : MapperBase, IInvoiceMap
    { // InvoiceMap class opener
        public InvoiceData Map(DataRow record)
        {
            try
            {
                return new InvoiceData()
                {
                    InvoiceKey = NullCheck<int>(record["invoice_key"]),
                    FromEntityKey = NullCheck<int>(record["from_entity_key"]),
                    AccountKey = NullCheck<int>(record["account_key"]),
                    AccountContactKey = NullCheck<int>(record["account_contact_key"]),
                    InvoiceNum = NullCheck<string>(record["invoice_num"]),
                    InvoiceEntryDate = NullCheck<DateTime>(record["invoice_entry_date"]),
                    OrderEntryDate = NullCheck<DateTime>(record["order_entry_date"]),
                    InvoiceStatusKey = NullCheck<int>(record["invoice_status_key"]),
                    InvoiceStatusDate = NullCheck<DateTime>(record["invoice_status_date"]),
                    OrderShipDate = (DBNull.Value == record["order_ship_date"]) ? null : record["order_ship_date"] as DateTime?,
                    AccountRepKey = NullCheck<int>(record["account_rep_key"]),
                    SalesRepKey = NullCheck<int>(record["sales_rep_key"]),
                    InvoiceCompleteDate = (DBNull.Value == record["invoice_complete_date"]) ? null : record["invoice_complete_date"] as DateTime?,
                    InvoiceValueSum = NullCheck<decimal>(record["invoice_value_sum"]),
                    InvoiceItemCount = NullCheck<int>(record["invoice_item_count"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public InvoiceData Map(IDataReader record)
        {
            try
            {
                return new InvoiceData()
                {
                    InvoiceKey = NullCheck<int>(record["invoice_key"]),
                    FromEntityKey = NullCheck<int>(record["from_entity_key"]),
                    AccountKey = NullCheck<int>(record["account_key"]),
                    AccountContactKey = NullCheck<int>(record["account_contact_key"]),
                    InvoiceNum = NullCheck<string>(record["invoice_num"]),
                    InvoiceEntryDate = NullCheck<DateTime>(record["invoice_entry_date"]),
                    OrderEntryDate = NullCheck<DateTime>(record["order_entry_date"]),
                    InvoiceStatusKey = NullCheck<int>(record["invoice_status_key"]),
                    InvoiceStatusDate = NullCheck<DateTime>(record["invoice_status_date"]),
                    OrderShipDate = (DBNull.Value == record["order_ship_date"]) ? null : record["order_ship_date"] as DateTime?,
                    AccountRepKey = NullCheck<int>(record["account_rep_key"]),
                    SalesRepKey = NullCheck<int>(record["sales_rep_key"]),
                    InvoiceCompleteDate = (DBNull.Value == record["invoice_complete_date"]) ? null : record["invoice_complete_date"] as DateTime?,
                    InvoiceValueSum = NullCheck<decimal>(record["invoice_value_sum"]),
                    InvoiceItemCount = NullCheck<int>(record["invoice_item_count"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(InvoiceData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@invoice_key", entity.InvoiceKey));
            sql_params.Add(new SqlParameter("@from_entity_key", entity.FromEntityKey));
            sql_params.Add(new SqlParameter("@account_key", entity.AccountKey));
            sql_params.Add(new SqlParameter("@account_contact_key", entity.AccountContactKey));
            sql_params.Add(new SqlParameter("@invoice_num", entity.InvoiceNum));
            sql_params.Add(new SqlParameter("@invoice_entry_date", entity.InvoiceEntryDate));
            sql_params.Add(new SqlParameter("@order_entry_date", entity.OrderEntryDate));
            sql_params.Add(new SqlParameter("@invoice_status_key", entity.InvoiceStatusKey));
            sql_params.Add(new SqlParameter("@invoice_status_date", entity.InvoiceStatusDate));
            sql_params.Add(new SqlParameter("@order_ship_date", entity.OrderShipDate));
            sql_params.Add(new SqlParameter("@account_rep_key", entity.AccountRepKey));
            sql_params.Add(new SqlParameter("@sales_rep_key", entity.SalesRepKey));
            sql_params.Add(new SqlParameter("@invoice_complete_date", entity.InvoiceCompleteDate));
            sql_params.Add(new SqlParameter("@invoice_value_sum", entity.InvoiceValueSum));
            sql_params.Add(new SqlParameter("@invoice_item_count", entity.InvoiceItemCount));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(InvoiceData entity)
        {
            return MapParamsForDelete(entity.InvoiceKey);
        }

        public List<SqlParameter> MapParamsForDelete(int invoice_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@invoice_key", invoice_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // InvoiceMap class closer
}