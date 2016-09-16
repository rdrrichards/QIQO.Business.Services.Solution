using QIQO.Business.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IIdentityUserService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int AddLogin(User user, UserLogin user_login);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int AddToRole(User user, string roleName);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int Create(User user);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Delete(User user);

        [OperationContract]
        User FindByEmail(string normalizedEmail);
        [OperationContract]
        User FindById(Guid userId);
        [OperationContract]
        User FindByLogin(string loginProvider, string providerKey);
        [OperationContract]
        User FindByName(string normalizedUserName);
        [OperationContract]
        IList<UserLogin> GetLogins(User user);
        [OperationContract]
        IList<string> GetRoles(User user);
        [OperationContract]
        IList<User> GetUsersInRole(string roleName);

        [OperationContract]
        bool IsInRole(User user, string roleName);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool RemoveFromRole(User user, string roleName);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool RemoveLogin(User user, string loginProvider, string providerKey);

        //[OperationContract]
        //bool HasPassword(User user);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //int IncrementAccessFailedCount(User user);
        //[OperationContract]
        //string GetSecurityStamp(User user);
        //[OperationContract]
        //bool GetTwoFactorEnabled(User user);
        //[OperationContract]
        //string GetUserId(User user);
        //[OperationContract]
        //string GetUserName(User user);
        //[OperationContract]
        //string GetNormalizedEmail(User user);
        //[OperationContract]
        //string GetNormalizedUserName(User user);
        //[OperationContract]
        //string GetPasswordHash(User user);
        //[OperationContract]
        //string GetPhoneNumber(User user);
        //[OperationContract]
        //bool GetPhoneNumberConfirmed(User user);
        //[OperationContract]
        //int GetAccessFailedCount(User user);
        //[OperationContract]
        //string GetEmail(User user);
        //[OperationContract]
        //bool GetEmailConfirmed(User user);
        //[OperationContract]
        //bool GetLockoutEnabled(User user);
        //[OperationContract]
        //DateTimeOffset? GetLockoutEndDate(User user);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool ResetAccessFailedCount(User user);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetEmail(User user, string email);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetEmailConfirmed(User user, bool confirmed);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetLockoutEnabled(User user, bool enabled);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetLockoutEndDate(User user, DateTimeOffset? lockoutEnd);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetNormalizedEmail(User user, string normalizedEmail);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetNormalizedUserName(User user, string normalizedName);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetPasswordHash(User user, string passwordHash);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetPhoneNumber(User user, string phoneNumber);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetPhoneNumberConfirmed(User user, bool confirmed);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetSecurityStamp(User user, string stamp);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SetTwoFactorEnabled(User user, bool enabled);
        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool SeUserName(User user, string userName);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int Update(User user);


        // User Claims operations
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int AddClaims(User user, IEnumerable<UserClaim> claims);
        [OperationContract]
        IList<UserClaim> GetClaims(User user);
        [OperationContract]
        IList<User> GetUsersForClaim(UserClaim claim);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int RemoveClaims(User user, IEnumerable<UserClaim> claims);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int ReplaceClaim(User user, UserClaim claim, UserClaim newClaim);
    }
}
