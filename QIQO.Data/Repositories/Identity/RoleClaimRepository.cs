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
    public class RoleClaimRepository : IdentityRepositoryBase<RoleClaimData>, IRoleClaimRepository
    {
        private IIdentityDBContext entity_context;

        public RoleClaimRepository(IIdentityDBContext dbc, IRoleClaimMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override void Delete(RoleClaimData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_role_claim_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override IEnumerable<RoleClaimData> GetAll()
        {
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_role_claim_all");
                Log.Info("UserLoginRepository GetAll function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<RoleClaimData> GetAll(string role_id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@RoleId", role_id) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_role_claim_all_by_role");
                Log.Info("UserLoginRepository GetAll by user function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<RoleClaimData> GetAll(Guid role_id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@RoleId", role_id) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_role_claim_all_by_role");
                Log.Info("UserLoginRepository GetAll by user function call successful");
                return MapRows(ds);
            }
        }

        public override RoleClaimData GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public override RoleClaimData GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override int Save(RoleClaimData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_user_claim_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}