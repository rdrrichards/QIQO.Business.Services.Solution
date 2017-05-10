using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System.Collections.Generic;

namespace QIQO.Business.Engines.Tests
{
    [TestClass()]
    public class OrderBusinessEngineTests
    {
        [TestMethod()]
        public void OrderSaveTest()
        {
            //Arrange
            var test_order = new Order() { OrderKey = 1, AccountKey = 1, OrderNumber = "TSTORDER0001" };
            test_order.OrderItems.Add(new OrderItem() { OrderItemKey = 1, OrderKey = 1, OrderItemQuantity = 1, OrderItemLineSum = 30M });
            var test_order_data = new OrderHeaderData() { OrderKey = 1, AccountKey = 1, OrderNum = "TSTORDER0001" };
            var test_order_item_data = new OrderItemData() { OrderKey = 1, OrderItemLineSum = 30M, OrderItemPricePer = 30M, OrderItemQuantity = 1 };
            var order_repo = new Mock<IOrderHeaderRepository>();
            var order_item_repo = new Mock<IOrderItemRepository>();
            var order_es = new Mock<IOrderEntityService>();
            var order_item_es = new Mock<IOrderItemEntityService>();
            var comment_be = new Mock<ICommentBusinessEngine>();

            var order_be = new Mock<IOrderBusinessEngine>();
            var repo_factory = new Mock<IDataRepositoryFactory>();
            var be_factory = new Mock<IBusinessEngineFactory>();
            var es_factory = new Mock<IEntityServiceFactory>();

            order_repo.Setup(mock => mock.Save(It.IsAny<OrderHeaderData>())).Returns(1);
            order_be.Setup(mock => mock.OrderSave(It.IsAny<Order>())).Returns(1);
            order_es.Setup(mock => mock.Map(It.IsAny<Order>())).Returns(test_order_data);
            order_es.Setup(mock => mock.Map(It.IsAny<Order>())).Returns(test_order_data);
            order_item_es.Setup(mock => mock.Map(It.IsAny<OrderItem>())).Returns(test_order_item_data);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderHeaderRepository>()).Returns(order_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderItemRepository>()).Returns(order_item_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IOrderBusinessEngine>()).Returns(order_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<ICommentBusinessEngine>()).Returns(comment_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IOrderEntityService>()).Returns(order_es.Object);
            es_factory.Setup(mock => mock.GetEntityService<IOrderItemEntityService>()).Returns(order_item_es.Object);

            OrderBusinessEngine account_business_engine = new OrderBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            int ret_val = account_business_engine.OrderSave(test_order);

            //Assert
            Assert.IsTrue(ret_val == 1);
        }

        [TestMethod()]
        public void GetOrderByCodeTest()
        {
            //Arrange
            var test_order = new Order() { OrderKey = 1, AccountKey = 1, OrderNumber = "TSTORDER0001" };
            test_order.OrderItems.Add(new OrderItem() { OrderItemKey = 1, OrderKey = 1, OrderItemQuantity = 1, OrderItemLineSum = 30M });
            var test_order_data = new OrderHeaderData() { OrderKey = 1, AccountKey = 1, OrderNum = "TSTORDER0001" };
            var test_order_item_data = new OrderItemData() { OrderKey = 1, OrderItemLineSum = 30M, OrderItemPricePer = 30M, OrderItemQuantity = 1 };
            Mock<IOrderHeaderRepository> order_repo = new Mock<IOrderHeaderRepository>();
            Mock<IOrderItemRepository> order_item_repo = new Mock<IOrderItemRepository>();
            Mock<IOrderEntityService> order_es = new Mock<IOrderEntityService>();

            Mock<IOrderBusinessEngine> order_be = new Mock<IOrderBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();

            Mock<IEmployeeBusinessEngine> emp_be = new Mock<IEmployeeBusinessEngine>();
            Mock<IOrderStatusBusinessEngine> ord_status_be = new Mock<IOrderStatusBusinessEngine>();

            order_repo.Setup(mock => mock.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_order_data);
            order_be.Setup(mock => mock.GetOrderByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_order);
            order_es.Setup(mock => mock.Map(It.IsAny<OrderHeaderData>())).Returns(test_order);
            //order_es.Setup(mock => mock.Map(It.IsAny<OrderItem>())).Returns(test_order_item_data);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderHeaderRepository>()).Returns(order_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderItemRepository>()).Returns(order_item_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IOrderBusinessEngine>()).Returns(order_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEmployeeBusinessEngine>()).Returns(emp_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IOrderStatusBusinessEngine>()).Returns(ord_status_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IOrderEntityService>()).Returns(order_es.Object);

            OrderBusinessEngine order_business_engine = new OrderBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            Order ret_val = order_business_engine.GetOrderByCode("TSTORDER0001", "TEST");

            //Assert
            Assert.IsTrue(ret_val.OrderNumber == test_order.OrderNumber);
        }

