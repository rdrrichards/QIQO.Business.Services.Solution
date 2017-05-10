using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_address_type_all"));
            }
        }

        public override AddressTypeData GetByID(int address_type_key)
        {
            Log.Info("Accessing AddressTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@address_type_key", address_type_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_address_type_get", pcol));
            }
        }

        public override AddressTypeData GetByCode(string address_type_code, string entity_code)
        {
            Log.Info("Accessing AddressTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() { 
                Mapper.BuildParam("@address_type_code", address_type_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_address_type_get_c", pcol));
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@address_type_code", entity_code) };
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