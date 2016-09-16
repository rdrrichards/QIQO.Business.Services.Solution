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
    public class OrderServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void order_update_existing()
        {
            Order newObject = new Order() { OrderKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IOrderBusinessEngine>().OrderSave(newObject)).Returns(123);

            OrderService service = new OrderService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateOrder(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void order_insert_new()
        {
            Order newObject = new Order();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IOrderBusinessEngine>().OrderSave(newObject)).Returns(123);

            OrderService service = new OrderService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateOrder(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
