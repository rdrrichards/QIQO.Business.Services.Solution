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
    public class FeeScheduleRepository : RepositoryBase<FeeScheduleData>, IFeeScheduleRepository
    {
        private IMainDBContext entity_context;
        
        public FeeScheduleRepository(IMainDBContext dbc, IFeeScheduleMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<FeeScheduleData> GetAll()
        {
            Log.Info("Accessing FeeScheduleRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_fee_schedule_all");
                Log.Info("FeeScheduleRepo ExecuteProcedureAsDataSet function call successful");

                List<FeeScheduleData> rows = new List<FeeScheduleData>();
                return MapRows(ds);
            }
        }

        public IEnumerable<FeeScheduleData> GetAll(AccountData account)
        {
            Log.Info("Accessing FeeScheduleRepo GetAll by Account function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@account_key", account.AccountKey) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_fee_schedule_all_by_account", pcol);
                Log.Info("FeeScheduleRepo Passed ExecuteProcedureAsDataSet (usp_fee_schedule_all_by_account) function");
                return MapRows(ds);
            }
        }

        public IEnumerable<FeeScheduleData> GetAll(CompanyData company)
        {
            Log.Info("Accessing FeeScheduleRepo GetAll by Company function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@account_key", company.CompanyKey) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_fee_schedule_all_by_company", pcol);
                Log.Info("FeeScheduleRepo Passed ExecuteProcedureAsDataSet (usp_fee_schedule_all_by_company) function");
                return MapRows(ds);
            }
        }

        public IEnumerable<FeeScheduleData> GetAll(ProductData product)
        {
            Log.Info("Accessing FeeScheduleRepo GetAll by Product function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@product_key", product.ProductKey) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_fee_schedule_all_by_product", pcol);
                Log.Info("FeeScheduleRepo Passed ExecuteProcedureAsDataSet (usp_fee_schedule_all_by_product) function");
                return MapRows(ds);
            }
        }

        public override FeeScheduleData GetByID(int fee_schedule_key)
        {
            Log.Info("Accessing FeeScheduleRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@fee_schedule_key", fee_schedule_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_fee_schedule_get", pcol);
                Log.Info("FeeScheduleRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_fee_schedule_get) function");
                return MapRow(ds);
            }
        }

        public override FeeScheduleData GetByCode(string fee_schedule_code, string entity_code)
        {
            Log.Info("Accessing FeeScheduleRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@fee_schedule_code", fee_schedule_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_fee_schedule_get_c", pcol);
                Log.Info("FeeScheduleRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_fee_schedule_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(FeeScheduleData entity)
        {
            Log.Info("Accessing FeeScheduleRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(FeeScheduleData entity)
        {
            Log.Info("Accessing FeeScheduleRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(FeeScheduleData entity)
        {
            Log.Info("Accessing FeeScheduleRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_fee_schedule_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing FeeScheduleRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@fee_schedule_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_fee_schedule_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing FeeScheduleRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_fee_schedule_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(FeeScheduleData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_fee_schedule_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}