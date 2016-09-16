using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class LedgerMap : MapperBase, ILedgerMap
    { // LedgerMap class opener
        public LedgerData Map(DataRow record)
        {
            try
            {
                return new LedgerData()
                {
                    LedgerKey = NullCheck<int>(record["ledger_key"]),
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    LedgerCode = NullCheck<string>(record["ledger_code"]),
                    LedgerName = NullCheck<string>(record["ledger_name"]),
                    LedgerDesc = NullCheck<string>(record["ledger_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"LedgerMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(LedgerData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ledger_key", entity.LedgerKey));
            sql_params.Add(new SqlParameter("@company_key", entity.CompanyKey));
            sql_params.Add(new SqlParameter("@ledger_code", entity.LedgerCode));
            sql_params.Add(new SqlParameter("@ledger_name", entity.LedgerName));
            sql_params.Add(new SqlParameter("@ledger_desc", entity.LedgerDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(LedgerData entity)
        {
            return MapParamsForDelete(entity.LedgerKey);
        }

        public List<SqlParameter> MapParamsForDelete(int ledger_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ledger_key", ledger_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // LedgerMap class closer
}