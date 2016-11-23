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
    public class AddressPostalRepository : RepositoryBase<AddressPostalData>,
                                     IAddressPostalRepository
    {
        private IMainDBContext entity_context;
        
        public AddressPostalRepository(IMainDBContext dbc, IAddressPostalMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<AddressPostalData> GetAll()
        {
            Log.Info("Accessing AddressPostalRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_address_postal_all");
                Log.Info("AddressPostalRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<AddressPostalData> GetAllByCountry(string country)
        {
            Log.Info("Accessing AddressPostalRepo GetAll function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@country", country) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_address_postal_all_by_country", pcol);
                Log.Info("AddressPostalRepo Passed ExecuteProcedureAsDataSet (usp_address_postal_all_by_country) function");
                return MapRows(ds);
            }
        }

        public IEnumerable<AddressPostalData> GetStatesByCountry(string country)
        {
            Log.Info("Accessing AddressPostalRepo GetAll function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@country", country) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_address_postal_states_by_country", pcol);
                Log.Info("AddressPostalRepo Passed ExecuteProcedureAsDataSet (usp_address_postal_states_by_country) function");
                return MapRows(ds);
            }
        }

        public IEnumerable<AddressPostalData> GetCountiesByState(string state)
        {
            Log.Info("Accessing AddressPostalRepo GetAll function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@state_code", state) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_address_postal_counties_by_state", pcol);
                Log.Info("AddressPostalRepo Passed ExecuteProcedureAsDataSet (usp_address_postal_counties_by_state) function");
                return MapRows(ds);
            }
        }

        public override AddressPostalData GetByID(int address_postal_key) { return null; }

        public override AddressPostalData GetByCode(string address_postal_code, string entity_code)
        {
            Log.Info("Accessing AddressPostalRepo GetByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@postal_code", address_postal_code) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_address_postal_get", pcol);
                Log.Info("AddressPostalRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_address_postal_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(AddressPostalData entity)
        {
            Log.Info("Accessing AddressPostalRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(AddressPostalData entity)
        {
            Log.Info("Accessing AddressPostalRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressPostalData entity) { Log.Info("Accessing AddressPostalRepo Delete function"); }
        public override void DeleteByCode(string entity_code) { Log.Info("Accessing AddressPostalRepo DeleteByCode function"); }
        public override void DeleteByID(int entity_key) { Log.Info("Accessing AddressPostalRepo Delete function"); }
        private int Upsert(AddressPostalData entity) { return 1; }
    }
}