using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Business.Services;
using QIQO.Common.Contracts;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;

namespace QIQO.CodeLogic.Test
{
    [TestClass]
    public class TypeServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void type_account_type_get_list_returns_account_types_in_list()
        {
            List<AccountType> newTypeList = new List<AccountType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<AccountType> lookup_ret_val = service.GetAccountTypeList();

            Assert.IsTrue(lookup_ret_val is List<AccountType>);
        }

        [TestMethod]
        public void type_address_type_get_list_returns_address_types_in_list()
        {
            List<AddressType> newTypeList = new List<AddressType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<AddressType> lookup_ret_val = service.GetAddressTypeList();

            Assert.IsTrue(lookup_ret_val is List<AddressType>);
        }

        [TestMethod]
        public void type_attribute_type_get_list_returns_attribute_types_in_list()
        {
            List<AttributeType> newTypeList = new List<AttributeType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAttributeTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<AttributeType> lookup_ret_val = service.GetAttributeTypeList();

            Assert.IsTrue(lookup_ret_val is List<AttributeType>);
        }

        [TestMethod]
        public void type_attribute_type_by_category_get_list_returns_attribute_types_in_list()
        {
            List<AttributeType> newTypeList = new List<AttributeType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAttributeTypeBusinessEngine>()
                .GetTypesByCategory("Dummy")).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<AttributeType> lookup_ret_val = service.GetAttributeTypeListByCategory("Dummy");

            Assert.IsTrue(lookup_ret_val is List<AttributeType>);
        }

        [TestMethod]
        public void type_comment_type_get_list_returns_comment_types_in_list()
        {
            List<CommentType> newTypeList = new List<CommentType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<ICommentTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<CommentType> lookup_ret_val = service.GetCommentTypeList();

            Assert.IsTrue(lookup_ret_val is List<CommentType>);
        }

        [TestMethod]
        public void type_comment_type_by_category_get_list_returns_comment_types_in_list()
        {
            List<CommentType> newTypeList = new List<CommentType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<ICommentTypeBusinessEngine>()
                .GetTypesByCategory("Dummy")).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<CommentType> lookup_ret_val = service.GetCommentTypeListByCategory("Dummy");

            Assert.IsTrue(lookup_ret_val is List<CommentType>);
        }

        [TestMethod]
        public void type_contact_type_get_list_returns_contact_types_in_list()
        {
            List<ContactType> newTypeList = new List<ContactType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IContactTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<ContactType> lookup_ret_val = service.GetContactTypeList();

            Assert.IsTrue(lookup_ret_val is List<ContactType>);
        }

        [TestMethod]
        public void type_contact_type_by_category_get_list_returns_contact_types_in_list()
        {
            List<ContactType> newTypeList = new List<ContactType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IContactTypeBusinessEngine>()
                .GetTypesByCategory("Dummy")).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<ContactType> lookup_ret_val = service.GetContactTypeListByCategory("Dummy");

            Assert.IsTrue(lookup_ret_val is List<ContactType>);
        }

        [TestMethod]
        public void type_entity_type_get_list_returns_entity_types_in_list()
        {
            List<EntityType> newTypeList = new List<EntityType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IEntityTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<EntityType> lookup_ret_val = service.GetEntityTypeList();

            Assert.IsTrue(lookup_ret_val is List<EntityType>);
        }

        [TestMethod]
        public void type_invoice_item_status_get_list_returns_invoice_item_stautses_in_list()
        {
            //List<InvoiceItemStatus> newTypeList = new List<InvoiceItemStatus>();

            //Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            //mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IInvoiceBusinessEngine>().GetStatuses()).Returns(newTypeList);

            //TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            //List<InvoiceItemStatus> lookup_ret_val = service.GetInvoiceItemStatusList();

            //Assert.IsTrue(lookup_ret_val is List<InvoiceItemStatus>);
        }

        [TestMethod]
        public void type_invoice_status_get_list_returns_invoice_stautses_in_list()
        {
            //List<AccountType> newTypeList = new List<AccountType>();

            //Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            //mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            //TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            //List<AccountType> lookup_ret_val = service.GetAccountTypeList();

            //Assert.IsTrue(lookup_ret_val is List<AccountType>);
        }

        [TestMethod]
        public void type_order_item_status_get_list_returns_order_item_stautses_in_list()
        {
            List<OrderItemStatus> newTypeList = new List<OrderItemStatus>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IOrderItemStatusBusinessEngine>().GetStatuses()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<OrderItemStatus> lookup_ret_val = service.GetOrderItemStatusList();

            Assert.IsTrue(lookup_ret_val is List<OrderItemStatus>);
        }

        [TestMethod]
        public void type_order_status_get_list_returns_order_stautses_in_list()
        {
            List<OrderStatus> newTypeList = new List<OrderStatus>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IOrderStatusBusinessEngine>().GetStatuses()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<OrderStatus> lookup_ret_val = service.GetOrderStatusList();

            Assert.IsTrue(lookup_ret_val is List<OrderStatus>);
        }

        [TestMethod]
        public void type_person_type_get_list_returns_person_types_in_list()
        {
            List<PersonType> newTypeList = new List<PersonType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IPersonTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<PersonType> lookup_ret_val = service.GetPersonTypeList();

            Assert.IsTrue(lookup_ret_val is List<PersonType>);
        }

        [TestMethod]
        public void type_person_type_get_list_by_category_returns_person_types_in_list()
        {
            List<PersonType> newTypeList = new List<PersonType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IPersonTypeBusinessEngine>()
                .GetTypesByCategory("Dummy")).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<PersonType> lookup_ret_val = service.GetPersonTypeListByCategory("Dummy");

            Assert.IsTrue(lookup_ret_val is List<PersonType>);
        }

        [TestMethod]
        public void type_product_type_get_list_returns_product_types_in_list()
        {
            List<ProductType> newTypeList = new List<ProductType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>().GetTypes()).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<ProductType> lookup_ret_val = service.GetProductTypeList();

            Assert.IsTrue(lookup_ret_val is List<ProductType>);
        }

        [TestMethod]
        public void type_product_type_get_list_by_category_returns_product_types_in_list()
        {
            List<ProductType> newTypeList = new List<ProductType>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>()
                .GetTypesByCategory("Dummy")).Returns(newTypeList);

            TypeService service = new TypeService(mockBusinessEngineFactory.Object);

            List<ProductType> lookup_ret_val = service.GetProductTypeListByCategory("Dummy");

            Assert.IsTrue(lookup_ret_val is List<ProductType>);
        }

    }
}
