using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class SessionService : ServiceBase, ISessionService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public SessionService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        public UserSession GetSessionObject(int process_id, string host_name, string user_domain, string user_name)
        {
            string session_id = host_name + "|" + user_domain + "|" + user_name + "|" + process_id.ToString();
            Log.Info("***************** Session accessed: {0}", session_id);

            IUserSessionBusinessEngine session_be = _business_engine_factory.GetBusinessEngine<IUserSessionBusinessEngine>();
            return session_be.GetUserSessionByCode(session_id, string.Empty);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void RegisterSession(int process_id, string host_name, string user_domain, string user_name, int company_key)
        {
            UserSession new_session = new UserSession(process_id, host_name, user_domain, user_name, company_key);
            IUserSessionBusinessEngine session_be = _business_engine_factory.GetBusinessEngine<IUserSessionBusinessEngine>();
            int ret_val = session_be.UserSessionSave(new_session);
            Log.Info("***************** New session registered: {0}", new_session.SessionID);
            Log.Info("***************** New session company key: {0}", company_key);
            Log.Info("***************** New session user session key: {0}", ret_val);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void UnregisterSession(int process_id, string host_name, string user_domain, string user_name, int company_key)
        {
            //string session_id = host_name + "|" + user_domain + "|" + user_name + "|" + process_id.ToString();
            UserSession old_session = new UserSession(process_id, host_name, user_domain, user_name, company_key);
            IUserSessionBusinessEngine session_be = _business_engine_factory.GetBusinessEngine<IUserSessionBusinessEngine>();
            bool ret_val = session_be.UserSessionDelete(old_session);
            Log.Info("***************** Session unregistered: {0}", old_session.SessionID);
            Log.Info("***************** Session unregistered company key: {0}", company_key);
            Log.Info("***************** Session unregistered return value: {0}", ret_val);
        }
    }
}