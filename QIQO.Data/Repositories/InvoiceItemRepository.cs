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
    public class InvoiceItemRepository : RepositoryBase<InvoiceItemData>, IInvoiceItemRepository
    {
        private IMainDBContext entity_context;

        public InvoiceItemRepository(IMainDBContext dbc, IInvoiceItemMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<InvoiceItemData> GetAll()
        {
            Log.Info("Accessing InvoiceItemRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_item_all");
                Log.Info("InvoiceItemRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<InvoiceItemData> GetAll(InvoiceData invoice)
        {
            Log.Info("Accessing InvoiceItemRepo GetAll by InvoiceData function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@invoice_key", invoice.InvoiceKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_item_all", pcol);
                Log.Info("InvoiceItemRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override InvoiceItemData GetByID(int invoice_item_key)
        {
            Log.Info("Accessing InvoiceItemRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@invoice_item_key", invoice_item_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_item_get", pcol);
                Log.Info("InvoiceItemRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_invoice_item_get) function");
                return MapRow(ds);
            }
        }

        public InvoiceItemData GetByOrderItemID(int order_item_key)
        {
            Log.Info("Accessing InvoiceItemRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@order_item_key", order_item_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_item_get_by_order_item", pcol);
                Log.Info("InvoiceItemRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_invoice_item_get_by_order_item) function");
                return MapRow(ds);
            }
        }

        public override InvoiceItemData GetByCode(string invoice_item_code, string entity_code)
        {
            Log.Info("Accessing InvoiceItemRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@invoice_item_code", invoice_item_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_item_get_c", pcol);
                Log.Info("InvoiceItemRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_invoice_item_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(InvoiceItemData entity)
        {
            Log.Info("Accessing InvoiceItemRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(InvoiceItemData entity)
        {
            Log.Info("Accessing InvoiceItemRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceItemData entity)
        {
            Log.Info("Accessing InvoiceItemRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_item_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing InvoiceItemRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@invoice_item_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_item_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing InvoiceItemRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_item_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(InvoiceItemData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_invoice_item_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}