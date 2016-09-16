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
    public class PersonTypeRepository : RepositoryBase<PersonTypeData>, IPersonTypeRepository
    {
        private IMainDBContext entity_context;

        public PersonTypeRepository(IMainDBContext dbc, IPersonTypeMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<PersonTypeData> GetAll()
        {
            Log.Info("Accessing PersonTypeRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_type_all");
                Log.Info("PersonTypeRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<PersonTypeData> GetAllByCategory(string category)
        {
            Log.Info("Accessing PersonTypeRepo GetAllByCategory function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@person_type_category", category) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_type_get_cat", pcol);
                Log.Info("PersonTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_person_type_get_cat) function");
                return MapRows(ds);
            }
        }

        public override PersonTypeData GetByID(int person_type_key)
        {
            Log.Info("Accessing PersonTypeRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@person_type_key", person_type_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_type_get", pcol);
                Log.Info("PersonTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_person_type_get) function");
                return MapRow(ds);
            }
        }

        public override PersonTypeData GetByCode(string person_type_code, string entity_code)
        {
            Log.Info("Accessing PersonTypeRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@person_type_code", person_type_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_person_type_get_c", pcol);
                Log.Info("PersonTypeRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_person_type_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(PersonTypeData entity)
        {
            Log.Info("Accessing PersonTypeRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(PersonTypeData entity)
        {
            Log.Info("Accessing PersonTypeRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(PersonTypeData entity)
        {
            Log.Info("Accessing PersonTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_person_type_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing PersonTypeRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@person_type_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_person_type_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing PersonTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_person_type_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(PersonTypeData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_person_type_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}