using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System.Collections.Generic;

namespace QIQO.Business.Engines.Tests
{
    [TestClass()]
    public class CompanyBusinessEngineTests
    {
        [TestMethod()]
        public void CompanyDeleteTest()
        {
            //Arrange
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Mock<ICompanyRepository> comp_repo = new Mock<ICompanyRepository>();

            Mock<ICompanyBusinessEngine> company_be = new Mock<ICompanyBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<ICompanyEntityService> comp_es = new Mock<ICompanyEntityService>();

            comp_repo.Setup(mock => mock.Delete(It.IsAny<CompanyData>()));
            company_be.Setup(mock => mock.CompanyDelete(It.IsAny<Company>())).Returns(true);
            comp_es.Setup(mock => mock.Map(It.IsAny<Company>())).Returns(test_comp_data);

            repo_factory.Setup(mock => mock.GetDataRepository<ICompanyRepository>()).Returns(comp_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>()).Returns(company_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<ICompanyEntityService>()).Returns(comp_es.Object);

            CompanyBusinessEngine company_business_engine = new CompanyBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            bool ret_val = company_business_engine.CompanyDelete(test_comp);

            //Assert
            Assert.IsTrue(ret_val);
        }

        [TestMethod()]
        public void CompanySaveTest()
        {
            //Arrange
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Mock<ICompanyRepository> comp_repo = new Mock<ICompanyRepository>();
            Mock<IPersonRepository> pers_repo = new Mock<IPersonRepository>();

            Mock<ICompanyBusinessEngine> company_be = new Mock<ICompanyBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<ICompanyEntityService> comp_es = new Mock<ICompanyEntityService>();

            Mock<IEntityAttributeBusinessEngine> entity_attribute_be = new Mock<IEntityAttributeBusinessEngine>();

            Mock<IChartOfAccountBusinessEngine> coa_be = new Mock<IChartOfAccountBusinessEngine>();
            Mock<IAddressBusinessEngine> address_be = new Mock<IAddressBusinessEngine>();

            comp_repo.Setup(mock => mock.Insert(It.IsAny<CompanyData>())).Returns(1);
            company_be.Setup(mock => mock.CompanySave(It.IsAny<Company>())).Returns(1);
            comp_es.Setup(mock => mock.Map(It.IsAny<Company>())).Returns(test_comp_data);

            repo_factory.Setup(mock => mock.GetDataRepository<ICompanyRepository>()).Returns(comp_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IPersonRepository>()).Returns(pers_repo.Object);

            be_factory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>()).Returns(company_be.Object);

            be_factory.Setup(mock => mock.GetBusinessEngine<IChartOfAccountBusinessEngine>()).Returns(coa_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()).Returns(address_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_attribute_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<ICompanyEntityService>()).Returns(comp_es.Object);

            CompanyBusinessEngine company_business_engine = new CompanyBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            int ret_val = company_business_engine.CompanySave(test_comp);

            //Assert
            Assert.IsTrue(ret_val == 1);
        }

        [TestMethod()]
        public void GetCompanyByIDTest()
        {
            //Arrange
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Mock<ICompanyRepository> comp_repo = new Mock<ICompanyRepository>();

            Mock<ICompanyBusinessEngine> company_be = new Mock<ICompanyBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<ICompanyEntityService> comp_es = new Mock<ICompanyEntityService>();

            comp_repo.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(test_comp_data);
            company_be.Setup(mock => mock.GetCompanyByID(It.IsAny<int>())).Returns(test_comp);
            comp_es.Setup(mock => mock.Map(It.IsAny<CompanyData>())).Returns(test_comp);

            repo_factory.Setup(mock => mock.GetDataRepository<ICompanyRepository>()).Returns(comp_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>()).Returns(company_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<ICompanyEntityService>()).Returns(comp_es.Object);

            CompanyBusinessEngine company_business_engine = new CompanyBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            Company ret_val = company_business_engine.GetCompanyByID(1);

            //Assert
            Assert.IsTrue(ret_val.CompanyKey == 1);
        }

