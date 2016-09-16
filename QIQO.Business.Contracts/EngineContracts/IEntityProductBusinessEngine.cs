using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IEntityProductBusinessEngine : IBusinessEngine
    {
        bool EntityProductDelete(EntityProduct entity_product);
        int EntityProductSave(EntityProduct entity_product);
        EntityProduct GetEntityProductByCode(string entity_product_code, Company company);
        EntityProduct GetEntityProductByCode(string entity_product_code, string company_code);
        EntityProduct GetEntityProductByID(int entity_product_key);
        List<EntityProduct> GetEntityProductsByEntity(int entity_key, QIQOEntityType entity_type);
        List<EntityProduct> GetAllEntityProducts();
    }
}