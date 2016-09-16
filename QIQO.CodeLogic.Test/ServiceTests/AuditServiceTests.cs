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
    public class AuditServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void audit_update_existing()
        {
            AuditLog newAudit = new AuditLog() { AuditLogKey = 123 };
            
            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAuditLogBusinessEngine>().AuditLogSave(newAudit)).Returns(123);
            
            AuditService service = new AuditService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateAuditLog(newAudit);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void audit_insert_new()
        {
            AuditLog newAudit = new AuditLog();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAuditLogBusinessEngine>().AuditLogSave(newAudit)).Returns(123);

            AuditService service = new AuditService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateAuditLog(newAudit);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void audit_get_audit_by_id_that_is_valid_returns_audit()
        {
            List<AuditLog> newAudit = new List<AuditLog>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAuditLogBusinessEngine>()
                .GetAuditLogBusinessObject("Blah")).Returns(newAudit);

            AuditService service = new AuditService(mockBusinessEngineFactory.Object);

            List<AuditLog> lookup_ret_val = service.GetAuditLogByBusinessObject("Blah");

            Assert.IsTrue(lookup_ret_val is List<AuditLog>);
        }

    }
}
