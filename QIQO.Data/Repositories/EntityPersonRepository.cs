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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_person_all"));
            }
        }

        public IEnumerable<EntityPersonData> GetAll(CompanyData company)
        {
            Log.Info("In GetAll by Emp function!");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_person_by_company", pcol));
            }
        }

        public IEnumerable<EntityPersonData> GetAll(AccountData account)
        {
            Log.Info("In GetAll by Emp function!");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_person_by_account", pcol));
            }
        }

        public override EntityPersonData GetByID(int entity_person_key)
        {
            Log.Info("Accessing EntityPersonRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_person_key", entity_person_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_person_get", pcol));
            }
        }

        public override EntityPersonData GetByCode(string entity_person_code, string entity_code)
        {
            Log.Info("Accessing EntityPersonRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@entity_person_code", entity_person_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_person_get_c", pcol));
            }
        }

        public EntityPersonData GetByPersonID(int person_key, int entity_type_key)
        {
            Log.Info("Accessing EntityPersonRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@person_key", person_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_person_get_emp_rel", pcol));
            }
        }
        
        public int SavePersonSupervisor(int person_key, int entity_key, int entity_type_key)
        {
            Log.Info("Accessing EntityPersonRepo SavePersonSupervisor function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@person_key", person_key),
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key),
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
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", company.CompanyKey),
                Mapper.BuildParam("@rep_type", rep_type)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_person_all_by_company_reponly", pcol));
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_person_code", entity_code) };
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