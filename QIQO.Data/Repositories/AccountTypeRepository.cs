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
    public class AccountTypeRepository : RepositoryBase<AccountTypeData>,
                                     IAccountTypeRepository
    {
        private IMainDBContext entity_context;
        
        public AccountTypeRepository(IMainDBContext dbc, IAccountTypeMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AccountTypeData> GetAll()
        {
            Log.Info("Accessing AccountTypeRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_type_all");
                Log.Info("AccountTypeRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override AccountTypeData GetByID(int account_type_key)
        {
            Log.Info("Accessing AccountTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@account_type_key", account_type_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_type_get", pcol);
                Log.Info("AccountTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_account_type_get) function");
                return MapRow(ds);
            }
        }

        public override AccountTypeData GetByCode(string account_type_code, string entity_code)
        {
            Log.Info("Accessing AccountTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() { 
                new SqlParameter("@account_type_code", account_type_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_account_type_get_c", pcol);
                Log.Info("AccountTypeRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_account_type_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(AccountTypeData entity)
        {
            Log.Info("Accessing AccountTypeRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AccountTypeData entity)
        {
            Log.Info("Accessing AccountTypeRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountTypeData entity)
        {
            Log.Info("Accessing AccountTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_account_type_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing AccountTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@account_type_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_account_type_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing AccountTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_account_type_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(AccountTypeData entity)
        {;
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_account_type_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}