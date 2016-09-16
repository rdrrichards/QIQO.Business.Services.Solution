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
    public class InvoiceServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOInvoiceEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void invoice_update_existing()
        {
            Invoice newObject = new Invoice() { InvoiceKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IInvoiceBusinessEngine>().InvoiceSave(newObject)).Returns(123);

            InvoiceService service = new InvoiceService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateInvoice(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void invoice_insert_new()
        {
            Invoice newObject = new Invoice();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IInvoiceBusinessEngine>().InvoiceSave(newObject)).Returns(123);

            InvoiceService service = new InvoiceService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateInvoice(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
