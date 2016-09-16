using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IFeeScheduleService
    {
        [OperationContract]
        List<FeeSchedule> GetFeeSchedulesByAccount(Account account);

        [OperationContract]
        List<FeeSchedule> GetFeeSchedulesByCompany(Company company);

        [OperationContract]
        List<FeeSchedule> GetFeeSchedulesByProduct(Product product);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateFeeSchedule(FeeSchedule fee_schedule);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteFeeSchedule(FeeSchedule fee_schedule);

        [OperationContract]
        FeeSchedule GetFeeSchedule(int fee_schedule);
    }
}