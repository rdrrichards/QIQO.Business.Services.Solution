using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class CompanyRepository : RepositoryBase<CompanyData>, ICompanyRepository
    {
        private IMainDBContext entity_context;
        
        public CompanyRepository(IMainDBContext dbc, ICompanyMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<CompanyData> GetAll()
        {
            Log.Info("Accessing CompanyRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_company_all"));
            }
        }

        public IEnumerable<CompanyData> GetAll(PersonData person)
        {
            Log.Info("Accessing CompanyRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@employee_key", person.PersonKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_company_all_by_person", pcol));
            }
        }

        public override CompanyData GetByID(int company_key)
        {
            Log.Info("Accessing CompanyRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_company_get", pcol));
            }
        }

        public override CompanyData GetByCode(string company_code, string entity_code)
        {
            Log.Info("Accessing CompanyRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_code", company_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_company_get_c", pcol));
            }
        }

        public string GetNextNumber(CompanyData company, int number_type)
        {
            Log.Info("Accessing AccountRepo GetNextNumber function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_key", company.CompanyKey) };
            switch (number_type)
            {
                case 3:
                    return entity_context.ExecuteSqlStatementAsScalar<string>("usp_get_next_emp_num", pcol);
                case 4:
                    return entity_context.ExecuteSqlStatementAsScalar<string>("usp_get_next_acct_num", pcol);
                case 5:
                    return entity_context.ExecuteSqlStatementAsScalar<string>("usp_get_next_vend_num", pcol);
                default:
                    return "";
            }
        }

        public override int Insert(CompanyData entity)
        {
            Log.Info("Accessing CompanyRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(CompanyData entity)
        {
            Log.Info("Accessing CompanyRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CompanyData entity)
        {
            Log.Info("Accessing CompanyRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_company_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing CompanyRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_company_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing CompanyRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_company_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(CompanyData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_company_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
} // namespace closer
