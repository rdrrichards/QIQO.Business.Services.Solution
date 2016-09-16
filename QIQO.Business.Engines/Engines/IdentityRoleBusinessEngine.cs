using QIQO.Business.Entities;
using QIQO.Data.Interfaces;
using QIQO.Common.Contracts;
using QIQO.Business.Contracts;
using QIQO.Data.Entities.Identity;
using System;
using System.Collections.Generic;

namespace QIQO.Business.Engines
{
    public class IdentityRoleBusinessEngine : EngineBase, IIdentityRoleBusinessEngine
    {
        public IdentityRoleBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact)
        : base(data_repo_fact, bus_eng_fact, null)
        {

        }

        public int Create(Role role)
        {
            IRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleRepository>();
            return repo.Save(MapRoleToRoleData(role));
        }

        public bool Delete(Role role)
        {
            IRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleRepository>();
            repo.Delete(MapRoleToRoleData(role));
            return true;
        }

        public Role FindById(Guid roleId)
        {
            IRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleRepository>();
            return MapRoleDataToRole(repo.GetByID(roleId));
        }

        public Role FindByName(string normalizedRoleName)
        {
            IRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleRepository>();
            return MapRoleDataToRole(repo.GetByName(normalizedRoleName));
        }

        //public bool SetNormalizedRoleName(Role role, string normalizedName)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool SetRoleName(Role role, string roleName)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Update(Role role)
        {
            IRoleRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleRepository>();
            repo.Save(MapRoleToRoleData(role));
            return true;
        }

        private RoleData MapRoleToRoleData(Role role)
        {
            return new RoleData()
            {
                RoleId = role.RoleId,
                Name = role.Name,
                NormalizedName = role.NormalizedName
            };
        }

        private Role MapRoleDataToRole(RoleData role)
        {
            return new Role()
            {
                RoleId = role.RoleId,
                Name = role.Name,
                NormalizedName = role.NormalizedName
            };
        }

        public int AddClaim(Role role, RoleClaim claim)
        {
            IRoleClaimRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleClaimRepository>();
            return repo.Save(new RoleClaimData() { Id = claim.ClaimID, RoleID = role.RoleId, ClaimType = claim.ClaimType, ClaimValue = claim.ClaimValue });
        }

        public IList<RoleClaim> GetClaims(Role role)
        {
            IRoleClaimRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleClaimRepository>();
            List<RoleClaim> rcs = new List<RoleClaim>();
            var rcds = repo.GetAll(role.RoleId);
            foreach (var rcd in rcds)
            {
                rcs.Add(new RoleClaim() { ClaimID = rcd.Id, RoleID = rcd.RoleID, ClaimType = rcd.ClaimType, ClaimValue = rcd.ClaimValue });
            }
            return rcs;
        }

        public int RemoveClaim(Role role, RoleClaim claim)
        {
            IRoleClaimRepository repo = _data_repository_factory.GetIdentityDataRepository<IRoleClaimRepository>();
            repo.Delete(new RoleClaimData() { Id = claim.ClaimID, RoleID = role.RoleId, ClaimType = claim.ClaimType, ClaimValue = claim.ClaimValue });
            return 1;
        }

        //public string GetNormalizedRoleName(Role role)
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetRoleId(Role role)
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetRoleName(Role role)
        //{
        //    throw new NotImplementedException();
        //}
    }
}