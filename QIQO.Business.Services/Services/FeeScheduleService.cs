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
    public class FeeScheduleService : ServiceBase, IFeeScheduleService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public FeeScheduleService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public int CreateFeeSchedule(FeeSchedule fee_schedule)
        {
            IFeeScheduleBusinessEngine fee_schedule_be = _business_engine_factory.GetBusinessEngine<IFeeScheduleBusinessEngine>();
            return fee_schedule_be.FeeScheduleSave(fee_schedule);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public bool DeleteFeeSchedule(FeeSchedule fee_schedule)
        {
            IFeeScheduleBusinessEngine fee_schedule_be = _business_engine_factory.GetBusinessEngine<IFeeScheduleBusinessEngine>();
            return fee_schedule_be.FeeScheduleDelete(fee_schedule);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public FeeSchedule GetFeeSchedule(int fee_schedule)
        {
            IFeeScheduleBusinessEngine fee_schedule_be = _business_engine_factory.GetBusinessEngine<IFeeScheduleBusinessEngine>();
            return fee_schedule_be.GetFeeScheduleByID(fee_schedule);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public List<FeeSchedule> GetFeeSchedulesByCompany(Company company)
        {
            IFeeScheduleBusinessEngine fee_schedule_be = _business_engine_factory.GetBusinessEngine<IFeeScheduleBusinessEngine>();
            return fee_schedule_be.GetFeeSchedulesByCompany(company);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public List<FeeSchedule> GetFeeSchedulesByAccount(Account account)
        {
            IFeeScheduleBusinessEngine fee_schedule_be = _business_engine_factory.GetBusinessEngine<IFeeScheduleBusinessEngine>();
            return fee_schedule_be.GetFeeSchedulesByAccount(account);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        public List<FeeSchedule> GetFeeSchedulesByProduct(Product product)
        {
            IFeeScheduleBusinessEngine fee_schedule_be = _business_engine_factory.GetBusinessEngine<IFeeScheduleBusinessEngine>();
            return fee_schedule_be.GetFeeSchedulesByProduct(product);
        }
    }
}