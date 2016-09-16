using QIQO.Common.Contracts;
using QIQO.Data.Entities.Identity;
using System;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IUserRepository : IIdentityRepository<UserData>
    {
        UserData GetByEmail(string email);
        UserData GetByLogin(string login_provider, string provider_key);
        IEnumerable<UserData> GetAllForClaim(UserClaimData claim);
        IEnumerable<UserData> GetAllInRole(string roleName);
        bool GetUserIsInRole(Guid user_id, string roleName);
    }
}
