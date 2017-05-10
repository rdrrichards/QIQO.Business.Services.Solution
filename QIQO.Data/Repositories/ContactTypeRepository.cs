using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_type_all"));
            }
        }

        public IEnumerable<ContactTypeData> GetAllByCategory(string category)
        {
            Log.Info("Accessing ContactTypeRepo GetAllByCategory function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_type_category", category) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_type_get_cat", pcol));
            }
        }

        public override ContactTypeData GetByID(int contact_type_key)
        {
            Log.Info("Accessing ContactTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_type_key", contact_type_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_type_get", pcol));
            }
        }

        public override ContactTypeData GetByCode(string contact_type_code, string entity_code)
        {
            Log.Info("Accessing ContactTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@contact_type_code", contact_type_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_type_get_c", pcol));
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_type_code", entity_code) };
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