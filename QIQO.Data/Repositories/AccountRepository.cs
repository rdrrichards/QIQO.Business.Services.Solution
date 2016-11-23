using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class AccountRepository : RepositoryBase<AccountData>, 
                                     IAccountRepository
    {
        private IMainDBContext entity_context;
        
        public AccountRepository(IMainDBContext dbc, IAccountMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AccountData> GetAll()
        {
            Log.Info("Accessing AccountRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_all");
                Log.Info("AccountRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<AccountData> GetAll(CompanyData company)
        {
            Log.Info("Accessing AccountRepo GetAll function");
            using (entity_context)
            {
                var pcol = new List<SqlParameter>() { new SqlParameter("@company_key", company.CompanyKey) };
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_all_by_company", pcol);
                Log.Info("AccountRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<AccountData> GetAll(PersonData employee)
        {
            Log.Info("Accessing AccountRepo GetAll function");
            using (entity_context)
            {
                var pcol = new List<SqlParameter>() { new SqlParameter("@person_key", employee.PersonKey) };
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_all_by_person", pcol);
                Log.Info("AccountRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<AccountData> FindAll(int company_key, string pattern)
        {
            Log.Info("Accessing AccountRepo GetAll function");
            using (entity_context)
            {
                var pcol = new List<SqlParameter>() {
                    new SqlParameter("@company_key", company_key),
                    new SqlParameter("@account_pattern", pattern)
                };
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_find", pcol);
                Log.Info("AccountRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override AccountData GetByID(int account_key)
        {
            Log.Info("Accessing AccountRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@account_key", account_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_get", pcol);
                Log.Info("AccountRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_account_get) function");
                return MapRow(ds);
            }
        }

        public override AccountData GetByCode(string account_code, string entity_code)
        {
            Log.Info("Accessing AccountRepo GetByCode function");
            var pcol = new List<SqlParameter>() { 
                new SqlParameter("@account_code", account_code),
                new SqlParameter("@company_code", entity_code)
            };

            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_get_c", pcol);
                Log.Info("AccountRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_account_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(AccountData entity)
        {
            Log.Info("Accessing AccountRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AccountData entity)
        {
            Log.Info("Accessing AccountRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountData entity)
        {
            Log.Info("Accessing AccountRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing AccountRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@account_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_account_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing AccountRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(AccountData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_account_ups", Mapper.MapParamsForUpsert(entity));
            }
        }

        public string GetNextNumber(AccountData account, int entity_desc)
        {
            Log.Info("Accessing AccountRepo GetNextNumber function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@entity_key", account.AccountKey) };
            using (entity_context)
            {
                if (entity_desc == 2)
                    return entity_context.ExecuteSqlStatementAsScalar<string>("usp_get_next_order_num", pcol);
                else
                    return entity_context.ExecuteSqlStatementAsScalar<string>("usp_get_next_invoice_num", pcol);
            }
        }
    }
}
