using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class VendorRepository : RepositoryBase<VendorData>, IVendorRepository
    {
        private IMainDBContext entity_context;

        public VendorRepository(IMainDBContext dbc, IVendorMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<VendorData> GetAll()
        {
            Log.Info("Accessing VendorRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_vendor_all"));
            }
        }

        public override VendorData GetByID(int vendor_key)
        {
            Log.Info("Accessing VendorRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@vendor_key", vendor_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_vendor_get", pcol));
            }
        }

        public override VendorData GetByCode(string vendor_code, string entity_code)
        {
            Log.Info("Accessing VendorRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@vendor_code", vendor_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_vendor_get_c", pcol));
            }
        }

        public override int Insert(VendorData entity)
        {
            Log.Info("Accessing VendorRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(VendorData entity)
        {
            Log.Info("Accessing VendorRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(VendorData entity)
        {
            Log.Info("Accessing VendorRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_vendor_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing VendorRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@vendor_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_vendor_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing VendorRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_vendor_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(VendorData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_vendor_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}