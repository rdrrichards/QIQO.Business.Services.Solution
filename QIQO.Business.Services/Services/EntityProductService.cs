using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class EntityProductService : ServiceBase, IEntityProductService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public EntityProductService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        public int CreateEntityProduct(EntityProduct product)
        {
            IEntityProductBusinessEngine entity_product_be = _business_engine_factory.GetBusinessEngine<IEntityProductBusinessEngine>();
            return entity_product_be.EntityProductSave(product);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        public bool DeleteEntityProduct(EntityProduct product)
        {
            IEntityProductBusinessEngine entity_product_be = _business_engine_factory.GetBusinessEngine<IEntityProductBusinessEngine>();
            return entity_product_be.EntityProductDelete(product);
        }

        public List<EntityProduct> GetAllEntityProducts()
        {
            IEntityProductBusinessEngine entity_product_be = _business_engine_factory.GetBusinessEngine<IEntityProductBusinessEngine>();
            return entity_product_be.GetAllEntityProducts();
        }

        public EntityProduct GetEntityProduct(int product_key)
        {
            IEntityProductBusinessEngine entity_product_be = _business_engine_factory.GetBusinessEngine<IEntityProductBusinessEngine>();
            return entity_product_be.GetEntityProductByID(product_key);
        }

        public List<EntityProduct> GetEntityProducts(Company company)
        {
            IEntityProductBusinessEngine entity_product_be = _business_engine_factory.GetBusinessEngine<IEntityProductBusinessEngine>();
            return entity_product_be.GetEntityProductsByEntity(company.CompanyKey, QIQOEntityType.Company);
        }
    }
}