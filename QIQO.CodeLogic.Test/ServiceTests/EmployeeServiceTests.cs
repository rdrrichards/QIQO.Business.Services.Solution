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
    public class EmployeeServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void employee_update_existing()
        {
            Employee newObject = new Employee() { PersonKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IEmployeeBusinessEngine>().EmployeeSave(newObject)).Returns(123);

            EmployeeService service = new EmployeeService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateEmployee(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void employee_insert_new()
        {
            Employee newObject = new Employee();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IEmployeeBusinessEngine>().EmployeeSave(newObject)).Returns(123);

            EmployeeService service = new EmployeeService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateEmployee(newObject);

            Assert.IsTrue(update_ret_val == 123);
        }
    }
}
