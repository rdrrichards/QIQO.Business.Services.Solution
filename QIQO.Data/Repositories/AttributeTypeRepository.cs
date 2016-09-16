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
    public class AttributeTypeRepository : RepositoryBase<AttributeTypeData>, IAttributeTypeRepository
    {
        private IMainDBContext entity_context;
        
        public AttributeTypeRepository(IMainDBContext dbc, IAttributeTypeMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AttributeTypeData> GetAll()
        {
            Log.Info("Accessing AttributeTypeRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_attribute_type_all");
                Log.Info("AttributeTypeRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<AttributeTypeData> GetAllByCategory(string category)
        {
            Log.Info("Accessing AttributeTypeRepo GetAllByCategory function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@attribute_type_category", category) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_attribute_type_get_cat", pcol);
                Log.Info("AttributeTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_attribute_type_get_cat) function");
                return MapRows(ds);
            }
        }

        public override AttributeTypeData GetByID(int attribute_type_key)
        {
            Log.Info("Accessing AttributeTypeRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@attribute_type_key", attribute_type_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_attribute_type_get", pcol);
                Log.Info("AttributeTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_attribute_type_get) function");
                return MapRow(ds);
            }
        }

        public override AttributeTypeData GetByCode(string attribute_type_code, string entity_code)
        {
            Log.Info("Accessing AttributeTypeRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { 
                new SqlParameter("@attribute_type_code", attribute_type_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_attribute_type_get_c", pcol);
                Log.Info("AttributeTypeRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_attribute_type_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(AttributeTypeData entity)
        {
            Log.Info("Accessing AttributeTypeRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AttributeTypeData entity)
        {
            Log.Info("Accessing AttributeTypeRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AttributeTypeData entity)
        {
            Log.Info("Accessing AttributeTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_attribute_type_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing AttributeTypeRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@attribute_type_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_attribute_type_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing AttributeTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_attribute_type_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(AttributeTypeData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_attribute_type_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}