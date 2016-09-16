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
    public class EntityProductServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void entity_product_update_existing()
        {
            EntityProduct newObject = new EntityProduct() { EntityProductKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IEntityProductBusinessEngine>().EntityProductSave(newObject)).Returns(123);

            EntityProductService service = new EntityProductService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateEntityProduct(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void entity_product_insert_new()
        {
            EntityProduct newObject = new EntityProduct();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IEntityProductBusinessEngine>().EntityProductSave(newObject)).Returns(123);

            EntityProductService service = new EntityProductService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateEntityProduct(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
