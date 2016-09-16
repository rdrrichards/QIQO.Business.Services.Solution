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
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_vendor_all");
                Log.Info("VendorRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override VendorData GetByID(int vendor_key)
        {
            Log.Info("Accessing VendorRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@vendor_key", vendor_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_vendor_get", pcol);
                Log.Info("VendorRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_vendor_get) function");
                return MapRow(ds);
            }
        }

        public override VendorData GetByCode(string vendor_code, string entity_code)
        {
            Log.Info("Accessing VendorRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@vendor_code", vendor_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_vendor_get_c", pcol);
                Log.Info("VendorRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_vendor_get_c) function");
                return MapRow(ds);
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
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@vendor_code", entity_code) };
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