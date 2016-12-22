using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class ChartOfAccountsMap : MapperBase, IChartOfAccountsMap
    { // ChartOfAccountsMap class opener
        public ChartOfAccountsData Map(DataRow record)
        {
            try
            {
                return new ChartOfAccountsData() {
                    CoaKey = NullCheck<int>(record["coa_key"]),
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    AcctNo = NullCheck<string>(record["acct_no"]),
                    AcctType = NullCheck<string>(record["acct_type"]),
                    AcctName = NullCheck<string>(record["acct_name"]),
                    BalanceType = NullCheck<string>(record["balance_type"]),
                    BankAcctFlg = NullCheck<string>(record["bank_acct_flg"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ChartOfAccountsMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer
        public ChartOfAccountsData Map(IDataReader record)
        {
            try
            {
                return new ChartOfAccountsData()
                {
                    CoaKey = NullCheck<int>(record["coa_key"]),
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    AcctNo = NullCheck<string>(record["acct_no"]),
                    AcctType = NullCheck<string>(record["acct_type"]),
                    AcctName = NullCheck<string>(record["acct_name"]),
                    BalanceType = NullCheck<string>(record["balance_type"]),
                    BankAcctFlg = NullCheck<string>(record["bank_acct_flg"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ChartOfAccountsMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ChartOfAccountsData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@coa_key", entity.CoaKey));
            sql_params.Add(new SqlParameter("@company_key", entity.CompanyKey));
            sql_params.Add(new SqlParameter("@acct_no", entity.AcctNo));
            sql_params.Add(new SqlParameter("@acct_type", entity.AcctType));
            //sql_params.Add(new SqlParameter("@department_no", entity.DepartmentNo));
            //sql_params.Add(new SqlParameter("@lob_no", entity.LobNo));
            sql_params.Add(new SqlParameter("@acct_name", entity.AcctName));
            sql_params.Add(new SqlParameter("@balance_type", entity.BalanceType));
            sql_params.Add(new SqlParameter("@bank_acct_flg", entity.BankAcctFlg));
            //sql_params.Add(new SqlParameter("@report", entity.Report));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(ChartOfAccountsData entity)
        {
            return MapParamsForDelete(entity.CoaKey);
        }

        public List<SqlParameter> MapParamsForDelete(int coa_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@coa_key", coa_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // ChartOfAccountsMap class closer
}