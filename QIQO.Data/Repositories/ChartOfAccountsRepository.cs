using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_chart_of_accounts_all"));
            }
        }

        public IEnumerable<ChartOfAccountsData> GetAll(CompanyData company)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetAll by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_chart_of_accounts_all_by_company_key", pcol));
            }
        }

        public IEnumerable<ChartOfAccountsData> GetAll(string company_code)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetAll by company code function");

            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_code", company_code) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_chart_of_accounts_all_by_company_code", pcol));
            }
        }

        public override ChartOfAccountsData GetByID(int chart_of_accounts_key)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@chart_of_accounts_key", chart_of_accounts_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_chart_of_accounts_get", pcol));
            }
        }

        public override ChartOfAccountsData GetByCode(string chart_of_accounts_code, string entity_code)
        {
            Log.Info("Accessing ChartOfAccountsRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@chart_of_accounts_code", chart_of_accounts_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_chart_of_accounts_get_c", pcol));
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@chart_of_accounts_code", entity_code) };
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