using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Engines
{
    public class UserSessionBusinessEngine : EngineBase, IUserSessionBusinessEngine
    {
        public UserSessionBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {

        }
        public List<UserSession> GetUserSessions()
        {
            List<UserSession> user_sessions = new List<UserSession>();

            return ExecuteFaultHandledOperation(() =>
            {
                IUserSessionRepository user_session_repo = _data_repository_factory.GetDataRepository<IUserSessionRepository>();
                IEnumerable<UserSessionData> user_session_data = user_session_repo.GetAll();

                foreach (UserSessionData user_session in user_session_data)
                {
                    user_sessions.Add(MapUserSessionDataToUserSession(user_session));
                }
                return user_sessions;
            });
        }

        public UserSession GetUserSessionByCode(string user_session_code, Company company)
        {
            return GetUserSessionByCode(user_session_code, company.CompanyCode);
        }

        public UserSession GetUserSessionByCode(string user_session_code, string company_code)
        {
            Log.Info("Accessing UserSessionBusinessEngine GetUserSessionByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                IUserSessionRepository user_session_repo = _data_repository_factory.GetDataRepository<IUserSessionRepository>();
                UserSessionData user_session_data = user_session_repo.GetByCode(user_session_code, company_code);
                Log.Info("UserSessionBusinessEngine GetUserSessionByCode function completed");

                if (user_session_data.SessionKey != 0)
                {
                    UserSession user_session = MapUserSessionDataToUserSession(user_session_data);

                    return user_session;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("UserSession with code {0} is not in database", user_session_code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public UserSession GetUserSessionByID(int user_session_key)
        {
            Log.Info("Accessing UserSessionBusinessEngine GetUserSessionByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                IUserSessionRepository user_session_repo = _data_repository_factory.GetDataRepository<IUserSessionRepository>();
                UserSessionData user_session_data = user_session_repo.GetByID(user_session_key);
                Log.Info("UserSessionBusinessEngine GetByID function completed");

                if (user_session_data.SessionKey != 0)
                {
                    UserSession user_session = MapUserSessionDataToUserSession(user_session_data);

                    return user_session;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("UserSession with key {0} is not in database", user_session_key));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public bool UserSessionDelete(UserSession user_session)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IUserSessionRepository user_session_repo = _data_repository_factory.GetDataRepository<IUserSessionRepository>();
                UserSessionData user_session_data = MapUserSessionToUserSessionData(user_session);

                user_session_repo.Delete(user_session_data);
                return true;
            });
        }

        public int UserSessionSave(UserSession user_session)
        {
            if (user_session == null)
                throw new ArgumentNullException(nameof(user_session));

            return ExecuteFaultHandledOperation(() =>
            {
                IUserSessionRepository user_session_repo = _data_repository_factory.GetDataRepository<IUserSessionRepository>();

                int user_session_key;
                UserSessionData prod_data = MapUserSessionToUserSessionData(user_session);

                user_session_key = user_session_repo.Insert(prod_data);

                return user_session_key;
            });
        }

        private UserSession MapUserSessionDataToUserSession(UserSessionData user_session_data)
        {
            UserSession UserSession = new UserSession()
            {
                ProcessID = user_session_data.ProcessId,
                SessionID = user_session_data.SessionCode,
                UserDomain = user_session_data.UserDomain,
                UserName = user_session_data.UserName,
                HostName = user_session_data.HostName,
                CompanyKey = user_session_data.CompanyKey,
                StartTime = user_session_data.StartDate,
                EndTime = user_session_data.EndDate,
                Active = user_session_data.ActiveFlg,
                AddedUserID = user_session_data.AuditAddUserId,
                AddedDateTime = user_session_data.AuditAddDatetime,
                UpdateUserID = user_session_data.AuditUpdateUserId,
                UpdateDateTime = user_session_data.AuditUpdateDatetime
            };

            return UserSession;
        }

        private UserSessionData MapUserSessionToUserSessionData(UserSession user_session)
        {
            UserSessionData UserSession_data = new UserSessionData()
            {
                ProcessId = user_session.ProcessID,
                SessionCode = user_session.SessionID,
                UserDomain = user_session.UserDomain,
                UserName = user_session.UserName,
                HostName = user_session.HostName,
                CompanyKey = user_session.CompanyKey,
                ActiveFlg = user_session.Active,
                StartDate = user_session.StartTime,
                EndDate = user_session.EndTime
            };

            return UserSession_data;
        }
    }
}