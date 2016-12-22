using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class AccountMap : MapperBase, IAccountMap
    {
        public AccountData Map(DataRow record)
        {
            try
            {
                return new AccountData() {
                    AccountKey = NullCheck<int>(record["account_key"]),
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    AccountTypeKey = NullCheck<int>(record["account_type_key"]),
                    AccountCode = NullCheck<string>(record["account_code"]),
                    AccountName = NullCheck<string>(record["account_name"]),
                    AccountDesc = NullCheck<string>(record["account_desc"]),
                    AccountDba = NullCheck<string>(record["account_dba"]),
                    AccountStartDate = NullCheck<DateTime>(record["account_start_date"]),
                    AccountEndDate = NullCheck<DateTime>(record["account_end_date"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };               
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer
        public AccountData Map(IDataReader record)
        {
            try
            {
                return new AccountData()
                {
                    AccountKey = NullCheck<int>(record["account_key"]),
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    AccountTypeKey = NullCheck<int>(record["account_type_key"]),
                    AccountCode = NullCheck<string>(record["account_code"]),
                    AccountName = NullCheck<string>(record["account_name"]),
                    AccountDesc = NullCheck<string>(record["account_desc"]),
                    AccountDba = NullCheck<string>(record["account_dba"]),
                    AccountStartDate = NullCheck<DateTime>(record["account_start_date"]),
                    AccountEndDate = NullCheck<DateTime>(record["account_end_date"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AccountData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@account_key", entity.AccountKey));
            sql_params.Add(new SqlParameter("@company_key", entity.CompanyKey));
            sql_params.Add(new SqlParameter("@account_type_key", entity.AccountTypeKey));
            sql_params.Add(new SqlParameter("@account_code", entity.AccountCode));
            sql_params.Add(new SqlParameter("@account_name", entity.AccountName));
            sql_params.Add(new SqlParameter("@account_desc", entity.AccountDesc));
            sql_params.Add(new SqlParameter("@account_dba", entity.AccountDba));
            sql_params.Add(new SqlParameter("@account_start_date", entity.AccountStartDate));
            sql_params.Add(new SqlParameter("@account_end_date", entity.AccountEndDate));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AccountData entity)
        {
            return MapParamsForDelete(entity.AccountKey);
        }

        public List<SqlParameter> MapParamsForDelete(int account_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@account_key", account_key));
            sql_params.Add(GetOutParam());
            return sql_params;
        }
    }
}