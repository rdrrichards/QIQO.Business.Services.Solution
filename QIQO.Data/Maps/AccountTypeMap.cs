using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class AccountTypeMap : MapperBase, IAccountTypeMap
    { // AccountTypeMap class opener
        public AccountTypeData Map(DataRow record)
        {
            try
            {
                return new AccountTypeData() {
                    AccountTypeKey = NullCheck<int>(record["account_type_key"]),
                    AccountTypeCode = NullCheck<string>(record["account_type_code"]),
                    AccountTypeName = NullCheck<string>(record["account_type_name"]),
                    AccountTypeDesc = NullCheck<string>(record["account_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AccountTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@account_type_key", entity.AccountTypeKey));
            sql_params.Add(new SqlParameter("@account_type_code", entity.AccountTypeCode));
            sql_params.Add(new SqlParameter("@account_type_name", entity.AccountTypeName));
            sql_params.Add(new SqlParameter("@account_type_desc", entity.AccountTypeDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AccountTypeData entity)
        {
            return MapParamsForDelete(entity.AccountTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int account_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@account_type_key", account_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // AccountTypeMap class closer
}