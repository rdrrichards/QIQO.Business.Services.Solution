using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IUserSessionBusinessEngine : IBusinessEngine
    {
        List<UserSession> GetUserSessions();
        UserSession GetUserSessionByCode(string user_session_code, Company company);
        UserSession GetUserSessionByCode(string user_session_code, string company_code);
        UserSession GetUserSessionByID(int user_session_key);
        bool UserSessionDelete(UserSession user_session);
        int UserSessionSave(UserSession user_session);
    }
}