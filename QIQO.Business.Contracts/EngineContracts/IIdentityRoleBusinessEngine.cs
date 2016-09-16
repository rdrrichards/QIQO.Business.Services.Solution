using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IIdentityRoleBusinessEngine : IBusinessEngine
    {
        int Create(Role role);
        bool Delete(Role role);
        Role FindById(Guid roleId);
        Role FindByName(string normalizedRoleName);
        //string GetNormalizedRoleName(Role role);
        //string GetRoleId(Role role);
        //string GetRoleName(Role role);
        //bool SetNormalizedRoleName(Role role, string normalizedName);
        //bool SetRoleName(Role role, string roleName);
        bool Update(Role role);


        int AddClaim(Role role, RoleClaim claim);
        IList<RoleClaim> GetClaims(Role role);
        int RemoveClaim(Role role, RoleClaim claim);
    }
}