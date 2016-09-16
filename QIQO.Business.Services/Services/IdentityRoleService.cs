using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System;
using System.ServiceModel;
using System.Collections.Generic;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
           ConcurrencyMode = ConcurrencyMode.Multiple,
           ReleaseServiceInstanceOnTransactionComplete = false)]
    public class IdentityRoleService : ServiceBase, IIdentityRoleService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public IdentityRoleService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }
        private IIdentityRoleBusinessEngine BusinessEngine => _business_engine_factory.GetBusinessEngine<IIdentityRoleBusinessEngine>();

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int AddClaim(Role role, RoleClaim claim)
        {
            return BusinessEngine.AddClaim(role, claim);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int Create(Role role)
        {
            return BusinessEngine.Create(role);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public bool Delete(Role role)
        {
            return BusinessEngine.Delete(role);
        }

        public Role FindById(Guid roleId)
        {
            return BusinessEngine.FindById(roleId);
        }

        public Role FindByName(string normalizedRoleName)
        {
            return BusinessEngine.FindByName(normalizedRoleName);
        }

        public IList<RoleClaim> GetClaims(Role role)
        {
            return BusinessEngine.GetClaims(role);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int RemoveClaim(Role role, RoleClaim claim)
        {
            return BusinessEngine.RemoveClaim(role, claim);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public bool Update(Role role)
        {
            return BusinessEngine.Update(role);
        }
    }
}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetNormalizedRoleName(Role role, string normalizedName)
//{
//    return BusinessEngine.SetNormalizedRoleName(role, normalizedName);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetRoleName(Role role, string roleName)
//{
//    return BusinessEngine.SetRoleName(role, roleName);
//}

//public string GetNormalizedRoleName(Role role)
//{
//    return BusinessEngine.GetNormalizedRoleName(role);
//}

//public string GetRoleId(Role role)
//{
//    return BusinessEngine.GetRoleId(role);
//}

//public string GetRoleName(Role role)
//{
//    return BusinessEngine.GetRoleName(role);
//}
