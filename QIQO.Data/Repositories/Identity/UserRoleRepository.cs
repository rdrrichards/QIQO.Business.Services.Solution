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
    public class UserRoleRepository : IdentityRepositoryBase<UserRoleData>, IUserRoleRepository
    {
        private IIdentityDBContext entity_context;

        public UserRoleRepository(IIdentityDBContext dbc, IUserRoleMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override void Delete(UserRoleData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_role_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override IEnumerable<UserRoleData> GetAll()
        {
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_role_all"));
            }
        }

        //public IEnumerable<UserRoleData> GetAll(string user_id)
        //{
        //    Log.Info($"UserID (string): {user_id}");
        //    SqlParameter uid = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, 16);
        //    uid.Value = user_id;
        //    var pcol = new List<SqlParameter>(); // { new SqlParameter("@UserId", SqlDbType.UniqueIdentifier, 16).Value = user_id };
        //    pcol.Add(uid);
        //    using (entity_context)
        //    {
        //        var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_role_all_by_user", pcol);
        //        Log.Info("UserLoginRepository GetAll by user function call successful");
        //        return MapRows(ds);
        //    }
        //}

        public IEnumerable<UserRoleData> GetAll(Guid user_id)
        {
            //Log.Info($"UserID (Guid): {user_id}");
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserId", user_id) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_role_all_by_user", pcol));
            }
        }

        public override UserRoleData GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public override UserRoleData GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override int Save(UserRoleData entity)
        {
            Log.Debug($"Adding Role User Rel: Role:{entity.RoleID}; UserID: {entity.UserID}");
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_user_role_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}