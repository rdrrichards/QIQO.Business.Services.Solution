using QIQO.Common.Contracts;
using QIQO.Data.Entities.Identity;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class UserRepository : IdentityRepositoryBase<UserData>, IUserRepository
    {
        private IIdentityDBContext entity_context;

        public UserRepository(IIdentityDBContext dbc, IUserMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }
        public override void Delete(UserData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override IEnumerable<UserData> GetAll()
        {
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_all"));
            }
        }

        public IEnumerable<UserData> GetAllForClaim(UserClaimData claim)
        {
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@ClaimType", claim.ClaimType),
                new SqlParameter("@ClaimValue", claim.ClaimValue)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_all_for_claim", pcol));
            }
        }

        public IEnumerable<UserData> GetAllInRole(string roleName)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@RoleName", roleName) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_all_in_role", pcol));
            }
        }

        public bool GetUserIsInRole(Guid user_id, string roleName)
        {
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@UserID", user_id),
                new SqlParameter("@RoleName", roleName)
            };
            using (entity_context)
            {
                return entity_context.ExecuteProcedureAsSqlDataReader("usp_user_is_in_role", pcol).HasRows;
            }
        }

        public override UserData GetByID(Guid id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserId", id) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_get", pcol));
            }
        }

        public override UserData GetByName(string name)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserName", name) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_get_by_name", pcol));
            }
        }

        public UserData GetByEmail(string email)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@Email", email) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_get_by_email", pcol));
            }
        }

        public UserData GetByLogin(string login_provider, string provider_key)
        {
            var pcol = new List<SqlParameter>()
                { new SqlParameter("@LoginProvider", login_provider),
                  new SqlParameter("@ProviderKey", provider_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_get_by_login", pcol));
            }
        }

        public override int Save(UserData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_ups", Mapper.MapParamsForUpsert(entity));
                return 1;
            }
        }
    }
}
