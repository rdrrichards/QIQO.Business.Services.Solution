using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class LedgerTxnRepository : RepositoryBase<LedgerTxnData>, ILedgerTxnRepository
    {
        private IMainDBContext entity_context;
 
        public LedgerTxnRepository(IMainDBContext dbc, ILedgerTxnMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<LedgerTxnData> GetAll()
        {
            return null;
        }

        public IEnumerable<LedgerTxnData> GetAll(LedgerData gl_data)
        {
            Log.Info("Accessing LedgerTxnRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ledger_key", gl_data.LedgerKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_ledger_txn_all"));
            }
        }

        public override LedgerTxnData GetByID(int ledger_txn_key)
        {
            Log.Info("Accessing LedgerTxnRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ledger_txn_key", ledger_txn_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_ledger_txn_get", pcol));
            }
        }

        public override LedgerTxnData GetByCode(string ledger_txn_code, string entity_code)
        {
            Log.Info("Accessing LedgerTxnRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@ledger_txn_code", ledger_txn_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_ledger_txn_get_c", pcol));
            }
        }

        public override int Insert(LedgerTxnData entity)
        {
            Log.Info("Accessing LedgerTxnRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(LedgerTxnData entity)
        {
            Log.Info("Accessing LedgerTxnRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(LedgerTxnData entity)
        {
            Log.Info("Accessing LedgerTxnRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_ledger_txn_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing LedgerTxnRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ledger_txn_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_ledger_txn_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing LedgerTxnRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_ledger_txn_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(LedgerTxnData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_ledger_txn_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}