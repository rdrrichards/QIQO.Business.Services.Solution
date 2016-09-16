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
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_all");
                Log.Info("InvoiceRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<InvoiceData> GetAll(CompanyData company)
        {
            Log.Info("Accessing InvoiceRepo GetAll by CompanyData function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_all_by_company", pcol);
                Log.Info("InvoiceRepo Passed ExecuteProcedureAsDataSet (usp_invoice_all_by_company) function");
                return MapRows(ds);
            }
        }

        public IEnumerable<InvoiceData> GetAll(AccountData account)
        {
            Log.Info("Accessing InvoiceRepo GetAll by AccountData function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@account_key", account.AccountKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_all_by_account", pcol);
                Log.Info("InvoiceRepo Passed ExecuteProcedureAsDataSet (usp_invoice_all_by_account) function");
                return MapRows(ds);
            }
        }
        public IEnumerable<InvoiceData> FindAll(int company_key, string pattern)
        {
            Log.Info("Accessing InvoiceRepo GetAll function");
            using (entity_context)
            {
                List<SqlParameter> pcol = new List<SqlParameter>() {
                    new SqlParameter("@company_key", company_key),
                    new SqlParameter("@test_pattern", pattern)
                };
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_find", pcol);
                Log.Info("InvoiceRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<InvoiceData> GetAllOpen(CompanyData company)
        {
            Log.Info("Accessing InvoiceRepo GetAllOpen by CompanyData function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_open_by_company", pcol);
                Log.Info("InvoiceRepo Passed ExecuteProcedureAsDataSet (usp_invoice_open_by_company) function");

                List<InvoiceData> rows = new List<InvoiceData>();
                return MapRows(ds);
            }
        }

        public IEnumerable<InvoiceData> GetAllOpen(AccountData account)
        {
            Log.Info("Accessing InvoiceRepo GetAllOpen by AccountData function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@account_key", account.AccountKey) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_open_by_account", pcol);
                Log.Info("InvoiceRepo Passed ExecuteProcedureAsDataSet (usp_invoice_open_by_account) function");
                return MapRows(ds);
            }
        }

        public override InvoiceData GetByID(int invoice_key)
        {
            Log.Info("Accessing InvoiceRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@invoice_key", invoice_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_get", pcol);
                Log.Info("InvoiceRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_invoice_get) function");
                return MapRow(ds);
            }
        }

        public override InvoiceData GetByCode(string invoice_code, string entity_code)
        {
            Log.Info("Accessing InvoiceRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@invoice_code", invoice_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_invoice_get_c", pcol);
                Log.Info("InvoiceRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_invoice_get_c) function");
                return MapRow(ds);
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
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@invoice_code", entity_code) };
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