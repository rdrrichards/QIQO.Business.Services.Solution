using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class LedgerTxnMap : MapperBase, ILedgerTxnMap
    { // LedgerTxnMap class opener
        public LedgerTxnData Map(DataRow record)
        {
            try
            {
                return new LedgerTxnData()
                {
                    LedgerTxnKey = NullCheck<int>(record["ledger_txn_key"]),
                    LedgerKey = NullCheck<int>(record["ledger_key"]),
                    TxnComment = NullCheck<string>(record["txn_comment"]),
                    AcctFrom = NullCheck<string>(record["acct_from"]),
                    DeptFrom = NullCheck<string>(record["dept_from"]),
                    LobFrom = NullCheck<string>(record["lob_from"]),
                    AcctTo = NullCheck<string>(record["acct_to"]),
                    DeptTo = NullCheck<string>(record["dept_to"]),
                    LobTo = NullCheck<string>(record["lob_to"]),
                    TxnNum = NullCheck<int>(record["txn_num"]),
                    PostDate = (DBNull.Value == record["post_date"]) ? null : record["post_date"] as DateTime?,
                    EntryDate = NullCheck<DateTime>(record["entry_date"]),
                    Credit = NullCheck<decimal>(record["credit"]),
                    Debit = NullCheck<decimal>(record["debit"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"LedgerTxnMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(LedgerTxnData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ledger_txn_key", entity.LedgerTxnKey));
            sql_params.Add(new SqlParameter("@ledger_key", entity.LedgerKey));
            sql_params.Add(new SqlParameter("@txn_comment", entity.TxnComment));
            sql_params.Add(new SqlParameter("@acct_from", entity.AcctFrom));
            sql_params.Add(new SqlParameter("@dept_from", entity.DeptFrom));
            sql_params.Add(new SqlParameter("@lob_from", entity.LobFrom));
            sql_params.Add(new SqlParameter("@acct_to", entity.AcctTo));
            sql_params.Add(new SqlParameter("@dept_to", entity.DeptTo));
            sql_params.Add(new SqlParameter("@lob_to", entity.LobTo));
            sql_params.Add(new SqlParameter("@txn_num", entity.TxnNum));
            sql_params.Add(new SqlParameter("@post_date", entity.PostDate));
            sql_params.Add(new SqlParameter("@entry_date", entity.EntryDate));
            sql_params.Add(new SqlParameter("@credit", entity.Credit));
            sql_params.Add(new SqlParameter("@debit", entity.Debit));
            sql_params.Add(new SqlParameter("@entity_key", entity.EntityKey));
            sql_params.Add(new SqlParameter("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(LedgerTxnData entity)
        {
            return MapParamsForDelete(entity.LedgerTxnKey);
        }

        public List<SqlParameter> MapParamsForDelete(int ledger_txn_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ledger_txn_key", ledger_txn_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // LedgerTxnMap class closer
}