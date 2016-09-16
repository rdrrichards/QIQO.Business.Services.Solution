using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class ProductService : ServiceBase, IProductService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public ProductService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOProductAdminRole)]
        public int CreateProduct(Product product)
        {
            IProductBusinessEngine product_be = _business_engine_factory.GetBusinessEngine<IProductBusinessEngine>();
            return product_be.ProductSave(product);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOProductAdminRole)]
        public bool DeleteProduct(Product product)
        {
            IProductBusinessEngine product_be = _business_engine_factory.GetBusinessEngine<IProductBusinessEngine>();
            return product_be.ProductDelete(product);
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int product_key)
        {
            IProductBusinessEngine product_be = _business_engine_factory.GetBusinessEngine<IProductBusinessEngine>();
            return product_be.GetProductByID(product_key);
        }

        public List<Product> GetProducts(Company company)
        {
            IProductBusinessEngine product_be = _business_engine_factory.GetBusinessEngine<IProductBusinessEngine>();
            return product_be.GetProductsByCompany(company);
        }
    }
}