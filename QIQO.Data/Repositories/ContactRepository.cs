using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class ContactRepository : RepositoryBase<ContactData>, IContactRepository
    {
        private IMainDBContext entity_context;
        
        public ContactRepository(IMainDBContext dbc, IContactMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<ContactData> GetAll()
        {
            Log.Info("Accessing ContactRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_all"));
            }
        }

        public IEnumerable<ContactData> GetAll(int entity_key, int entity_type_key)
        {
            Log.Info("Accessing ContactRepo GetAll function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_all_by_entity", pcol));
            }
        }

        public override ContactData GetByID(int contact_key)
        {
            Log.Info("Accessing ContactRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_key", contact_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_get", pcol));
            }
        }

        public override ContactData GetByCode(string contact_code, string entity_code)
        {
            Log.Info("Accessing ContactRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@contact_code", contact_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_contact_get_c", pcol));
            }
        }

        public override int Insert(ContactData entity)
        {
            Log.Info("Accessing ContactRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(ContactData entity)
        {
            Log.Info("Accessing ContactRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ContactData entity)
        {
            Log.Info("Accessing ContactRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_contact_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing ContactRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_contact_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing ContactRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_contact_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(ContactData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_contact_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}