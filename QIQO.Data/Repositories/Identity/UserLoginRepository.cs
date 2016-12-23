using QIQO.Common.Contracts;
using QIQO.Data.Entities.Identity;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_login_all"));
            }
        }

        public IEnumerable<UserLoginData> GetAll(string user_id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserId", user_id) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_login_get"));
            }
        }

        public IEnumerable<UserLoginData> GetAll(Guid user_id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserId", user_id) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_user_login_get"));
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