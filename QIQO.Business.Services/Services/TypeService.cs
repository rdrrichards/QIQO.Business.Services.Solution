using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TypeService : ServiceBase, ITypeService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public TypeService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        public List<AccountType> GetAccountTypeList()
        {
            IAccountTypeBusinessEngine account_type_be = _business_engine_factory.GetBusinessEngine<IAccountTypeBusinessEngine>();
            return account_type_be.GetTypes();
        }

        public List<AddressType> GetAddressTypeList()
        {
            IAddressTypeBusinessEngine address_type_be = _business_engine_factory.GetBusinessEngine<IAddressTypeBusinessEngine>();
            return address_type_be.GetTypes();
        }

        public List<AttributeType> GetAttributeTypeList()
        {
            IAttributeTypeBusinessEngine attribute_type_be = _business_engine_factory.GetBusinessEngine<IAttributeTypeBusinessEngine>();
            return attribute_type_be.GetTypes();
        }

        public List<AttributeType> GetAttributeTypeListByCategory(string category)
        {
            IAttributeTypeBusinessEngine attribute_type_be = _business_engine_factory.GetBusinessEngine<IAttributeTypeBusinessEngine>();
            return attribute_type_be.GetTypesByCategory(category);
        }

        public List<CommentType> GetCommentTypeList()
        {
            ICommentTypeBusinessEngine comment_type_be = _business_engine_factory.GetBusinessEngine<ICommentTypeBusinessEngine>();
            return comment_type_be.GetTypes();
        }

        public List<CommentType> GetCommentTypeListByCategory(string category)
        {
            ICommentTypeBusinessEngine comment_type_be = _business_engine_factory.GetBusinessEngine<ICommentTypeBusinessEngine>();
            return comment_type_be.GetTypesByCategory(category);
        }

        public List<ContactType> GetContactTypeList()
        {
            IContactTypeBusinessEngine contact_type_be = _business_engine_factory.GetBusinessEngine<IContactTypeBusinessEngine>();
            return contact_type_be.GetTypes();
        }

        public List<ContactType> GetContactTypeListByCategory(string category)
        {
            IContactTypeBusinessEngine contact_type_be = _business_engine_factory.GetBusinessEngine<IContactTypeBusinessEngine>();
            return contact_type_be.GetTypesByCategory(category);
        }

        public List<EntityType> GetEntityTypeList()
        {
            IEntityTypeBusinessEngine entity_type_be = _business_engine_factory.GetBusinessEngine<IEntityTypeBusinessEngine>();
            return entity_type_be.GetTypes();
        }

        public List<InvoiceItemStatus> GetInvoiceItemStatusList()
        {
            throw new NotImplementedException();
        }

        public List<InvoiceStatus> GetInvoiceStatusList()
        {
            throw new NotImplementedException();
        }

        public List<OrderItemStatus> GetOrderItemStatusList()
        {
            IOrderItemStatusBusinessEngine order_item_status_be = _business_engine_factory.GetBusinessEngine<IOrderItemStatusBusinessEngine>();
            return order_item_status_be.GetStatuses();
        }

        public List<OrderStatus> GetOrderStatusList()
        {
            IOrderStatusBusinessEngine order_status_be = _business_engine_factory.GetBusinessEngine<IOrderStatusBusinessEngine>();
            return order_status_be.GetStatuses();
        }

        public List<PersonType> GetPersonTypeList()
        {
            IPersonTypeBusinessEngine person_type_be = _business_engine_factory.GetBusinessEngine<IPersonTypeBusinessEngine>();
            return person_type_be.GetTypes();
        }

        public List<PersonType> GetPersonTypeListByCategory(string category)
        {
            IPersonTypeBusinessEngine person_type_be = _business_engine_factory.GetBusinessEngine<IPersonTypeBusinessEngine>();
            return person_type_be.GetTypesByCategory(category);
        }

        public List<ProductType> GetProductTypeList()
        {
            IProductTypeBusinessEngine product_type_be = _business_engine_factory.GetBusinessEngine<IProductTypeBusinessEngine>();
            return product_type_be.GetTypes();
        }

        public List<ProductType> GetProductTypeListByCategory(string category)
        {
            IProductTypeBusinessEngine product_type_be = _business_engine_factory.GetBusinessEngine<IProductTypeBusinessEngine>();
            return product_type_be.GetTypesByCategory(category);
        }
    }
}