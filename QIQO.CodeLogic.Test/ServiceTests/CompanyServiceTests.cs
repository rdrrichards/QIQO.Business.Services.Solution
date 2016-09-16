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
    public class CompanyServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin", "QIQOCompanyAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void company_update_existing()
        {
            Company newObject = new Company() { CompanyKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>().CompanySave(newObject)).Returns(123);

            CompanyService service = new CompanyService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateCompany(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void company_insert_new()
        {
            Company newObject = new Company();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>().CompanySave(newObject)).Returns(123);

            CompanyService service = new CompanyService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateCompany(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
