using QIQO.Common.Contracts;
using QIQO.Data.Entities.Identity;
using System;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IUserLoginRepository : IIdentityRepository<UserLoginData>
    {
        IEnumerable<UserLoginData> GetAll(Guid user_id);
    }
}