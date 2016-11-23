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
    public class OrderStatusRepository : RepositoryBase<OrderStatusData>, IOrderStatusRepository //, IStatusRepository<OrderStatusData>
    {
        private IMainDBContext entity_context;

        public OrderStatusRepository(IMainDBContext dbc, IOrderStatusMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<OrderStatusData> GetAll()
        {
            Log.Info("Accessing OrderStatusRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_order_status_all");
                Log.Info("OrderStatusRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override OrderStatusData GetByID(int order_status_key)
        {
            Log.Info("Accessing OrderStatusRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@order_status_key", order_status_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_order_status_get", pcol);
                Log.Info("OrderStatusRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_order_status_get) function");
                return MapRow(ds);
            }
        }

        public override OrderStatusData GetByCode(string order_status_code, string entity_code)
        {
            Log.Info("Accessing OrderStatusRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@order_status_code", order_status_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_order_status_get_c", pcol);
                Log.Info("OrderStatusRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_order_status_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(OrderStatusData entity)
        {
            Log.Info("Accessing OrderStatusRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(OrderStatusData entity)
        {
            Log.Info("Accessing OrderStatusRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderStatusData entity)
        {
            Log.Info("Accessing OrderStatusRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_status_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing OrderStatusRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@order_status_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_status_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing OrderStatusRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_status_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(OrderStatusData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_order_status_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}