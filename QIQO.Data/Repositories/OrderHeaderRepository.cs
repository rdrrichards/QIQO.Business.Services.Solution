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
    public class OrderHeaderRepository : RepositoryBase<OrderHeaderData>, IOrderHeaderRepository
    {
        private IMainDBContext entity_context;

        public OrderHeaderRepository(IMainDBContext dbc, IOrderHeaderMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<OrderHeaderData> GetAll()
        {
            Log.Info("Accessing OrderHeaderRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_all"));
            }
        }

        public IEnumerable<OrderHeaderData> GetAllOpen(CompanyData company)
        {
            Log.Info("Accessing OrderHeaderRepo GetAllOpen by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_open_by_company", pcol));
            }
        }
        public IEnumerable<OrderHeaderData> FindAll(int company_key, string pattern)
        {
            Log.Info("Accessing OrderHeaderRepo GetAll function");
            using (entity_context)
            {
                var pcol = new List<SqlParameter>() {
                    Mapper.BuildParam("@company_key", company_key),
                    Mapper.BuildParam("@test_pattern", pattern)
                };
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_find", pcol));
            }
        }

        public IEnumerable<OrderHeaderData> GetAll(CompanyData company)
        {
            Log.Info("Accessing OrderHeaderRepo GetAll by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_all_by_company", pcol));
            }
        }

        public IEnumerable<OrderHeaderData> GetAllOpen(AccountData account)
        {
            Log.Info("Accessing OrderHeaderRepo GetAllOpen by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_open_by_account", pcol));
            }
        }

        public IEnumerable<OrderHeaderData> GetAll(AccountData account)
        {
            Log.Info("Accessing OrderHeaderRepo GetAll by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_all_by_account", pcol));
            }
        }

        public override OrderHeaderData GetByID(int order_header_key)
        {
            Log.Info("Accessing OrderHeaderRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_key", order_header_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_get", pcol));
            }
        }

        public override OrderHeaderData GetByCode(string order_header_code, string entity_code)
        {
            Log.Info("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@order_num", order_header_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_get_c", pcol));
            }
        }

        public IEnumerable<OrderHeaderData> GetForInvoice(int company_key, int account_key)
        {
            Log.Info("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", company_key),
                Mapper.BuildParam("@account_key", account_key)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_get_for_invoice", pcol));
            }
        }

        public override int Insert(OrderHeaderData entity)
        {
            Log.Info("Accessing OrderHeaderRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(OrderHeaderData entity)
        {
            Log.Info("Accessing OrderHeaderRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderHeaderData entity)
        {
            Log.Info("Accessing OrderHeaderRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_header_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing OrderHeaderRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_header_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_header_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing OrderHeaderRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_header_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(OrderHeaderData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_order_header_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}