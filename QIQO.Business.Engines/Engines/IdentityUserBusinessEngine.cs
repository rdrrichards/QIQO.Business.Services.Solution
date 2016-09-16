using QIQO.Data.Entities.Identity;
using QIQO.Business.Entities;
using System;
using QIQO.Data.Interfaces;
using QIQO.Common.Contracts;
using QIQO.Business.Contracts;
using System.Collections.Generic;
using QIQO.Common.Core.Logging;

namespace QIQO.Business.Engines
{
    public class IdentityUserBusinessEngine : EngineBase, IIdentityUserBusinessEngine
    {
        public IdentityUserBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact)
            : base(data_repo_fact, bus_eng_fact, null)
        {

        }

        public int AddLogin(User user, UserLogin user_login)
        {
            IUserLoginRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserLoginRepository>();
            UserLoginData ul = new UserLoginData()
            {
                LoginProvider = user_login.LoginProvider,
                ProviderKey = user_login.ProviderKey,
                UserID = user.UserId,
                ProviderDisplayName = user_login.ProviderDisplayName
            };

            return repo.Save(ul);
        }

        public int AddToRole(User user, string roleName)
        {
            IUserRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRoleRepository>();
            IIdentityRoleBusinessEngine role_be = _business_engine_factory.GetBusinessEngine<IIdentityRoleBusinessEngine>();
            var role = role_be.FindByName(roleName);

            Log.Debug($"Adding Role User Rel: Role:{role.RoleId}; UserID: {user.UserId}");

            UserRoleData ur = new UserRoleData()
            {
                RoleID = role.RoleId,
                UserID = user.UserId
            };

            return repo.Save(ur);
        }

