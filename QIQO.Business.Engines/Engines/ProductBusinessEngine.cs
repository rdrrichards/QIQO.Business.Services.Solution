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
    public class ProductBusinessEngine : EngineBase, IProductBusinessEngine
    {
        private readonly IProductRepository _product_repo;
        private readonly IProductTypeBusinessEngine _prod_type_be;
        private readonly IEntityAttributeBusinessEngine _attrib_be;
        private readonly IProductEntityService _prod_es;
        public ProductBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _product_repo = _data_repository_factory.GetDataRepository<IProductRepository>();
            _attrib_be = _business_engine_factory.GetBusinessEngine<IEntityAttributeBusinessEngine>();
            _prod_type_be = _business_engine_factory.GetBusinessEngine<IProductTypeBusinessEngine>();
            _prod_es = _entity_service_factory.GetEntityService<IProductEntityService>();
        }

        public Product GetProductByCode(string product_code, Company company)
        {
            return GetProductByCode(product_code, company.CompanyCode);
        }

        public Product GetProductByCode(string product_code, string company_code)
        {
            Log.Info("Accessing ProductBusinessEngine GetProductByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                var product_data = _product_repo.GetByCode(product_code, company_code);
                Log.Info("ProductBusinessEngine GetProductByCode function completed");

                if (product_data.ProductKey != 0)
                {
                    Product product = Map(product_data);
                    return product;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Product with code {0} is not in database", product_code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }
        public Product GetProductByID(int product_key)
        {
            Log.Info("Accessing ProductBusinessEngine GetProductByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var product_data = _product_repo.GetByID(product_key);
                Log.Info("ProductBusinessEngine GetByID function completed");

                if (product_data.ProductKey != 0)
                {
                    var product = Map(product_data);
                    product.ProductAttributes = _attrib_be.GetAttributeByEntity(product.ProductKey, QIQOEntityType.Product);
                    return product;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Product with key {0} is not in database", product_key));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<Product> GetProductsByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var products = new List<Product>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };
                var products_data = _product_repo.GetAll(comp);

                foreach (ProductData product_data in products_data)
                {
                    Product product = Map(product_data);
                    product.ProductAttributes = _attrib_be.GetAttributeByEntity(product.ProductKey, QIQOEntityType.Product);
                    products.Add(product);
                }
                return products;
            });
        }

        public bool ProductDelete(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return ExecuteFaultHandledOperation(() =>
            {
                var product_data = _prod_es.Map(product);

                if (product.ProductAttributes != null)
                {
                    Log.Info("Account attributes to be deleted -> {0}", product.ProductAttributes.Count);
                    foreach (EntityAttribute attribute in product.ProductAttributes)
                    {
                        try
                        {
                            bool ret_value = _attrib_be.EntityAttributeDelete(attribute);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error deleting product attribute data from the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                _product_repo.Delete(product_data);
                return true;
            });
        }

        public int ProductSave(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return ExecuteFaultHandledOperation(() =>
            {
                var prod_data = _prod_es.Map(product);
                int product_key = _product_repo.Save(prod_data);

                if (product.ProductAttributes != null)
                {
                    Log.Info("Product attributes to be saved -> {0}", product.ProductAttributes.Count);
                    foreach (EntityAttribute attribute in product.ProductAttributes)
                    {
                        try
                        {
                            attribute.EntityKey = product_key;
                            attribute.EntityType = QIQOEntityType.Product;
                            int attr_key = _attrib_be.EntityAttributeUpdate(attribute);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Error saving product attribute data to the database");
                            Log.Error($"{ex.Source}:{ex.Message}");
                            throw ex;
                        }
                    }
                }

                return product_key;
            });
        }

        private Product Map(ProductData product_data)
        {
            var product = _prod_es.Map(product_data);
            product.ProductTypeData = _prod_type_be.GetTypeByKey(product_data.ProductTypeKey);
            return product;
        }
    }
}