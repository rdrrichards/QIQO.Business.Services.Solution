using System.ServiceModel;
using QIQO.Business.Entities;
using QIQO.Common.Core;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IEntityProductService
    {
        [OperationContract]
        List<EntityProduct> GetAllEntityProducts();

        [OperationContract]
        List<EntityProduct> GetEntityProducts(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateEntityProduct(EntityProduct product);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteEntityProduct(EntityProduct product);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        EntityProduct GetEntityProduct(int product_key);
    }
}
 