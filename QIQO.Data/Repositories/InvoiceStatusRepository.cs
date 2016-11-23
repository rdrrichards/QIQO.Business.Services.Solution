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
    public class InvoiceStatusRepository : RepositoryBase<InvoiceStatusData>, IInvoiceStatusRepository
    {
        private IMainDBContext entity_context;

        public InvoiceStatusRepository(IMainDBContext dbc, IInvoiceStatusMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<InvoiceStatusData> GetAll()
        {
            Log.Info("Accessing InvoiceStatusRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_status_all");
                Log.Info("InvoiceStatusRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override InvoiceStatusData GetByID(int invoice_status_key)
        {
            Log.Info("Accessing InvoiceStatusRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@invoice_status_key", invoice_status_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_status_get", pcol);
                Log.Info("InvoiceStatusRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_invoice_status_get) function");
                return MapRow(ds);
            }
        }

        public override InvoiceStatusData GetByCode(string invoice_status_code, string entity_code)
        {
            Log.Info("Accessing InvoiceStatusRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@invoice_status_code", invoice_status_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_status_get_c", pcol);
                Log.Info("InvoiceStatusRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_invoice_status_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(InvoiceStatusData entity)
        {
            Log.Info("Accessing InvoiceStatusRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(InvoiceStatusData entity)
        {
            Log.Info("Accessing InvoiceStatusRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceStatusData entity)
        {
            Log.Info("Accessing InvoiceStatusRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_status_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing InvoiceStatusRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@invoice_status_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_status_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing InvoiceStatusRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_status_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(InvoiceStatusData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_invoice_status_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}