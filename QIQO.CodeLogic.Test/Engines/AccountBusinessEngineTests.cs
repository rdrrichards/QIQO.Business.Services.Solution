using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;

namespace QIQO.Business.Engines.Tests
{
    [TestClass()]
    public class AccountBusinessEngineTests
    {
        [TestMethod()]
        public void AccountDeleteTest()
        {
            //Arrange
            var test_account = new Account() { AccountKey = 1, AccountCode = "TEST" };
            var test_account_data = new AccountData() { AccountKey = 1, AccountCode = "TEST" };
            Mock<IAccountRepository> acct_repo = new Mock<IAccountRepository>();
            Mock<IAccountBusinessEngine> account_be = new Mock<IAccountBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IAccountEntityService> account_es = new Mock<IAccountEntityService>();

            acct_repo.Setup(mock => mock.Delete(It.IsAny<AccountData>()));
            account_be.Setup(mock => mock.AccountDelete(It.IsAny<Account>())).Returns(true);
            account_es.Setup(mock => mock.Map(It.IsAny<Account>())).Returns(test_account_data);
            repo_factory.Setup(mock => mock.GetDataRepository<IAccountRepository>()).Returns(acct_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()).Returns(account_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IAccountEntityService>()).Returns(account_es.Object);

            //account_be.Setup(mock => mock.AccountDelete(It.IsAny<Account>())).Returns(true);
            AccountBusinessEngine account_business_engine = new AccountBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            bool ret_val = account_business_engine.AccountDelete(test_account);

            //Assert
            Assert.IsTrue(ret_val);
        }

        [TestMethod()]
        public void AccountSaveTest()
        {
            //Arrange
            var test_account = new Account() { AccountKey = 1, AccountCode = "TEST" };
            var test_account_data = new AccountData() { AccountKey = 1, AccountCode = "TEST" };
            Mock<IAccountRepository> acct_repo = new Mock<IAccountRepository>();
            Mock<IAccountBusinessEngine> account_be = new Mock<IAccountBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IAccountEntityService> account_es = new Mock<IAccountEntityService>();

            acct_repo.Setup(mock => mock.Insert(It.IsAny<AccountData>())).Returns(1);
            account_be.Setup(mock => mock.AccountSave(It.IsAny<Account>())).Returns(1);
            account_es.Setup(mock => mock.Map(It.IsAny<Account>())).Returns(test_account_data);
            repo_factory.Setup(mock => mock.GetDataRepository<IAccountRepository>()).Returns(acct_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()).Returns(account_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IAccountEntityService>()).Returns(account_es.Object);

            AccountBusinessEngine account_business_engine = new AccountBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            int ret_val = account_business_engine.AccountSave(test_account);

            //Assert
            Assert.IsTrue(ret_val == 1);
        }

        [TestMethod()]
        public void GetAccountByCodeTest()
        {
            //Arrange
            var test_account = new Account() { AccountKey = 1, AccountCode = "TEST" };
            var test_account_data = new AccountData() { AccountKey = 1, AccountCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Mock<IAccountRepository> acct_repo = new Mock<IAccountRepository>();
            Mock<IAccountBusinessEngine> account_be = new Mock<IAccountBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IAccountEntityService> account_es = new Mock<IAccountEntityService>();

            Mock<IAccountTypeBusinessEngine> at_be = new Mock<IAccountTypeBusinessEngine>();
            Mock<IAddressBusinessEngine> address_be = new Mock<IAddressBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_attribute_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IFeeScheduleBusinessEngine> fee_schedule_be = new Mock<IFeeScheduleBusinessEngine>();
            Mock<IAccountEmployeeBusinessEngine> account_employee_be = new Mock<IAccountEmployeeBusinessEngine>();
            Mock<IContactBusinessEngine> contact_be = new Mock<IContactBusinessEngine>();

            acct_repo.Setup(mock => mock.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_account_data);
            account_be.Setup(mock => mock.GetAccountByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_account);
            account_es.Setup(mock => mock.Map(It.IsAny<AccountData>())).Returns(test_account);
            repo_factory.Setup(mock => mock.GetDataRepository<IAccountRepository>()).Returns(acct_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()).Returns(account_be.Object);

            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountTypeBusinessEngine>()).Returns(at_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()).Returns(address_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_attribute_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IFeeScheduleBusinessEngine>()).Returns(fee_schedule_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountEmployeeBusinessEngine>()).Returns(account_employee_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IContactBusinessEngine>()).Returns(contact_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IAccountEntityService>()).Returns(account_es.Object);

            AccountBusinessEngine account_business_engine = new AccountBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            Account ret_val = account_business_engine.GetAccountByCode("TEST", "TEST");

            //Assert
            Assert.IsTrue(ret_val.AccountCode == test_account.AccountCode);
        }

        [TestMethod()]
        public void GetAccountByIDTest()
        {
            //Arrange
            var test_account = new Account() { AccountKey = 1, AccountCode = "TEST" };
            var test_account_data = new AccountData() { AccountKey = 1, AccountCode = "TEST" };
            var test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Mock<IAccountRepository> acct_repo = new Mock<IAccountRepository>();
            Mock<IAccountBusinessEngine> account_be = new Mock<IAccountBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IAccountEntityService> account_es = new Mock<IAccountEntityService>();

            Mock<IAccountTypeBusinessEngine> at_be = new Mock<IAccountTypeBusinessEngine>();
            Mock<IAddressBusinessEngine> address_be = new Mock<IAddressBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_attribute_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IFeeScheduleBusinessEngine> fee_schedule_be = new Mock<IFeeScheduleBusinessEngine>();
            Mock<IAccountEmployeeBusinessEngine> account_employee_be = new Mock<IAccountEmployeeBusinessEngine>();
            Mock<IContactBusinessEngine> contact_be = new Mock<IContactBusinessEngine>();

            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountTypeBusinessEngine>()).Returns(at_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAddressBusinessEngine>()).Returns(address_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_attribute_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IFeeScheduleBusinessEngine>()).Returns(fee_schedule_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountEmployeeBusinessEngine>()).Returns(account_employee_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IContactBusinessEngine>()).Returns(contact_be.Object);

            acct_repo.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(test_account_data);
            account_be.Setup(mock => mock.GetAccountByID(It.IsAny<int>(), false)).Returns(test_account);
            account_es.Setup(mock => mock.Map(It.IsAny<AccountData>())).Returns(test_account);
            account_be.Setup(mock => mock.GetAccountByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_account);
            repo_factory.Setup(mock => mock.GetDataRepository<IAccountRepository>()).Returns(acct_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()).Returns(account_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IAccountEntityService>()).Returns(account_es.Object);

            AccountBusinessEngine account_business_engine = new AccountBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            Account ret_val = account_business_engine.GetAccountByID(1, false);

            //Assert
            Assert.IsTrue(ret_val.AccountCode == test_account.AccountCode);
        }
    }
}