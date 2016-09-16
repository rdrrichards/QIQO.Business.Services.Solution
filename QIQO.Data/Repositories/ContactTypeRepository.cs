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
    public class ContactTypeRepository : RepositoryBase<ContactTypeData>, IContactTypeRepository
    {
        private IMainDBContext entity_context;
        
        public ContactTypeRepository(IMainDBContext dbc, IContactTypeMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<ContactTypeData> GetAll()
        {
            Log.Info("Accessing ContactTypeRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_contact_type_all");
                Log.Info("ContactTypeRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<ContactTypeData> GetAllByCategory(string category)
        {
            Log.Info("Accessing ContactTypeRepo GetAllByCategory function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@contact_type_category", category) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_contact_type_get_cat", pcol);
                Log.Info("ContactTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_contact_type_get_cat) function");
                return MapRows(ds);
            }
        }

        public override ContactTypeData GetByID(int contact_type_key)
        {
            Log.Info("Accessing ContactTypeRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@contact_type_key", contact_type_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_contact_type_get", pcol);
                Log.Info("ContactTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_contact_type_get) function");
                return MapRow(ds);
            }
        }

        public override ContactTypeData GetByCode(string contact_type_code, string entity_code)
        {
            Log.Info("Accessing ContactTypeRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@contact_type_code", contact_type_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_contact_type_get_c", pcol);
                Log.Info("ContactTypeRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_contact_type_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(ContactTypeData entity)
        {
            Log.Info("Accessing ContactTypeRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(ContactTypeData entity)
        {
            Log.Info("Accessing ContactTypeRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ContactTypeData entity)
        {
            Log.Info("Accessing ContactTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_contact_type_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing ContactTypeRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@contact_type_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_contact_type_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing ContactTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_contact_type_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(ContactTypeData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_contact_type_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}