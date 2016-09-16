using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;

namespace QIQO.Business.Contracts
{
    public interface IEntityProductEntityService : IEntityService
    {
        EntityProductData Map(EntityProduct entity_product);
        EntityProduct Map(EntityProductData entity_product_data, ProductData product_data);
    }
}