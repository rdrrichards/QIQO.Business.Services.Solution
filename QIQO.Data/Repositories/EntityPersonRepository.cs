using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using QIQO.Data.Maps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class EntityPersonRepository : RepositoryBase<EntityPersonData>, IEntityPersonRepository
    {
        private IMainDBContext entity_context;

        public EntityPersonRepository(IMainDBContext dbc, IEntityPersonMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<EntityPersonData> GetAll()
        {
            Log.Info("Accessing EntityPersonRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_person_all");
                Log.Info("EntityPersonRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<EntityPersonData> GetAll(CompanyData company)
        {
            Log.Info("In GetAll by Emp function!");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_person_by_company", pcol);
                Log.Info("Made it passed ExecuteProcedureAsDataSet (usp_entity_person_by_company) function!");
                return MapRows(ds);
            }
        }

        public IEnumerable<EntityPersonData> GetAll(AccountData account)
        {
            Log.Info("In GetAll by Emp function!");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@account_key", account.AccountKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_person_by_account", pcol);
                Log.Info("Made it passed ExecuteProcedureAsDataSet (usp_entity_person_by_company) function!");
                return MapRows(ds);
            }
        }

        public override EntityPersonData GetByID(int entity_person_key)
        {
            Log.Info("Accessing EntityPersonRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@entity_person_key", entity_person_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_person_get", pcol);
                Log.Info("EntityPersonRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_entity_person_get) function");
                return MapRow(ds);
            }
        }

        public override EntityPersonData GetByCode(string entity_person_code, string entity_code)
        {
            Log.Info("Accessing EntityPersonRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@entity_person_code", entity_person_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_person_get_c", pcol);
                Log.Info("EntityPersonRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_entity_person_get_c) function");
                return MapRow(ds);
            }
        }

        public EntityPersonData GetByPersonID(int person_key, int entity_type_key)
        {
            Log.Info("Accessing EntityPersonRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@person_key", person_key),
                new SqlParameter("@entity_type_key", entity_type_key)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_person_get_emp_rel", pcol);
                Log.Info("EntityPersonRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_entity_person_get_emp_rel) function");
                return MapRow(ds);
            }
        }
        
        public int SavePersonSupervisor(int person_key, int entity_key, int entity_type_key)
        {
            Log.Info("Accessing EntityPersonRepo SavePersonSupervisor function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@person_key", person_key),
                new SqlParameter("@entity_key", entity_key),
                new SqlParameter("@entity_type_key", entity_type_key),
                new SqlParameter("@key", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 18, "", DataRowVersion.Current, null)
            };
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_entity_person_ups_emp_rel", pcol);
            }
        }

        public IEnumerable<EntityPersonData> GetAllReps(CompanyData company, int rep_type)
        {
            Log.Info("Accessing EntityPersonRepo GetAllReps by Company function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@company_key", company.CompanyKey),
                new SqlParameter("@rep_type", rep_type)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_person_all_by_company_reponly", pcol);
                Log.Info("PersonRepo Passed ExecuteProcedureAsDataSet (usp_entity_person_all_by_company_reponly) function");
                return MapRows(ds);
            }
        }

        public override int Insert(EntityPersonData entity)
        {
            Log.Info("Accessing EntityPersonRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(EntityPersonData entity)
        {
            Log.Info("Accessing EntityPersonRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(EntityPersonData entity)
        {
            Log.Info("Accessing EntityPersonRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_person_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing EntityPersonRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@entity_person_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_person_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing EntityPersonRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_person_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        public void DeleteByObject(EntityPersonData entity)
        {
            Log.Info("Accessing EntityPersonRepo Delete function");
            EntityPersonMap map = new EntityPersonMap();
            List<SqlParameter> pcol = map.MapParamsForObjectDelete(entity);
            map = null;
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_person_del", pcol);
            }
        }

        private int Upsert(EntityPersonData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_entity_person_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}