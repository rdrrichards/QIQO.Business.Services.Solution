using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class EntityProductRepository : RepositoryBase<EntityProductData>, IEntityProductRepository
    {
        private IMainDBContext entity_context;
        
        public EntityProductRepository(IMainDBContext dbc, IEntityProductMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<EntityProductData> GetAll()
        {
            Log.Info("Accessing EntityProductRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_product_all"));
            }
        }

        public IEnumerable<EntityProductData> GetAll(int entity_key, int entity_type_key)
        {
            Log.Info("Accessing EntityProductRepo GetAll by Person function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_product_all_by_entity", pcol));
            }
        }

        public override EntityProductData GetByID(int entity_product_key)
        {
            Log.Info("Accessing EntityProductRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_product_key", entity_product_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_product_get", pcol));
            }
        }

        public override EntityProductData GetByCode(string entity_product_code, string entity_code)
        {
            Log.Info("Accessing EntityProductRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@entity_product_code", entity_product_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_entity_product_get_c", pcol));
            }
        }

        public override int Insert(EntityProductData entity)
        {
            Log.Info("Accessing EntityProductRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(EntityProductData entity)
        {
            Log.Info("Accessing EntityProductRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(EntityProductData entity)
        {
            Log.Info("Accessing EntityProductRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_product_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing EntityProductRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_product_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_product_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing EntityProductRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_entity_product_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(EntityProductData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_entity_product_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}