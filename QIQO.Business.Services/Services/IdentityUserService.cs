using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
           ConcurrencyMode = ConcurrencyMode.Multiple,
           ReleaseServiceInstanceOnTransactionComplete = false)]
    public class IdentityUserService : ServiceBase, IIdentityUserService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public IdentityUserService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        private IIdentityUserBusinessEngine BusinessEngine => _business_engine_factory.GetBusinessEngine<IIdentityUserBusinessEngine>();

        public int AddClaims(User user, IEnumerable<UserClaim> claims)
        {
            return BusinessEngine.AddClaims(user, claims);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int AddLogin(User user, UserLogin user_login)
        {
            return BusinessEngine.AddLogin(user, user_login);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int AddToRole(User user, string roleName)
        {
            return BusinessEngine.AddToRole(user, roleName);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int Create(User user)
        {
            return BusinessEngine.Create(user);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public bool Delete(User user)
        {
            return BusinessEngine.Delete(user);
        }

        public User FindByEmail(string normalizedEmail)
        {
            return BusinessEngine.FindByEmail(normalizedEmail);
        }

        public User FindById(Guid userId)
        {
            return BusinessEngine.FindById(userId);
        }

        public User FindByLogin(string loginProvider, string providerKey)
        {
            return BusinessEngine.FindByLogin(loginProvider, providerKey);
        }

        public User FindByName(string normalizedUserName)
        {
            return BusinessEngine.FindByName(normalizedUserName);
        }

        public IList<UserClaim> GetClaims(User user)
        {
            return BusinessEngine.GetClaims(user);
        }

        public IList<UserLogin> GetLogins(User user)
        {
            return BusinessEngine.GetLogins(user);
        }

        public IList<string> GetRoles(User user)
        {
            return BusinessEngine.GetRoles(user);
        }

        public IList<User> GetUsersForClaim(UserClaim claim)
        {
            return BusinessEngine.GetUsersForClaim(claim);
        }

        public IList<User> GetUsersInRole(string roleName)
        {
            return BusinessEngine.GetUsersInRole(roleName);
        }

        public bool IsInRole(User user, string roleName)
        {
            return BusinessEngine.IsInRole(user, roleName);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int RemoveClaims(User user, IEnumerable<UserClaim> claims)
        {
            return BusinessEngine.RemoveClaims(user, claims);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public bool RemoveFromRole(User user, string roleName)
        {
            return BusinessEngine.RemoveFromRole(user, roleName);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public bool RemoveLogin(User user, string loginProvider, string providerKey)
        {
            return BusinessEngine.RemoveLogin(user, loginProvider, providerKey);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int ReplaceClaim(User user, UserClaim claim, UserClaim newClaim)
        {
            return BusinessEngine.ReplaceClaim(user, claim, newClaim);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int Update(User user)
        {
            return BusinessEngine.Update(user);
        }
    }
}

//public bool HasPassword(User user)
//{
//    throw new NotImplementedException();
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public int IncrementAccessFailedCount(User user)
//{
//    return BusinessEngine.IncrementAccessFailedCount(user);
//}

//public string GetSecurityStamp(User user)
//{
//    throw new NotImplementedException();
//}

//public bool GetTwoFactorEnabled(User user)
//{
//    throw new NotImplementedException();
//}

//public string GetUserId(User user)
//{
//    throw new NotImplementedException();
//}

//public string GetUserName(User user)
//{
//    throw new NotImplementedException();
//}

//public string GetNormalizedEmail(User user)
//{
//    throw new NotImplementedException();
//}

//public string GetNormalizedUserName(User user)
//{
//    throw new NotImplementedException();
//}

//public string GetPasswordHash(User user)
//{
//    throw new NotImplementedException();
//}

//public string GetPhoneNumber(User user)
//{
//    throw new NotImplementedException();
//}

//public bool GetPhoneNumberConfirmed(User user)
//{
//    throw new NotImplementedException();
//}

//public int GetAccessFailedCount(User user)
//{
//    throw new NotImplementedException();
//}

//public string GetEmail(User user)
//{
//    throw new NotImplementedException();
//}

//public bool GetEmailConfirmed(User user)
//{
//    throw new NotImplementedException();
//}

//public bool GetLockoutEnabled(User user)
//{
//    throw new NotImplementedException();
//}

//public DateTimeOffset? GetLockoutEndDate(User user)
//{
//    throw new NotImplementedException();
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool ResetAccessFailedCount(User user)
//{
//    return BusinessEngine.ResetAccessFailedCount(user);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetEmail(User user, string email)
//{
//    return BusinessEngine.SetEmail(user, email);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetEmailConfirmed(User user, bool confirmed)
//{
//    return BusinessEngine.SetEmailConfirmed(user, confirmed);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetLockoutEnabled(User user, bool enabled)
//{
//    return BusinessEngine.SetLockoutEnabled(user, enabled);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetLockoutEndDate(User user, DateTimeOffset? lockoutEnd)
//{
//    return BusinessEngine.SetLockoutEndDate(user, lockoutEnd);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetNormalizedEmail(User user, string normalizedEmail)
//{
//    return BusinessEngine.SetNormalizedEmail(user, normalizedEmail);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetNormalizedUserName(User user, string normalizedName)
//{
//    return BusinessEngine.SetNormalizedUserName(user, normalizedName);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetPasswordHash(User user, string passwordHash)
//{
//    return BusinessEngine.SetPasswordHash(user, passwordHash);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetPhoneNumber(User user, string phoneNumber)
//{
//    return BusinessEngine.SetPhoneNumber(user, phoneNumber);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetPhoneNumberConfirmed(User user, bool confirmed)
//{
//    return BusinessEngine.SetPhoneNumberConfirmed(user, confirmed);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetSecurityStamp(User user, string stamp)
//{
//    return BusinessEngine.SetSecurityStamp(user, stamp);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SetTwoFactorEnabled(User user, bool enabled)
//{
//    return BusinessEngine.SetTwoFactorEnabled(user, enabled);
//}

//[OperationBehavior(TransactionScopeRequired = true)]
//public bool SeUserName(User user, string userName)
//{
//    return BusinessEngine.SeUserName(user, userName);
//}