using QIQO.Common.Contracts;
using QIQO.Data.Entities.Identity;
using System;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IUserRoleRepository : IIdentityRepository<UserRoleData>
    {
        IEnumerable<UserRoleData> GetAll(Guid user_id);
    }
}