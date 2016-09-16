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
    public class LedgerRepository : RepositoryBase<LedgerData>, ILedgerRepository
    {
        private IMainDBContext entity_context;

        public LedgerRepository(IMainDBContext dbc, ILedgerMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<LedgerData> GetAll()
        {
            return null;
        }

        public IEnumerable<LedgerData> GetAll(CompanyData company)
        {
            Log.Info("Accessing LedgerRepo GetAll function");
            return GetAll(company.CompanyKey);
        }

        public IEnumerable<LedgerData> GetAll(int company_key)
        {
            Log.Info("Accessing LedgerRepo GetAll function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@company_key", company_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_ledger_all");
                Log.Info("LedgerRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override LedgerData GetByID(int ledger_key)
        {
            Log.Info("Accessing LedgerRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@ledger_key", ledger_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_ledger_get", pcol);
                Log.Info("LedgerRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_ledger_get) function");
                return MapRow(ds);
            }
        }

        public override LedgerData GetByCode(string ledger_code, string entity_code)
        {
            Log.Info("Accessing LedgerRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@ledger_code", ledger_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_ledger_get_c", pcol);
                Log.Info("LedgerRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_ledger_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(LedgerData entity)
        {
            Log.Info("Accessing LedgerRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(LedgerData entity)
        {
            Log.Info("Accessing LedgerRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(LedgerData entity)
        {
            Log.Info("Accessing LedgerRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_ledger_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing LedgerRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@ledger_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_ledger_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing LedgerRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_ledger_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(LedgerData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_ledger_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}