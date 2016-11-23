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
    public class UserClaimRepository : IdentityRepositoryBase<UserClaimData>, IUserClaimRepository
    {
        private IIdentityDBContext entity_context;

        public UserClaimRepository(IIdentityDBContext dbc, IUserClaimMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override void Delete(UserClaimData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_claim_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override IEnumerable<UserClaimData> GetAll()
        {
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_claim_all");
                Log.Info("UserLoginRepository GetAll function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<UserClaimData> GetAll(Guid user_id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@UserId", user_id) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_claim_all_by_user", pcol);
                Log.Info("UserLoginRepository GetAll by user function call successful");
                return MapRows(ds);
            }
        }

        public override UserClaimData GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public override UserClaimData GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override int Save(UserClaimData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_user_claim_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}