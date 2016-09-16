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
    public class AddressServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void address_update_existing()
        {
            Address newAddress = new Address() { AddressKey = 123 };
            //AddressData newAddressData = new AddressData() { AddressKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>().AddressSave(newAddress)).Returns(123);
            //Mock<IDataRepositoryFactory> mockDataRepoFactory = new Mock<IDataRepositoryFactory>();
            //mockDataRepoFactory.Setup(mock => mock.GetDataRepository<IAddressRepository>().Save(newAddressData)).Returns(123);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateAddress(newAddress);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void address_insert_new()
        {
            Address newAddress = new Address() { };
            //AddressData newAddressData = new AddressData() { AddressKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>().AddressSave(newAddress)).Returns(123);
            //Mock<IDataRepositoryFactory> mockDataRepoFactory = new Mock<IDataRepositoryFactory>();
            //mockDataRepoFactory.Setup(mock => mock.GetDataRepository<IAddressRepository>().Save(newAddressData)).Returns(123);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateAddress(newAddress);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void address_get_address_by_id_that_is_valid_returns_address()
        {
            Address newAddress = new Address() { AddressKey = 3 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>().GetAddressByID(3)).Returns(newAddress);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            Address lookup_ret_val = service.GetAddress(3);

            Assert.IsTrue(lookup_ret_val is Address);
        }

        [TestMethod]
        public void address_get_address_by_id_that_is_invalid_returns_empty_object()
        {
            Address emptyAddress = new Address() { };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>().GetAddressByID(33333)).Returns(emptyAddress);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            Address lookup_ret_val = service.GetAddress(33333);

            Assert.IsTrue(lookup_ret_val == emptyAddress);
        }

        [TestMethod]
        public void address_get_addresss_by_employee_that_is_valid_returns_addresses()
        {
            Employee employee = new Employee() { PersonKey = 1 };
            List<Address> newAddressData = new List<Address>()
            {
                new Address() { AddressKey = 1 },
                new Address() { AddressKey = 2 }
            };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()
                .GetAddressesByEntityID(employee.PersonKey, QIQOEntityType.Person)).Returns(newAddressData);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            List<Address> lookup_ret_val = service.GetAddressesByEntity(employee.PersonKey, QIQOEntityType.Person);

            Assert.IsTrue(lookup_ret_val.Count > 0);
        }

        [TestMethod]
        public void address_get_addresss_by_employee_that_is_invalid_returns_empty_list()
        {
            Employee employee = new Employee();
            List<Address> newAddressData = new List<Address>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()
                .GetAddressesByEntityID(employee.PersonKey, QIQOEntityType.Person)).Returns(newAddressData);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            List<Address> lookup_ret_val = service.GetAddressesByEntity(employee.PersonKey, QIQOEntityType.Person);

            Assert.IsTrue(lookup_ret_val.Count == 0);
        }

        [TestMethod]
        public void address_get_addresss_by_company_that_is_valid_returns_addresses()
        {
            Company company = new Company() { CompanyKey = 1 };
            List<Address> newAddressData = new List<Address>()
            {
                new Address() { AddressKey = 1 },
                new Address() { AddressKey = 2 }
            };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()
                .GetAddressesByCompany(company)).Returns(newAddressData);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            List<Address> lookup_ret_val = service.GetAddressesByCompany(company);

            Assert.IsTrue(lookup_ret_val.Count > 0);
        }

        [TestMethod]
        public void address_get_addresss_by_company_that_is_invalid_returns_empty_list()
        {
            Company company = new Company();
            List<Address> newAddressData = new List<Address>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()
                .GetAddressesByCompany(company)).Returns(newAddressData);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            List<Address> lookup_ret_val = service.GetAddressesByCompany(company);

            Assert.IsTrue(lookup_ret_val.Count == 0);
        }

        [TestMethod]
        public void address_delete_address_that_is_valid_returns_true()
        {
            Address address = new Address() { AddressKey = 1 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()
                .AddressDelete(address)).Returns(true);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            bool ret_val = service.DeleteAddress(address);

            Assert.IsTrue(ret_val);
        }

        [TestMethod]
        public void address_delete_address_that_is_invalid_returns_false()
        {
            Address address = new Address();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()
                .AddressDelete(address)).Returns(false);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            bool ret_val = service.DeleteAddress(address);

            Assert.IsFalse(ret_val);
        }

        [TestMethod]
        public void address_get_address_by_code_that_is_valid_returns_address()
        {
            AddressPostal newAddress = new AddressPostal() { PostalCode = "49735" };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressPostalBusinessEngine>()
                .GetAddressPostalByCode("49735")).Returns(newAddress);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            AddressPostal lookup_ret_val = service.GetAddressInfoByPostal("49735");

            Assert.IsTrue(lookup_ret_val is AddressPostal);
        }

        [TestMethod]
        public void address_get_address_by_code_that_is_invalid_returns_empty_object()
        {
            AddressPostal newAddress = new AddressPostal() { PostalCode = "00000" };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressPostalBusinessEngine>()
                .GetAddressPostalByCode("00000")).Returns(newAddress);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            AddressPostal lookup_ret_val = service.GetAddressInfoByPostal("00000");

            Assert.IsTrue(lookup_ret_val == newAddress);
        }

        [TestMethod]
        public void address_find_addresss_by_company_that_is_valid_returns_addresss()
        {
            List<AddressPostal> newAddressData = new List<AddressPostal>()
            {
                new AddressPostal() { StateFullName = "Michigan" },
                new AddressPostal() { StateFullName = "Tennessee" }
            };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressPostalBusinessEngine>()
                .GetStateListByCountry("United States")).Returns(newAddressData);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            List<AddressPostal> lookup_ret_val = service.GetStateListByCountry("United States");

            Assert.IsTrue(lookup_ret_val.Count > 0);
        }

        [TestMethod]
        public void address_find_addresss_by_company_that_is_invalid_returns_empty_object()
        {
            List<AddressPostal> newAddressData = new List<AddressPostal>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAddressPostalBusinessEngine>()
                .GetStateListByCountry("Java")).Returns(newAddressData);

            AddressService service = new AddressService(mockBusinessEngineFactory.Object);

            List<AddressPostal> lookup_ret_val = service.GetStateListByCountry("Java");

            Assert.IsTrue(lookup_ret_val.Count == 0);
        }
    }
}
