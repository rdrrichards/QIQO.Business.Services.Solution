using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_status_all"));
            }
        }

        public override InvoiceStatusData GetByID(int invoice_status_key)
        {
            Log.Info("Accessing InvoiceStatusRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_status_key", invoice_status_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_status_get", pcol));
            }
        }

        public override InvoiceStatusData GetByCode(string invoice_status_code, string entity_code)
        {
            Log.Info("Accessing InvoiceStatusRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@invoice_status_code", invoice_status_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_status_get_c", pcol));
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_status_code", entity_code) };
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