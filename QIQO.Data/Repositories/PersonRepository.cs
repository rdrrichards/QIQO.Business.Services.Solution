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
    public class PersonRepository : RepositoryBase<PersonData>, IPersonRepository
    {
        private IMainDBContext entity_context;

        public PersonRepository(IMainDBContext dbc, IPersonMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<PersonData> GetAll()
        {
            Log.Info("Accessing PersonRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_all");
                Log.Info("PersonRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<PersonData> GetAll(CompanyData comp)
        {
            Log.Info("Accessing PersonRepo GetAll by Company function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@company_key", comp.CompanyKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_all_by_company", pcol);
                Log.Info("PersonRepo Passed ExecuteProcedureAsDataSet (usp_person_all_by_company) function");
                return MapRows(ds);
            }
        }

        public IEnumerable<PersonData> GetAll(AccountData acct)
        {
            Log.Info("Accessing PersonRepo GetAll by Company function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@account_key", acct.AccountKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_all_by_account", pcol);
                Log.Info("PersonRepo Passed ExecuteProcedureAsDataSet (usp_person_all_by_account) function");
                return MapRows(ds);
            }
        }

        public override PersonData GetByCode(string account_code, string entity_code)
        {
            Log.Info("Accessing PersonRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@person_code", entity_code) };

            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_get_c", pcol);
                Log.Info("PersonRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_account_get_c) function");
                return MapRow(ds);
            }
        }

        public override PersonData GetByID(int entity_key)
        {
            Log.Info("Accessing PersonRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@person_key", entity_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_get", pcol);
                Log.Info("PersonRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_person_get) function");
                return MapRow(ds);
            }
        }

        public override int Insert(PersonData entity)
        {
            Log.Info("Accessing PersonRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(PersonData entity)
        {
            Log.Info("Accessing PersonRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(PersonData entity)
        {
            Log.Info("Accessing PersonRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_person_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing PersonRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@person_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_person_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing PersonRepo DeleteByID function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_person_del", Mapper.MapParamsForDelete(entity_key));
            }
        }
        
        public PersonData GetByUserName(string user_name)
        {
            Log.Info("Accessing PersonRepo GetByUserName function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@user_name", user_name) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_by_creds", pcol);
                Log.Info("PersonRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_person_by_creds) function");
                return MapRow(ds);
            }
        }

        public IEnumerable<PersonData> GetAllReps(CompanyData comp, int rep_type)
        {
            Log.Info("Accessing PersonRepo GetAllReps by Company function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@company_key", comp.CompanyKey),
                new SqlParameter("@rep_type", rep_type)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_all_by_company_reponly", pcol);
                Log.Info("PersonRepo Passed ExecuteProcedureAsDataSet (usp_person_all_by_company_reponly) function");
                return MapRows(ds);
            }
        }

        private int Upsert(PersonData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_person_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}
