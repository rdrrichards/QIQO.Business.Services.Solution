using QIQO.Business.Entities;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        List<Product> GetProducts(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateProduct(Product product);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteProduct(Product product);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Product GetProduct(int product_key);
    }
}