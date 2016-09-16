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
    public class ChartOfAccountsRepository : RepositoryBase<ChartOfAccountsData>, IChartOfAccountsRepository
    {
        private IMainDBContext entity_context;
        
        public ChartOfAccountsRepository(IMainDBContext dbc, IChartOfAccountsMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<ChartOfAccountsData> GetAll()
        {
            Log.Info("Accessing ChartOfAccountsRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_chart_of_accounts_all");
                Log.Info("ChartOfAccountsRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<ChartOfAccountsData> GetAll(CompanyData company)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetAll by CompanyData function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_chart_of_accounts_all_by_company_key", pcol);
                Log.Info("ChartOfAccountsRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<ChartOfAccountsData> GetAll(string company_code)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetAll by company code function");

            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@company_code", company_code) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_chart_of_accounts_all_by_company_code", pcol);
                Log.Info("ChartOfAccountsRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override ChartOfAccountsData GetByID(int chart_of_accounts_key)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@chart_of_accounts_key", chart_of_accounts_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_chart_of_accounts_get", pcol);
                Log.Info("ChartOfAccountsRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_chart_of_accounts_get) function");
                return MapRow(ds);
            }
        }

        public override ChartOfAccountsData GetByCode(string chart_of_accounts_code, string entity_code)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@chart_of_accounts_code", chart_of_accounts_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_chart_of_accounts_get_c", pcol);
                Log.Info("ChartOfAccountsRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_chart_of_accounts_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(ChartOfAccountsData entity)
        {
            Log.Info("Accessing ChartOfAccountsRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(ChartOfAccountsData entity)
        {
            Log.Info("Accessing ChartOfAccountsRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ChartOfAccountsData entity)
        {
            Log.Info("Accessing ChartOfAccountsRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_chart_of_accounts_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing ChartOfAccountsRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@chart_of_accounts_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_chart_of_accounts_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing ChartOfAccountsRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_chart_of_accounts_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(ChartOfAccountsData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_chart_of_accounts_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}