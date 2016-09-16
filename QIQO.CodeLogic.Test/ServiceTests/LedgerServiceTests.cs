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
    public class ChartOfAccountServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin", "QIQOCompanyAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void chart_of_account_update_existing()
        {
            ChartOfAccount newObject = new ChartOfAccount() { ChartOfAccountKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IChartOfAccountBusinessEngine>().ChartOfAccountSave(newObject)).Returns(123);

            LedgerService service = new LedgerService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateChartOfAccount(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void chart_of_account_insert_new()
        {
            ChartOfAccount newObject = new ChartOfAccount();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IChartOfAccountBusinessEngine>().ChartOfAccountSave(newObject)).Returns(123);

            LedgerService service = new LedgerService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateChartOfAccount(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
