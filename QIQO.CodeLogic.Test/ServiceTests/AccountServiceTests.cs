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
    public class AccountServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            GenericPrincipal principal = new GenericPrincipal(
               new GenericIdentity("Richard Richards"), new string[] { "Administrators", "QIQOOrderEntryAdmin" });
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        public void account_update_existing()
        {
            Account newAccount = new Account() { AccountKey = 123 };
            //AccountData newAccountData = new AccountData() { AccountKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>().AccountSave(newAccount)).Returns(123);
            //Mock<IDataRepositoryFactory> mockDataRepoFactory = new Mock<IDataRepositoryFactory>();
            //mockDataRepoFactory.Setup(mock => mock.GetDataRepository<IAccountRepository>().Save(newAccountData)).Returns(123);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateAccount(newAccount);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void account_insert_new()
        {
            Account newAccount = new Account() {};
            //AccountData newAccountData = new AccountData() { AccountKey = 123 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>().AccountSave(newAccount)).Returns(123);
            //Mock<IDataRepositoryFactory> mockDataRepoFactory = new Mock<IDataRepositoryFactory>();
            //mockDataRepoFactory.Setup(mock => mock.GetDataRepository<IAccountRepository>().Save(newAccountData)).Returns(123);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            int update_ret_val = service.CreateAccount(newAccount);

            Assert.IsTrue(update_ret_val == 123);
        }

        [TestMethod]
        public void account_get_account_by_id_that_is_valid_returns_account()
        {
            Account newAccount = new Account() { AccountKey = 3 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>().GetAccountByID(3, false)).Returns(newAccount);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            Account lookup_ret_val = service.GetAccountByID(3);

            Assert.IsTrue(lookup_ret_val is Account);
        }

        [TestMethod]
        public void account_get_account_by_id_that_is_invalid_returns_empty_object()
        {
            Account emptyAccount = new Account() { };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>().GetAccountByID(33333, false)).Returns(emptyAccount);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            Account lookup_ret_val = service.GetAccountByID(33333);

            Assert.IsTrue(lookup_ret_val == emptyAccount);
        }

        [TestMethod]
        public void account_get_accounts_by_employee_that_is_valid_returns_accounts()
        {
            Employee employee = new Employee() { PersonKey = 1 };
            List<Account> newAccountData = new List<Account>()
            {
                new Account() { AccountKey = 1 },
                new Account() { AccountKey = 2 }
            };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetAccountsByRep(employee)).Returns(newAccountData);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            List<Account> lookup_ret_val = service.GetAccountsByEmployee(employee);

            Assert.IsTrue(lookup_ret_val.Count > 0);
        }

        [TestMethod]
        public void account_get_accounts_by_employee_that_is_invalid_returns_empty_list()
        {
            Employee employee = new Employee();
            List<Account> newAccountData = new List<Account>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetAccountsByRep(employee)).Returns(newAccountData);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            List<Account> lookup_ret_val = service.GetAccountsByEmployee(employee);

            Assert.IsTrue(lookup_ret_val.Count == 0);
        }

        [TestMethod]
        public void account_get_accounts_by_company_that_is_valid_returns_accounts()
        {
            Company company = new Company() { CompanyKey = 1 };
            List<Account> newAccountData = new List<Account>()
            {
                new Account() { AccountKey = 1 },
                new Account() { AccountKey = 2 }
            };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetAccountsByCompany(company)).Returns(newAccountData);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            List<Account> lookup_ret_val = service.GetAccountsByCompany(company);

            Assert.IsTrue(lookup_ret_val.Count > 0);
        }

        [TestMethod]
        public void account_get_accounts_by_company_that_is_invalid_returns_empty_list()
        {
            Company company = new Company();
            List<Account> newAccountData = new List<Account>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetAccountsByCompany(company)).Returns(newAccountData);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            List<Account> lookup_ret_val = service.GetAccountsByCompany(company);

            Assert.IsTrue(lookup_ret_val.Count == 0);
        }

        [TestMethod]
        public void account_delete_account_that_is_valid_returns_true()
        {
            Account account = new Account() { AccountKey = 1 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .AccountDelete(account)).Returns(true);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            bool ret_val = service.DeleteAccount(account);

            Assert.IsTrue(ret_val);
        }

        [TestMethod]
        public void account_delete_account_that_is_invalid_returns_false()
        {
            Account account = new Account();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .AccountDelete(account)).Returns(false);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            bool ret_val = service.DeleteAccount(account);

            Assert.IsFalse(ret_val);
        }

        [TestMethod]
        public void account_get_next_number_for_account_that_is_valid_returns_nonempty_string()
        {
            Account account = new Account() { AccountKey = 1 };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetNextEntityNumber(account, QIQOEntityNumberType.AccountNumber)).Returns("Dummy Number");

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            string ret_val = service.GetAccountNextNumber(account, QIQOEntityNumberType.AccountNumber);

            Assert.IsTrue(ret_val.Length > 0);
        }

        [TestMethod]
        public void account_get_next_number_for_account_that_is_invalid_returns_empty_string()
        {
            Account account = new Account();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetNextEntityNumber(account, QIQOEntityNumberType.AccountNumber)).Returns("");

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            string ret_val = service.GetAccountNextNumber(account, QIQOEntityNumberType.AccountNumber);

            Assert.IsTrue(ret_val.Length == 0);
        }

        [TestMethod]
        public void account_get_account_by_code_that_is_valid_returns_account()
        {
            Account newAccount = new Account() { AccountCode = "TEST" };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetAccountByCode("TEST", "COMP")).Returns(newAccount);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            Account lookup_ret_val = service.GetAccountByCode("TEST", "COMP");

            Assert.IsTrue(lookup_ret_val is Account);
        }

        [TestMethod]
        public void account_get_account_by_code_that_is_invalid_returns_empty_object()
        {
            Account newAccount = new Account();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .GetAccountByCode("TEST", "COMP")).Returns(newAccount);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            Account lookup_ret_val = service.GetAccountByCode("TEST", "COMP");

            Assert.IsTrue(lookup_ret_val == newAccount);
        }

        [TestMethod]
        public void account_find_accounts_by_company_that_is_valid_returns_accounts()
        {
            Company company = new Company() { CompanyKey = 1 };
            List<Account> newAccountData = new List<Account>()
            {
                new Account() { AccountKey = 1 },
                new Account() { AccountKey = 2 }
            };

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .FindAccountsByCompany(company, "Java")).Returns(newAccountData);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            List<Account> lookup_ret_val = service.FindAccountByCompany(company, "Java");

            Assert.IsTrue(lookup_ret_val.Count > 0);
        }

        [TestMethod]
        public void account_find_accounts_by_company_that_is_invalid_returns_empty_object()
        {
            Company company = new Company();
            List<Account> newAccountData = new List<Account>();

            Mock<IBusinessEngineFactory> mockBusinessEngineFactory = new Mock<IBusinessEngineFactory>();
            mockBusinessEngineFactory.Setup(mock => mock.GetBusinessEngine<IAccountBusinessEngine>()
                .FindAccountsByCompany(company, "ZzZZYYXX")).Returns(newAccountData);

            AccountService service = new AccountService(mockBusinessEngineFactory.Object);

            List<Account> lookup_ret_val = service.FindAccountByCompany(company, "ZzZZYYXX");

            Assert.IsTrue(lookup_ret_val.Count == 0);
        }
    }
}
