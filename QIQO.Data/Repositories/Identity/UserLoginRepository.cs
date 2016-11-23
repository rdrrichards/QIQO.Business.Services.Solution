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
    public class UserLoginRepository : IdentityRepositoryBase<UserLoginData>, IUserLoginRepository
    {
        private IIdentityDBContext entity_context;

        public UserLoginRepository(IIdentityDBContext dbc, IUserLoginMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override void Delete(UserLoginData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_login_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override IEnumerable<UserLoginData> GetAll()
        {
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_login_all");
                Log.Info("UserLoginRepository GetAll function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<UserLoginData> GetAll(string user_id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserId", user_id) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_login_get");
                Log.Info("UserLoginRepository GetAll by user function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<UserLoginData> GetAll(Guid user_id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserId", user_id) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_login_get");
                Log.Info("UserLoginRepository GetAll by user function call successful");
                return MapRows(ds);
            }
        }

        public override UserLoginData GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public override UserLoginData GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override int Save(UserLoginData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_user_login_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}