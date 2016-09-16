using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface ITypeService
    {
        [OperationContract]
        List<AccountType> GetAccountTypeList();

        [OperationContract]
        List<AddressType> GetAddressTypeList();

        [OperationContract]
        List<AttributeType> GetAttributeTypeList();

        [OperationContract]
        List<AttributeType> GetAttributeTypeListByCategory(string category);

        [OperationContract]
        List<CommentType> GetCommentTypeList();

        [OperationContract]
        List<CommentType> GetCommentTypeListByCategory(string category);

        [OperationContract]
        List<ContactType> GetContactTypeList();

        [OperationContract]
        List<ContactType> GetContactTypeListByCategory(string category);

        [OperationContract]
        List<EntityType> GetEntityTypeList();

        [OperationContract]
        List<PersonType> GetPersonTypeList();

        [OperationContract]
        List<PersonType> GetPersonTypeListByCategory(string category);

        [OperationContract]
        List<ProductType> GetProductTypeList();

        [OperationContract]
        List<ProductType> GetProductTypeListByCategory(string category);

        [OperationContract]
        List<OrderStatus> GetOrderStatusList();

        [OperationContract]
        List<OrderItemStatus> GetOrderItemStatusList();

        [OperationContract]
        List<InvoiceStatus> GetInvoiceStatusList();

        [OperationContract]
        List<InvoiceItemStatus> GetInvoiceItemStatusList();
    }
}