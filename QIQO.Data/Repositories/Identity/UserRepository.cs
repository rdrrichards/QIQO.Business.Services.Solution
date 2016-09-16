using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities.Identity;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_all");
                Log.Info("UserRepository GetAll function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<UserData> GetAllForClaim(UserClaimData claim)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@ClaimType", claim.ClaimType),
                new SqlParameter("@ClaimValue", claim.ClaimValue)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_all_for_claim", pcol);
                Log.Info("UserRepository usp_user_all_for_claim function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<UserData> GetAllInRole(string roleName)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@RoleName", roleName) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_all_in_role", pcol);
                Log.Info("UserRepository usp_user_all_in_role function call successful");
                return MapRows(ds);
            }
        }

        public bool GetUserIsInRole(Guid user_id, string roleName)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() {
                new SqlParameter("@UserID", user_id),
                new SqlParameter("@RoleName", roleName)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_is_in_role", pcol);
                Log.Info("UserRepository usp_user_is_in_role function call successful");
                return ds.Tables[0].Rows.Count > 0;
            }
        }

        public override UserData GetByID(Guid id)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@UserId", id) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_get", pcol);
                Log.Info("UserRepository (GetByID) Passed ExecuteProcedureAsDataSet (usp_user_get_by_id) function");
                return MapRow(ds);
            }
        }

        public override UserData GetByName(string name)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@UserName", name) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_get_by_name", pcol);
                Log.Info("UserRepository (GetByName) Passed ExecuteProcedureAsDataSet (usp_user_get_by_name) function");
                return MapRow(ds);
            }
        }

        public UserData GetByEmail(string email)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@Email", email) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_get_by_email", pcol);
                Log.Info("UserRepository (GetByName) Passed ExecuteProcedureAsDataSet (usp_user_get_by_email) function");
                return MapRow(ds);
            }
        }

        public UserData GetByLogin(string login_provider, string provider_key)
        {
            List<SqlParameter> pcol = new List<SqlParameter>()
                { new SqlParameter("@LoginProvider", login_provider),
                  new SqlParameter("@ProviderKey", provider_key) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_user_get_by_login", pcol);
                Log.Info("UserRepository (GetByName) Passed ExecuteProcedureAsDataSet (usp_user_get_by_login) function");
                return MapRow(ds);
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