        [TestMethod()]
        public void GetOpenOrdersByCompanyTest()
        {
            //Arrange
            List<Order> orders = new List<Order>() {
                new Order() { OrderKey = 1, AccountKey = 1, OrderNumber = "TSTORDER0001" },
                new Order() { OrderKey = 2, AccountKey = 1, OrderNumber = "TSTORDER0002" },
                new Order() { OrderKey = 3, AccountKey = 1, OrderNumber = "TSTORDER0003" }
            };
            List<OrderHeaderData> order_headers = new List<OrderHeaderData>() {
                new OrderHeaderData() { OrderKey = 1, AccountKey = 1, OrderNum = "TSTORDER0001" },
                new OrderHeaderData() { OrderKey = 2, AccountKey = 1, OrderNum = "TSTORDER0002" },
                new OrderHeaderData() { OrderKey = 3, AccountKey = 1, OrderNum = "TSTORDER0003" }
            };
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            var test_order = new Order() { OrderKey = 1, AccountKey = 1, OrderNumber = "TSTORDER0001" };
            test_order.OrderItems.Add(new OrderItem() { OrderItemKey = 1, OrderKey = 1, OrderItemQuantity = 1, OrderItemLineSum = 30M });
            Mock<IOrderHeaderRepository> order_repo = new Mock<IOrderHeaderRepository>();
            Mock<IOrderItemRepository> order_item_repo = new Mock<IOrderItemRepository>();
            Mock<IOrderEntityService> order_es = new Mock<IOrderEntityService>();

            Mock<IOrderBusinessEngine> order_be = new Mock<IOrderBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();

            Mock<IEmployeeBusinessEngine> emp_be = new Mock<IEmployeeBusinessEngine>();
            Mock<IOrderStatusBusinessEngine> ord_status_be = new Mock<IOrderStatusBusinessEngine>();
            Mock<IAccountBusinessEngine> account_be = new Mock<IAccountBusinessEngine>();

            order_repo.Setup(mock => mock.GetAllOpen(It.IsAny<CompanyData>())).Returns(order_headers);
            order_be.Setup(mock => mock.GetOpenOrdersByCompany(It.IsAny<Company>())).Returns(orders);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderHeaderRepository>()).Returns(order_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderItemRepository>()).Returns(order_item_repo.Object);
            order_es.Setup(mock => mock.Map(It.IsAny<OrderHeaderData>())).Returns(test_order);
            be_factory.Setup(mock => mock.GetBusinessEngine<IOrderBusinessEngine>()).Returns(order_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEmployeeBusinessEngine>()).Returns(emp_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IOrderStatusBusinessEngine>()).Returns(ord_status_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()).Returns(account_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IOrderEntityService>()).Returns(order_es.Object);

            OrderBusinessEngine order_business_engine = new OrderBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            List<Order> ret_val = order_business_engine.GetOpenOrdersByCompany(test_comp);

            //Assert
            Assert.IsTrue(ret_val.Count == 3);
        }

        [TestMethod()]
        public void GetOpenOrdersByAccountTest()
        {
            //Arrange
            List<Order> orders = new List<Order>() {
                new Order() { OrderKey = 1, AccountKey = 1, OrderNumber = "TSTORDER0001" },
                new Order() { OrderKey = 2, AccountKey = 1, OrderNumber = "TSTORDER0002" },
                new Order() { OrderKey = 3, AccountKey = 1, OrderNumber = "TSTORDER0003" }
            };
            List<OrderHeaderData> order_headers = new List<OrderHeaderData>() {
                new OrderHeaderData() { OrderKey = 1, AccountKey = 1, OrderNum = "TSTORDER0001" },
                new OrderHeaderData() { OrderKey = 2, AccountKey = 1, OrderNum = "TSTORDER0002" },
                new OrderHeaderData() { OrderKey = 3, AccountKey = 1, OrderNum = "TSTORDER0003" }
            };
            AccountData test_acct_data = new AccountData() { CompanyKey = 1, AccountKey = 1, AccountCode = "TEST" };
            Account test_acct = new Account() { CompanyKey = 1, AccountKey = 1, AccountCode = "TEST" };
            var test_order = new Order() { OrderKey = 1, AccountKey = 1, OrderNumber = "TSTORDER0001" };
            test_order.OrderItems.Add(new OrderItem() { OrderItemKey = 1, OrderKey = 1, OrderItemQuantity = 1, OrderItemLineSum = 30M });
            Mock<IOrderHeaderRepository> order_repo = new Mock<IOrderHeaderRepository>();
            Mock<IOrderItemRepository> order_item_repo = new Mock<IOrderItemRepository>();
            Mock<IOrderEntityService> order_es = new Mock<IOrderEntityService>();

            Mock<IOrderBusinessEngine> order_be = new Mock<IOrderBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();

            Mock<IEmployeeBusinessEngine> emp_be = new Mock<IEmployeeBusinessEngine>();
            Mock<IOrderStatusBusinessEngine> ord_status_be = new Mock<IOrderStatusBusinessEngine>();
            Mock<IAccountBusinessEngine> account_be = new Mock<IAccountBusinessEngine>();

            order_repo.Setup(mock => mock.GetAllOpen(It.IsAny<AccountData>())).Returns(order_headers);
            order_be.Setup(mock => mock.GetOpenOrdersByAccount(It.IsAny<Account>())).Returns(orders);
            order_es.Setup(mock => mock.Map(It.IsAny<OrderHeaderData>())).Returns(test_order);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderHeaderRepository>()).Returns(order_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IOrderItemRepository>()).Returns(order_item_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IOrderBusinessEngine>()).Returns(order_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEmployeeBusinessEngine>()).Returns(emp_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IOrderStatusBusinessEngine>()).Returns(ord_status_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()).Returns(account_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IOrderEntityService>()).Returns(order_es.Object);

            OrderBusinessEngine order_business_engine = new OrderBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            List<Order> ret_val = order_business_engine.GetOpenOrdersByAccount(test_acct);

            //Assert
            Assert.IsTrue(ret_val.Count == 3);
        }
    }
}