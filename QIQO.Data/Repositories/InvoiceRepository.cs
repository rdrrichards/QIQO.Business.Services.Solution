using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class InvoiceRepository : RepositoryBase<InvoiceData>, IInvoiceRepository
    {
        private IMainDBContext entity_context;

        public InvoiceRepository(IMainDBContext dbc, IInvoiceMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<InvoiceData> GetAll()
        {
            Log.Info("Accessing InvoiceRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_all"));
            }
        }

        public IEnumerable<InvoiceData> GetAll(CompanyData company)
        {
            Log.Info("Accessing InvoiceRepo GetAll by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_all_by_company", pcol));
            }
        }

        public IEnumerable<InvoiceData> GetAll(AccountData account)
        {
            Log.Info("Accessing InvoiceRepo GetAll by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_all_by_account", pcol));
            }
        }
        public IEnumerable<InvoiceData> FindAll(int company_key, string pattern)
        {
            Log.Info("Accessing InvoiceRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", company_key),
                Mapper.BuildParam("@test_pattern", pattern)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_find", pcol));
            }
        }

        public IEnumerable<InvoiceData> GetAllOpen(CompanyData company)
        {
            Log.Info("Accessing InvoiceRepo GetAllOpen by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_open_by_company", pcol));
            }
        }

        public IEnumerable<InvoiceData> GetAllOpen(AccountData account)
        {
            Log.Info("Accessing InvoiceRepo GetAllOpen by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_open_by_account", pcol));
            }
        }

        public override InvoiceData GetByID(int invoice_key)
        {
            Log.Info("Accessing InvoiceRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_key", invoice_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_get", pcol));
            }
        }

        public override InvoiceData GetByCode(string invoice_code, string entity_code)
        {
            Log.Info("Accessing InvoiceRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@invoice_code", invoice_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_get_c", pcol));
            }
        }

        public override int Insert(InvoiceData entity)
        {
            Log.Info("Accessing InvoiceRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(InvoiceData entity)
        {
            Log.Info("Accessing InvoiceRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceData entity)
        {
            Log.Info("Accessing InvoiceRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing InvoiceRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing InvoiceRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_invoice_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(InvoiceData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_invoice_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}