using QIQO.Business.Entities;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface ISessionService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void RegisterSession(int process_id, string host_name, string user_domain, string user_name, int company_key);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void UnregisterSession(int process_id, string host_name, string user_domain, string user_name, int company_key);

        [OperationContract]
        UserSession GetSessionObject(int process_id, string host_name, string user_domain, string user_name);
    }
}