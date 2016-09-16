using QIQO.Common.Contracts;
using QIQO.Data.Entities.Identity;
using System;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IUserClaimRepository : IIdentityRepository<UserClaimData>
    {
        IEnumerable<UserClaimData> GetAll(Guid user_id);
    }
}