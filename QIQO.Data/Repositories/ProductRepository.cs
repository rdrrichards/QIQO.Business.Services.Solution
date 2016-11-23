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
    public class ProductRepository : RepositoryBase<ProductData>, IProductRepository
    {
        private IMainDBContext entity_context;

        public ProductRepository(IMainDBContext dbc, IProductMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<ProductData> GetAll()
        {
            Log.Info("Accessing ProductRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_product_all");
                Log.Info("ProductRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<ProductData> GetAll(CompanyData company)
        {
            Log.Info("Accessing ProductRepo GetAll by CompanyData function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@company_key", company.CompanyKey) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_product_all_by_company", pcol);
                Log.Info("ProductRepo Passed ExecuteProcedureAsDataSet (usp_product_all_by_company) function");
                return MapRows(ds);
            }
        }

        public override ProductData GetByID(int product_key)
        {
            Log.Info("Accessing ProductRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@product_key", product_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_product_get", pcol);
                Log.Info("ProductRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_product_get) function");
                return MapRow(ds);
            }
        }

        public override ProductData GetByCode(string product_code, string entity_code)
        {
            Log.Info("Accessing ProductRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@product_code", product_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_product_get_c", pcol);
                Log.Info("ProductRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_product_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(ProductData entity)
        {
            Log.Info("Accessing ProductRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(ProductData entity)
        {
            Log.Info("Accessing ProductRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ProductData entity)
        {
            Log.Info("Accessing ProductRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing ProductRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@product_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing ProductRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(ProductData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_product_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}