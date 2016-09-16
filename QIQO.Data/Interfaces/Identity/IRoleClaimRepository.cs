using QIQO.Common.Contracts;
using QIQO.Data.Entities.Identity;
using System;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IRoleClaimRepository : IIdentityRepository<RoleClaimData>
    {
        IEnumerable<RoleClaimData> GetAll(string role_id);
        IEnumerable<RoleClaimData> GetAll(Guid role_id);
    }
}