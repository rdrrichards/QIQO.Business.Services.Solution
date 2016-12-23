using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_person_all"));
            }
        }

        public IEnumerable<PersonData> GetAll(CompanyData comp)
        {
            Log.Info("Accessing PersonRepo GetAll by Company function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", comp.CompanyKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_person_all_by_company", pcol));
            }
        }

        public IEnumerable<PersonData> GetAll(AccountData acct)
        {
            Log.Info("Accessing PersonRepo GetAll by Company function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", acct.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_person_all_by_account", pcol));
            }
        }

        public override PersonData GetByCode(string account_code, string entity_code)
        {
            Log.Info("Accessing PersonRepo GetByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_code", entity_code) };

            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_person_get_c", pcol));
            }
        }

        public override PersonData GetByID(int entity_key)
        {
            Log.Info("Accessing PersonRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_key", entity_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_person_get", pcol));
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_code", entity_code) };
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@user_name", user_name) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_person_by_creds", pcol));
            }
        }

        public IEnumerable<PersonData> GetAllReps(CompanyData comp, int rep_type)
        {
            Log.Info("Accessing PersonRepo GetAllReps by Company function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", comp.CompanyKey),
                Mapper.BuildParam("@rep_type", rep_type)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_person_all_by_company_reponly", pcol));
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
