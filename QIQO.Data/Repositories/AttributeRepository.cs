using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class AttributeRepository : RepositoryBase<AttributeData>, IAttributeRepository
    {
        private IMainDBContext entity_context;
        
        public AttributeRepository(IMainDBContext dbc, IAttributeMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AttributeData> GetAll()
        {
            Log.Info("Accessing AttributeRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_attribute_all"));
            }
        }

        public IEnumerable<AttributeData> GetAll(int entity_key, int entity_type_key)
        {
            //Log.Info("Accessing AttributeRepo GetAll by keys function");
            var pcol = new List<SqlParameter>() { 
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_attribute_all_by_entity", pcol));
            }
        }

        public override AttributeData GetByID(int attribute_key)
        {
            Log.Info("Accessing AttributeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@attribute_key", attribute_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_attribute_get", pcol));
            }
        }

        public override AttributeData GetByCode(string attribute_code, string entity_code)
        {
            Log.Info("Accessing AttributeRepo GetByCode function");
            var pcol = new List<SqlParameter>() { 
                Mapper.BuildParam("@attribute_code", attribute_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_attribute_get_c", pcol));
            }
        }

        public override int Insert(AttributeData entity)
        {
            Log.Info("Accessing AttributeRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AttributeData entity)
        {
            Log.Info("Accessing AttributeRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AttributeData entity)
        {
            Log.Info("Accessing AttributeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_attribute_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing AttributeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@attribute_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_attribute_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing AttributeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_attribute_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(AttributeData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_attribute_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}