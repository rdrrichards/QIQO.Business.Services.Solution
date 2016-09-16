using QIQO.Business.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IIdentityRoleService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int Create(Role role);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Delete(Role role);

        [OperationContract]
        Role FindById(Guid roleId);
        [OperationContract]
        Role FindByName(string normalizedRoleName);
        //[OperationContract]
        //string GetNormalizedRoleName(Role role);
        //[OperationContract]
        //string GetRoleId(Role role);
        //[OperationContract]
        //string GetRoleName(Role role);
        //[OperationContract]
        //bool SetNormalizedRoleName(Role role, string normalizedName);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetRoleName(Role role, string roleName);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Update(Role role);

        // Role Claims operations
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int AddClaim(Role role, RoleClaim claim);
        [OperationContract]
        IList<RoleClaim> GetClaims(Role role);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int RemoveClaim(Role role, RoleClaim claim);
    }
}
