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
    public class EntityEntityRepository : RepositoryBase<EntityEntityData>, IEntityEntityRepository
    {
        private IMainDBContext entity_context;
        
        public EntityEntityRepository(IMainDBContext dbc, IEntityEntityMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<EntityEntityData> GetAll()
        {
            Log.Info("Accessing EntityEntityRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_entity_all");
                Log.Info("EntityEntityRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override EntityEntityData GetByID(int entity_entity_key)
        {
            Log.Info("Accessing EntityEntityRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@entity_entity_key", entity_entity_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_entity_get", pcol);
                Log.Info("EntityEntityRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_entity_entity_get) function");
                return MapRow(ds);
            }
        }

        public override EntityEntityData GetByCode(string entity_entity_code, string entity_code)
        {
            Log.Info("Accessing EntityEntityRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@entity_entity_code", entity_entity_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_entity_entity_get_c", pcol);
                Log.Info("EntityEntityRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_entity_entity_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(EntityEntityData entity)
        {
            Log.Info("Accessing EntityEntityRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(EntityEntityData entity)
        {
            Log.Info("Accessing EntityEntityRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(EntityEntityData entity)
        {
            Log.Info("Accessing EntityEntityRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_entity_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing EntityEntityRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@entity_entity_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_entity_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing EntityEntityRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_entity_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(EntityEntityData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_entity_entity_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}