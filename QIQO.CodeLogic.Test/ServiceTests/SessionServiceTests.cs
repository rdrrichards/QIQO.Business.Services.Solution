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
    public class UserSessionServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void session_update_existing()
        {
            UserSession newObject = new UserSession() { SessionID = "Dummy"};

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IUserSessionBusinessEngine>()
                .UserSessionSave(newObject)).Returns(123);

            SessionService service = new SessionService(mockBusinessEngineFactory.Object);

            service.RegisterSession(123,"RDRRL7", "RDRRL7", "Richard Richards", 1);

            //Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void session_insert_new()
        {
            UserSession newObject = new UserSession();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IUserSessionBusinessEngine>().UserSessionSave(newObject)).Returns(123);

            SessionService service = new SessionService(mockBusinessEngineFactory.Object);

            service.RegisterSession(666, "RDRRL7", "RDRRL7", "Richard Richards", 1);

            //Assert.IsTrue(update_ret_val == 123);
        }
    }
}
