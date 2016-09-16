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
    public class AddressRepository : RepositoryBase<AddressData>, IAddressRepository
    {
        private IMainDBContext entity_context;

        public AddressRepository(IMainDBContext dbc, IAddressMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AddressData> GetAll()
        {
            Log.Info("Accessing AddressRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_address_all");
                Log.Info("AddressRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<AddressData> GetAll(int entity_key, int entity_type)
        {
            Log.Info("Accessing AddressRepo GetAll by keys function");
            List<SqlParameter> pcol = new List<SqlParameter>() { 
                new SqlParameter("@entity_key", entity_key),
                new SqlParameter("@entity_type_key", entity_type)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_address_all_by_entity", pcol);
                Log.Info("AddressRepo Passed ExecuteProcedureAsDataSet (usp_address_all_by_entity) function");
                return MapRows(ds);
            }
        }

        public override AddressData GetByID(int address_key)
        {
            Log.Info("Accessing AddressRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@address_key", address_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_address_get", pcol);
                Log.Info("AddressRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_address_get) function");
                return MapRow(ds);
            }
        }

        public override AddressData GetByCode(string address_code, string entity_code)
        {
            Log.Info("Accessing AddressRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@address_code", address_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_address_get_c", pcol);
                Log.Info("AddressRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_address_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(AddressData entity)
        {
            Log.Info("Accessing AddressRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AddressData entity)
        {
            Log.Info("Accessing AddressRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressData entity)
        {
            Log.Info("Accessing AddressRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_address_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing AddressRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@address_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_address_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing AddressRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_address_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(AddressData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_address_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}