        [TestMethod()]
        public void GetCompaniesByEmployeeTest()
        {
            //Arrange
            List<CompanyData> test_comp_data = new List<CompanyData>() { new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" } };
            List<Company> test_comp = new List<Company>() { new Company() { CompanyKey = 1, CompanyCode = "TEST" } };
            PersonData person_date = new PersonData() { PersonCode = "TEST" };
            Employee emp = new Employee() { PersonCode = "TEST" };
            Company test_co = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Mock<ICompanyRepository> comp_repo = new Mock<ICompanyRepository>();
            Mock<IPersonRepository> pers_repo = new Mock<IPersonRepository>();

            Mock<ICompanyBusinessEngine> company_be = new Mock<ICompanyBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<ICompanyEntityService> comp_es = new Mock<ICompanyEntityService>();

            Mock<IEntityAttributeBusinessEngine> entity_attribute_be = new Mock<IEntityAttributeBusinessEngine>();

            Mock<IChartOfAccountBusinessEngine> coa_be = new Mock<IChartOfAccountBusinessEngine>();
            Mock<IAddressBusinessEngine> address_be = new Mock<IAddressBusinessEngine>();

            comp_repo.Setup(mock => mock.GetAll(It.IsAny<PersonData>())).Returns(test_comp_data);
            company_be.Setup(mock => mock.GetCompaniesByEmployee(It.IsAny<Employee>())).Returns(test_comp);
            comp_es.Setup(mock => mock.Map(It.IsAny<CompanyData>())).Returns(test_co);

            repo_factory.Setup(mock => mock.GetDataRepository<ICompanyRepository>()).Returns(comp_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IPersonRepository>()).Returns(pers_repo.Object);

            be_factory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>()).Returns(company_be.Object);

            be_factory.Setup(mock => mock.GetBusinessEngine<IChartOfAccountBusinessEngine>()).Returns(coa_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()).Returns(address_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_attribute_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<ICompanyEntityService>()).Returns(comp_es.Object);

            CompanyBusinessEngine company_business_engine = new CompanyBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            List<Company> ret_val = company_business_engine.GetCompaniesByEmployee(emp);

            //Assert
            Assert.IsTrue(ret_val.Count == 1);
        }

        [TestMethod()]
        public void GetEmployeeRoleInCompanyTest()
        {
            //Arrange
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            EntityPersonData ep_data = new EntityPersonData() { PersonRole = "TEST_ROLE" };
            Employee emp = new Employee() { RoleInCompany = "TEST_ROLE"};
            Mock<ICompanyRepository> comp_repo = new Mock<ICompanyRepository>();
            Mock<IEntityPersonRepository> ep_repo = new Mock<IEntityPersonRepository>();

            Mock<ICompanyBusinessEngine> company_be = new Mock<ICompanyBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();

            ep_repo.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(ep_data);
            company_be.Setup(mock => mock.GetEmployeeRoleInCompany(It.IsAny<Employee>())).Returns(emp.RoleInCompany);

            repo_factory.Setup(mock => mock.GetDataRepository<ICompanyRepository>()).Returns(comp_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IEntityPersonRepository>()).Returns(ep_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>()).Returns(company_be.Object);

            CompanyBusinessEngine company_business_engine = new CompanyBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            string ret_val = company_business_engine.GetEmployeeRoleInCompany(emp);

            //Assert
            Assert.IsTrue(ret_val == emp.RoleInCompany);
        }

        [TestMethod()]
        public void AddEmployeeTest()
        {
            //Arrange
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            EntityPersonData ep_data = new EntityPersonData();
            Employee emp = new Employee();
            Mock<ICompanyRepository> comp_repo = new Mock<ICompanyRepository>();
            Mock<IEntityPersonRepository> ep_repo = new Mock<IEntityPersonRepository>();

            Mock<ICompanyBusinessEngine> company_be = new Mock<ICompanyBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();

            ep_repo.Setup(mock => mock.Insert(It.IsAny<EntityPersonData>())).Returns(1);
            company_be.Setup(mock => mock.AddEmployee(It.IsAny<Company>(), It.IsAny<Employee>(), It.IsAny<string>(), It.IsAny<string>())).Returns(1);

            repo_factory.Setup(mock => mock.GetDataRepository<ICompanyRepository>()).Returns(comp_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IEntityPersonRepository>()).Returns(ep_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>()).Returns(company_be.Object);

            CompanyBusinessEngine company_business_engine = new CompanyBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            int ret_val = company_business_engine.AddEmployee(test_comp, emp, "", "");

            //Assert
            Assert.IsTrue(ret_val == 1);
        }

        [TestMethod()]
        public void DeteteEmployeeTest()
        {
            //Arrange
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            EntityPersonData ep_data = new EntityPersonData();
            Employee emp = new Employee();
            Mock<ICompanyRepository> comp_repo = new Mock<ICompanyRepository>();
            Mock<IEntityPersonRepository> ep_repo = new Mock<IEntityPersonRepository>();

            Mock<ICompanyBusinessEngine> company_be = new Mock<ICompanyBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();

            ep_repo.Setup(mock => mock.Delete(It.IsAny<EntityPersonData>()));
            company_be.Setup(mock => mock.DeteteEmployee(It.IsAny<Company>(), It.IsAny<Employee>())).Returns(true);

            repo_factory.Setup(mock => mock.GetDataRepository<ICompanyRepository>()).Returns(comp_repo.Object);
            repo_factory.Setup(mock => mock.GetDataRepository<IEntityPersonRepository>()).Returns(ep_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<ICompanyBusinessEngine>()).Returns(company_be.Object);

            CompanyBusinessEngine company_business_engine = new CompanyBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            bool ret_val = company_business_engine.DeteteEmployee(test_comp, emp);

            //Assert
            Assert.IsTrue(ret_val);
        }
    }
}