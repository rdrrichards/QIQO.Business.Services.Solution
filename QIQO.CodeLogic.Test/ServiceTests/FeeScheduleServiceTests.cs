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
    public class FeeScheduleServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin", "QIQOCompanyAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void fee_schedule_update_existing()
        {
            FeeSchedule newObject = new FeeSchedule() { FeeScheduleKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IFeeScheduleBusinessEngine>().FeeScheduleSave(newObject)).Returns(123);

            FeeScheduleService service = new FeeScheduleService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateFeeSchedule(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void fee_schedule_insert_new()
        {
            FeeSchedule newObject = new FeeSchedule();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IFeeScheduleBusinessEngine>().FeeScheduleSave(newObject)).Returns(123);

            FeeScheduleService service = new FeeScheduleService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateFeeSchedule(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
