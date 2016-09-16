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
    public class AddressTypeRepository : RepositoryBase<AddressTypeData>,
                                     IAddressTypeRepository
    {
        private IMainDBContext entity_context;
        
        public AddressTypeRepository(IMainDBContext dbc, IAddressTypeMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AddressTypeData> GetAll()
        {
            Log.Info("Accessing AddressTypeRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_address_type_all");
                Log.Info("AddressTypeRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override AddressTypeData GetByID(int address_type_key)
        {
            Log.Info("Accessing AddressTypeRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@address_type_key", address_type_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_address_type_get", pcol);
                Log.Info("AddressTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_address_type_get) function");
                return MapRow(ds);
            }
        }

        public override AddressTypeData GetByCode(string address_type_code, string entity_code)
        {
            Log.Info("Accessing AddressTypeRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { 
                new SqlParameter("@address_type_code", address_type_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_address_type_get_c", pcol);
                Log.Info("AddressTypeRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_address_type_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(AddressTypeData entity)
        {
            Log.Info("Accessing AddressTypeRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AddressTypeData entity)
        {
            Log.Info("Accessing AddressTypeRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressTypeData entity)
        {
            Log.Info("Accessing AddressTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_address_type_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing AddressTypeRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@address_type_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_address_type_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing AddressTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_address_type_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(AddressTypeData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_address_type_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}