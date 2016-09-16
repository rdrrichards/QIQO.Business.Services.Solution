using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class LedgerService : ServiceBase, ILedgerService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public LedgerService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public int CreateChartOfAccount(ChartOfAccount chart_of_account)
        {
            IChartOfAccountBusinessEngine coa_be = _business_engine_factory.GetBusinessEngine<IChartOfAccountBusinessEngine>();
            return coa_be.ChartOfAccountSave(chart_of_account);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public bool DeleteChartOfAccount(ChartOfAccount chart_of_account)
        {
            IChartOfAccountBusinessEngine coa_be = _business_engine_factory.GetBusinessEngine<IChartOfAccountBusinessEngine>();
            return coa_be.ChartOfAccountDelete(chart_of_account);
        }

        public ChartOfAccount GetChartOfAccount(int chart_of_account_key)
        {
            IChartOfAccountBusinessEngine coa_be = _business_engine_factory.GetBusinessEngine<IChartOfAccountBusinessEngine>();
            return coa_be.GetChartOfAccountByID(chart_of_account_key);
        }

        public List<ChartOfAccount> GetChartOfAccounts(Company company)
        {
            IChartOfAccountBusinessEngine coa_be = _business_engine_factory.GetBusinessEngine<IChartOfAccountBusinessEngine>();
            return coa_be.GetChartOfAccountsByCompany(company);
        }
    }
}