using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface ILedgerService
    {
        [OperationContract]
        List<ChartOfAccount> GetChartOfAccounts(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateChartOfAccount(ChartOfAccount chart_of_account);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteChartOfAccount(ChartOfAccount chart_of_account);

        [OperationContract]
        ChartOfAccount GetChartOfAccount(int chart_of_account_key);
    }
}