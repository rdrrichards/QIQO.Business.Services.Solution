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
    public class ProductServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOProductAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void product_update_existing()
        {
            Product newObject = new Product() { ProductKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>().ProductSave(newObject)).Returns(123);

            ProductService service = new ProductService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateProduct(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void product_insert_new()
        {
            Product newObject = new Product();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>().ProductSave(newObject)).Returns(123);

            ProductService service = new ProductService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateProduct(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
