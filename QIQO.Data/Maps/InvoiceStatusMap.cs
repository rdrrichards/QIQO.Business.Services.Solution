using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class InvoiceStatusMap : MapperBase, IInvoiceStatusMap
    { // InvoiceStatusMap class opener
        public InvoiceStatusData Map(DataRow record)
        {
            try
            {
                return new InvoiceStatusData()
                {
                    InvoiceStatusKey = NullCheck<int>(record["invoice_status_key"]),
                    InvoiceStatusCode = NullCheck<string>(record["invoice_status_code"]),
                    InvoiceStatusName = NullCheck<string>(record["invoice_status_name"]),
                    InvoiceStatusType = NullCheck<string>(record["invoice_status_type"]),
                    InvoiceStatusDesc = NullCheck<string>(record["invoice_status_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceStatusMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public InvoiceStatusData Map(IDataReader record)
        {
            try
            {
                return new InvoiceStatusData()
                {
                    InvoiceStatusKey = NullCheck<int>(record["invoice_status_key"]),
                    InvoiceStatusCode = NullCheck<string>(record["invoice_status_code"]),
                    InvoiceStatusName = NullCheck<string>(record["invoice_status_name"]),
                    InvoiceStatusType = NullCheck<string>(record["invoice_status_type"]),
                    InvoiceStatusDesc = NullCheck<string>(record["invoice_status_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceStatusMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(InvoiceStatusData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@invoice_status_key", entity.InvoiceStatusKey));
            sql_params.Add(new SqlParameter("@invoice_status_code", entity.InvoiceStatusCode));
            sql_params.Add(new SqlParameter("@invoice_status_name", entity.InvoiceStatusName));
            sql_params.Add(new SqlParameter("@invoice_status_type", entity.InvoiceStatusType));
            sql_params.Add(new SqlParameter("@invoice_status_desc", entity.InvoiceStatusDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(InvoiceStatusData entity)
        {
            return MapParamsForDelete(entity.InvoiceStatusKey);
        }

        public List<SqlParameter> MapParamsForDelete(int invoice_status_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@invoice_status_key", invoice_status_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // InvoiceStatusMap class closer
}