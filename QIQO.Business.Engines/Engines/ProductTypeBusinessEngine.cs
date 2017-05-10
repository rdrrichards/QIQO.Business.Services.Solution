using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Caching;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QIQO.Business.Engines
{
    public class ProductTypeBusinessEngine : EngineBase, IProductTypeBusinessEngine
    {
        private readonly ICache _cache;
        private readonly IProductTypeRepository _report_prod_type;
        private readonly IProductTypeEntityService _prod_es;
        public ProductTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _report_prod_type = _data_repository_factory.GetDataRepository<IProductTypeRepository>();
            _prod_es = _entity_service_factory.GetEntityService<IProductTypeEntityService>();
        }

        public ProductType GetTypeByKey(int type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var product_types = _cache.Get(CacheKeys.ProductTypes) as List<ProductType>;
                if (product_types != null)
                    return product_types.Where(item => item.ProductTypeKey == type).FirstOrDefault();
                return GetTypes().Where(item => item.ProductTypeKey == type).FirstOrDefault();
            });
        }

        public List<ProductType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<ProductType> product_types = _cache.Get(CacheKeys.ProductTypes) as List<ProductType>;
                if (product_types == null)
                {
                    Log.Debug("ProductTypeRepository GetAll called");
                    product_types = new List<ProductType>();
                    var product_type_data = _report_prod_type.GetAll();

                    foreach (ProductTypeData account_type in product_type_data)
                    {
                        product_types.Add(_prod_es.Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.ProductTypes, product_types);
                    Log.Debug("ProductTypeRepository GetAll complete");
                }
                return product_types;
            });
        }

        public List<ProductType> GetTypesByCategory(string category)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var product_types = _cache.Get(CacheKeys.ProductTypes) as List<ProductType>;
                if (product_types != null)
                    return product_types.Where(item => item.ProductTypeCategory == category).ToList();
                return GetTypes().Where(item => item.ProductTypeCategory == category).ToList();
            });
        }
        public int AddOrUpdateType(ProductType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                return _report_prod_type.Insert(_prod_es.Map(type));
            });
        }

        public bool DeleteType(ProductType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                _report_prod_type.Delete(_prod_es.Map(type));
                return true;
            });
        }
        
    }
}