        public int Create(User user)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            return repo.Save(MapUserToUserData(user));
        }

        public bool Delete(User user)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            UserData u = new UserData() { Id = user.UserId };
            repo.Delete(u);
            return true;
        }

        public User FindByEmail(string normalizedEmail)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            return MapUserDataToUser(repo.GetByEmail(normalizedEmail));
        }

        public User FindById(Guid userId)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            return MapUserDataToUser(repo.GetByID(userId));
        }

        public User FindByLogin(string loginProvider, string providerKey)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            return MapUserDataToUser(repo.GetByLogin(loginProvider, providerKey));
        }

        public User FindByName(string normalizedUserName)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            return MapUserDataToUser(repo.GetByName(normalizedUserName));
        }

        public IList<UserLogin> GetLogins(User user)
        {
            IUserLoginRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserLoginRepository>();
            List<UserLogin> uls = new List<UserLogin>();
            var collection = repo.GetAll(user.UserId);
            foreach (UserLoginData uld in collection)
                uls.Add(MapUserLoginDataToUserLogin(uld));
            return uls;
        }

        public IList<string> GetRoles(User user)
        {
            IUserRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRoleRepository>();
            IIdentityRoleBusinessEngine role_be = _business_engine_factory.GetBusinessEngine<IIdentityRoleBusinessEngine>();

            List<string> uls = new List<string>();
            var collection = repo.GetAll(user.UserId);
            foreach (UserRoleData uld in collection)
            {
                var role = role_be.FindById(uld.RoleID);
                uls.Add(role.Name);
            }
            return uls;
        }

        public IList<User> GetUsersInRole(string roleName)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();

            List<User> users = new List<User>();
            var user_data = repo.GetAllInRole(roleName);
            foreach (var ucd in user_data)
            {
                users.Add(MapUserDataToUser(ucd));
            }
            return users;
        }

        public bool IsInRole(User user, string roleName)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            return repo.GetUserIsInRole(user.UserId, roleName);
        }

        public bool RemoveFromRole(User user, string roleName)
        {
            IUserRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRoleRepository>();
            IIdentityRoleBusinessEngine role_be = _business_engine_factory.GetBusinessEngine<IIdentityRoleBusinessEngine>();
            var role = role_be.FindByName(roleName);

            UserRoleData ur = new UserRoleData()
            {
                RoleID = role.RoleId,
                UserID = user.UserId
            };
            repo.Delete(ur);
            return true;
        }

        public bool RemoveLogin(User user, string loginProvider, string providerKey)
        {
            IUserLoginRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserLoginRepository>();

            repo.Delete(new UserLoginData() { UserID = user.UserId, LoginProvider = loginProvider, ProviderKey = providerKey });
            return true;
        }

        public int Update(User user)
        {
            IUserRepository repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            return repo.Save(MapUserToUserData(user));
        }

        private User MapUserDataToUser(UserData user_data)
        {
            return new User()
            {
                UserId = user_data.Id,
                Email = user_data.Email,
                NormalizedEmail = user_data.NormalizedEmail,
                EmailConfirmed = user_data.EmailConfirmed,
                PasswordHash = user_data.PasswordHash,
                SecurityStamp = user_data.SecurityStamp,
                PhoneNumber = user_data.PhoneNumber,
                PhoneNumberConfirmed = user_data.PhoneNumberConfirmed,
                TwoFactorEnabled = user_data.TwoFactorEnabled,
                LockoutEnd = user_data.LockoutEnd,
                LockoutEnabled = user_data.LockoutEnabled,
                AccessFailedCount = user_data.AccessFailedCount,
                UserName = user_data.UserName,
                NormalizedUserName = user_data.NormalizedUserName
            };
        }

        private UserData MapUserToUserData(User user_data)
        {
            return new UserData()
            {
                Id = user_data.UserId,
                Email = user_data.Email,
                NormalizedEmail = user_data.NormalizedEmail,
                EmailConfirmed = user_data.EmailConfirmed,
                PasswordHash = user_data.PasswordHash,
                SecurityStamp = user_data.SecurityStamp,
                PhoneNumber = user_data.PhoneNumber,
                PhoneNumberConfirmed = user_data.PhoneNumberConfirmed,
                TwoFactorEnabled = user_data.TwoFactorEnabled,
                LockoutEnd = user_data.LockoutEnd,
                LockoutEnabled = user_data.LockoutEnabled,
                AccessFailedCount = user_data.AccessFailedCount,
                UserName = user_data.UserName,
                NormalizedUserName = user_data.NormalizedUserName
            };
        }

        private UserLogin MapUserLoginDataToUserLogin(UserLoginData user_data)
        {
            return new UserLogin()
            {
                UserID = user_data.UserID,
                LoginProvider = user_data.LoginProvider,
                ProviderKey = user_data.ProviderKey,
                ProviderDisplayName = user_data.ProviderDisplayName
            };
        }

        public int AddClaims(User user, IEnumerable<UserClaim> claims)
        {
            IUserClaimRepository uc_repo = _data_repository_factory.GetIdentityDataRepository<IUserClaimRepository>();

            foreach (var uc in claims)
            {
                UserClaimData ucd = new UserClaimData() { UserID = user.UserId, Id = uc.ClaimID, ClaimType = uc.ClaimType, ClaimValue = uc.ClaimValue };
                int result = uc_repo.Save(ucd);
            }

            return 1;
        }

        public IList<UserClaim> GetClaims(User user)
        {
            IUserClaimRepository uc_repo = _data_repository_factory.GetIdentityDataRepository<IUserClaimRepository>();
            List<UserClaim> ucs = new List<UserClaim>();
            var claims = uc_repo.GetAll(user.UserId);
            foreach (var ucd in claims)
            {
                ucs.Add(new UserClaim() { UserID = ucd.UserID, ClaimID = ucd.Id, ClaimType = ucd.ClaimType, ClaimValue = ucd.ClaimValue });
            }
            return ucs;
        }

        public IList<User> GetUsersForClaim(UserClaim claim)
        {
            IUserRepository uc_repo = _data_repository_factory.GetIdentityDataRepository<IUserRepository>();
            List<User> users = new List<User>();
            var claims = uc_repo.GetAllForClaim(new UserClaimData() { ClaimType = claim.ClaimType, ClaimValue = claim.ClaimValue });
            foreach (var ucd in claims)
            {
                users.Add(MapUserDataToUser(ucd));
            }
            return users;
        }

        public int RemoveClaims(User user, IEnumerable<UserClaim> claims)
        {
            IUserClaimRepository uc_repo = _data_repository_factory.GetIdentityDataRepository<IUserClaimRepository>();

            foreach (var uc in claims)
            {
                UserClaimData ucd = new UserClaimData() { UserID = user.UserId, Id = uc.ClaimID, ClaimType = uc.ClaimType, ClaimValue = uc.ClaimValue };
                uc_repo.Delete(ucd);
            }

            return 1;
        }

        public int ReplaceClaim(User user, UserClaim claim, UserClaim newClaim)
        {
            IUserClaimRepository uc_repo = _data_repository_factory.GetIdentityDataRepository<IUserClaimRepository>();
            UserClaimData rem_ucd = new UserClaimData() { UserID = user.UserId, Id = claim.ClaimID,
                ClaimType = claim.ClaimType, ClaimValue = claim.ClaimValue };
            uc_repo.Delete(rem_ucd);
            UserClaimData new_ucd = new UserClaimData() { UserID = user.UserId, Id = newClaim.ClaimID,
                ClaimType = newClaim.ClaimType, ClaimValue = newClaim.ClaimValue };
            return uc_repo.Save(new_ucd);
        }

        //public int GetAccessFailedCount(User user)
        //public string GetEmail(User user)
        //public bool GetEmailConfirmed(User user)
        //public bool GetLockoutEnabled(User user)
        //public DateTimeOffset? GetLockoutEndDate(User user)
        //public string GetNormalizedEmail(User user)
        //public string GetNormalizedUserName(User user)
        //public string GetPasswordHash(User user)
        //public string GetPhoneNumber(User user)
        //public bool GetPhoneNumberConfirmed(User user)
        //public string GetSecurityStamp(User user)
        //public bool GetTwoFactorEnabled(User user)
        //public string GetUserId(User user)
        //public string GetUserName(User user)
        //public bool HasPassword(User user)    
        //public int IncrementAccessFailedCount(User user)    
        //public bool ResetAccessFailedCount(User user)
        //public bool SetEmail(User user, string email)
        //public bool SetEmailConfirmed(User user, bool confirmed)
        //public bool SetLockoutEnabled(User user, bool enabled)
        //public bool SetLockoutEndDate(User user, DateTimeOffset? lockoutEnd)
        //public bool SetNormalizedEmail(User user, string normalizedEmail)
        //public bool SetNormalizedUserName(User user, string normalizedName)
        //public bool SetPasswordHash(User user, string passwordHash)
        //public bool SetPhoneNumber(User user, string phoneNumber)
        //public bool SetPhoneNumberConfirmed(User user, bool confirmed)
        //public bool SetSecurityStamp(User user, string stamp)
        //public bool SetTwoFactorEnabled(User user, bool enabled)
        //public bool SeUserName(User user, string userName)
    }

}
