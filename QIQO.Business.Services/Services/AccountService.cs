using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Business.Services.Behaviors;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class AccountService : ServiceBase, IAccountService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public AccountService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [QIQOOperationBehavior]
        public Account GetAccountByID(int account_key, bool full_load = false)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning GetAccountByID Call for account key {0}", account_key);
            return acctBE.GetAccountByID(account_key, full_load);
        }

        [QIQOOperationBehavior]
        public List<Account> GetAccountsByEmployee(Employee employee)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning GetAccountsByEmployee Call for account key {0}", employee.PersonLastName);
            return acctBE.GetAccountsByRep(employee);
        }

        [QIQOOperationBehavior]
        public List<Account> GetAccountsByCompany(Company company)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning GetAccountsByCompany Call for account key {0}", company.CompanyName);
            return acctBE.GetAccountsByCompany(company);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOAccountAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryUser)]
        public int CreateAccount(Account account)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning CreateAccount Call for account key {0}", account.AccountName);
            return acctBE.AccountSave(account);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOAccountAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryUser)]
        public bool DeleteAccount(Account account)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning DeleteAccount Call for account key {0}", account.AccountName);
            return acctBE.AccountDelete(account);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOAccountAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryUser)]
        public string GetAccountNextNumber(Account account, QIQOEntityNumberType number_type)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning GetAccountNextNumber Call for account key {0}", account.AccountName);
            return acctBE.GetNextEntityNumber(account, number_type);
        }

        [QIQOOperationBehavior]
        public Account GetAccountByCode(string account_code, string company_code)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning GetAccountByCode Call for account key {0}", account_code);
            return acctBE.GetAccountByCode(account_code, company_code);
        }

        public List<Account> FindAccountByCompany(Company company, string pattern)
        {
            IAccountBusinessEngine acctBE = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            Log.Info("Beginning FindAccountByCompany Call for account key {0}", company.CompanyName);
            return acctBE.FindAccountsByCompany(company, pattern);
        }

        //*******************************************************************
        //****** MAY ONLY BE NEEDED ON NON-ACCOUNT CLASSES, LIKE Order
        //*******************************************************************

        //protected override Account LoadAuthorizationValidationAccount(string loginName)
        //{
        //    IAccountRepository accountRepository = _DataRepositoryFactory.GetDataRepository<IAccountRepository>();
        //    Account authAcct = accountRepository.GetByLogin(loginName);
        //    if (authAcct == null)
        //    {
        //        NotFoundException ex = new NotFoundException(string.Format("Cannot find account for login name {0} to use for security trimming.", loginName));
        //        throw new FaultException<NotFoundException>(ex, ex.Message);
        //    }

        //    return authAcct;
        //}
    }

}
