using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItemData>, IOrderItemRepository
    {
        private IMainDBContext entity_context;

        public OrderItemRepository(IMainDBContext dbc, IOrderItemMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<OrderItemData> GetAll()
        {
            Log.Info("Accessing OrderItemRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_item_all"));
            }
        }

        public IEnumerable<OrderItemData> GetAll(OrderHeaderData order)
        {
            Log.Info("Accessing OrderItemRepo GetAll by InvoiceData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_key", order.OrderKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_item_all", pcol));
            }
        }

        public override OrderItemData GetByID(int order_item_key)
        {
            Log.Info("Accessing OrderItemRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_item_key", order_item_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_item_get", pcol));
            }
        }

        public override OrderItemData GetByCode(string order_item_code, string entity_code)
        {
            Log.Info("Accessing OrderItemRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@order_item_code", order_item_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_item_get_c", pcol));
            }
        }

        public override int Insert(OrderItemData entity)
        {
            Log.Info("Accessing OrderItemRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(OrderItemData entity)
        {
            Log.Info("Accessing OrderItemRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderItemData entity)
        {
            Log.Info("Accessing OrderItemRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_item_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing OrderItemRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_item_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_item_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing OrderItemRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_item_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(OrderItemData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_order_item_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}