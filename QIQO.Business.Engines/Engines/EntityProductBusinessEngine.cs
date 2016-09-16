using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Engines
{
    public class EntityProductBusinessEngine : EngineBase, IEntityProductBusinessEngine
    {

        private readonly IEntityProductRepository _entity_product_repo;
        private readonly IProductRepository _prod_repository;
        private readonly IProductTypeBusinessEngine _prod_type_be;
        private readonly IEntityTypeBusinessEngine _entity_type_be;
        private readonly IEntityProductEntityService _ent_prod_es;

        public EntityProductBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _entity_product_repo = _data_repository_factory.GetDataRepository<IEntityProductRepository>();
            _prod_repository = _data_repository_factory.GetDataRepository<IProductRepository>();
            _prod_type_be = _business_engine_factory.GetBusinessEngine<IProductTypeBusinessEngine>();
            _entity_type_be = _business_engine_factory.GetBusinessEngine<IEntityTypeBusinessEngine>();
            _ent_prod_es = _entity_service_factory.GetEntityService<IEntityProductEntityService>();
        }

        public bool EntityProductDelete(EntityProduct entity_product)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var entity_product_data = _ent_prod_es.Map(entity_product);
                _entity_product_repo.Delete(entity_product_data);
                return true;
            });
        }

        public int EntityProductSave(EntityProduct entity_product)
        {
            if (entity_product == null)
                throw new ArgumentNullException(nameof(entity_product));

            return ExecuteFaultHandledOperation(() =>
            {
                var prod_data = _ent_prod_es.Map(entity_product);
                return _entity_product_repo.Insert(prod_data);
            });
        }

        public EntityProduct GetEntityProductByCode(string entity_product_code, Company company)
        {
            return GetEntityProductByCode(entity_product_code, company.CompanyCode);
        }

        public EntityProduct GetEntityProductByCode(string entity_product_code, string company_code)
        {
            Log.Info("Accessing EntityProductBusinessEngine GetEntityProductByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                var entity_product_data = _entity_product_repo.GetByCode(entity_product_code, company_code);
                Log.Info("EntityProductBusinessEngine GetEntityProductByCode function completed");

                if (entity_product_data.EntityProductKey != 0)
                {
                    var prod_data = _prod_repository.GetByID(entity_product_data.ProductKey);
                    return Map(entity_product_data, prod_data);
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("EntityProduct with code {0} is not in database", entity_product_code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public EntityProduct GetEntityProductByID(int entity_product_key)
        {
            Log.Info("Accessing EntityProductBusinessEngine GetEntityProductByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var entity_product_data = _entity_product_repo.GetByID(entity_product_key);
                Log.Info("EntityProductBusinessEngine GetByID function completed");

                if (entity_product_data.EntityProductKey != 0)
                {
                    var prod_data = _prod_repository.GetByID(entity_product_data.ProductKey);
                    return Map(entity_product_data, prod_data);
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("EntityProduct with key {0} is not in database", entity_product_key));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<EntityProduct> GetAllEntityProducts()
        { 
            List<EntityProduct> products = new List<EntityProduct>();

            return ExecuteFaultHandledOperation(() =>
            {
                IEntityProductRepository entity_product_repo = _data_repository_factory.GetDataRepository<IEntityProductRepository>();
                IProductRepository prod_repository = _data_repository_factory.GetDataRepository<IProductRepository>();
                IEnumerable<EntityProductData> entity_prods = entity_product_repo.GetAll();

                foreach (EntityProductData entity_prod in entity_prods)
                {
                    ProductData prod_data = prod_repository.GetByID(entity_prod.ProductKey);
                    products.Add(Map(entity_prod, prod_data));
                }
                return products;
            });
        }

        public List<EntityProduct> GetEntityProductsByEntity(int entity_key, QIQOEntityType entity_type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IEntityProductRepository entity_product_repo = _data_repository_factory.GetDataRepository<IEntityProductRepository>();
                IProductRepository product_repo = _data_repository_factory.GetDataRepository<IProductRepository>();
                List<EntityProduct> entity_products = new List<EntityProduct>();

                IEnumerable<EntityProductData> entity_products_data = entity_product_repo.GetAll(entity_key, (int)entity_type);

                foreach (EntityProductData entity_product_data in entity_products_data)
                {
                    ProductData product_data = product_repo.GetByID(entity_product_data.ProductKey);
                    EntityProduct entity_product = Map(entity_product_data, product_data);
                    entity_products.Add(entity_product);
                }
                return entity_products;
            });
        }

        private EntityProduct Map(EntityProductData entity_product_data, ProductData product_data)
        {
            var product = _ent_prod_es.Map(entity_product_data, product_data);
            product.ProductTypeData = _prod_type_be.GetTypeByKey(product_data.ProductTypeKey);
            product.EntityProductEntityTypeData = _entity_type_be.GetTypeByKey(entity_product_data.EntityTypeKey);
            return product;
        }
    }
}