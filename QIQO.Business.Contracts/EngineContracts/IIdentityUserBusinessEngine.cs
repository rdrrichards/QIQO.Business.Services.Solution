using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IIdentityUserBusinessEngine : IBusinessEngine
    {
        int AddLogin(User user, UserLogin user_login);
        int AddToRole(User user, string roleName);
        int Create(User user);
        bool Delete(User user);
        User FindByEmail(string normalizedEmail);
        User FindById(Guid userId);
        User FindByLogin(string loginProvider, string providerKey);
        User FindByName(string normalizedUserName);
        //int GetAccessFailedCount(User user);
        //string GetEmail(User user);
        //bool GetEmailConfirmed(User user);
        //bool GetLockoutEnabled(User user);
        //DateTimeOffset? GetLockoutEndDate(User user);
        IList<UserLogin> GetLogins(User user);
        //string GetNormalizedEmail(User user);
        //string GetNormalizedUserName(User user);
        //string GetPasswordHash(User user);
        //string GetPhoneNumber(User user);
        //bool GetPhoneNumberConfirmed(User user);
        IList<string> GetRoles(User user);
        //string GetSecurityStamp(User user);
        //bool GetTwoFactorEnabled(User user);
        //string GetUserId(User user);
        //string GetUserName(User user);
        IList<User> GetUsersInRole(string roleName);
        //bool HasPassword(User user);
        //int IncrementAccessFailedCount(User user);
        bool IsInRole(User user, string roleName);
        bool RemoveFromRole(User user, string roleName);
        bool RemoveLogin(User user, string loginProvider, string providerKey);
        //bool ResetAccessFailedCount(User user);
        //bool SetEmail(User user, string email);
        //bool SetEmailConfirmed(User user, bool confirmed);
        //bool SetLockoutEnabled(User user, bool enabled);
        //bool SetLockoutEndDate(User user, DateTimeOffset? lockoutEnd);
        //bool SetNormalizedEmail(User user, string normalizedEmail);
        //bool SetNormalizedUserName(User user, string normalizedName);
        //bool SetPasswordHash(User user, string passwordHash);
        //bool SetPhoneNumber(User user, string phoneNumber);
        //bool SetPhoneNumberConfirmed(User user, bool confirmed);
        //bool SetSecurityStamp(User user, string stamp);
        //bool SetTwoFactorEnabled(User user, bool enabled);
        //bool SeUserName(User user, string userName);
        int Update(User user);




        int AddClaims(User user, IEnumerable<UserClaim> claims);
        IList<UserClaim> GetClaims(User user);
        IList<User> GetUsersForClaim(UserClaim claim);
        int RemoveClaims(User user, IEnumerable<UserClaim> claims);
        int ReplaceClaim(User user, UserClaim claim, UserClaim newClaim);
    }
}
